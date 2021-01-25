using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coffee_Shop_Lab.Models.CoffeeShop;
using Coffee_Shop_Lab.Services;
using Microsoft.AspNetCore.Mvc;

namespace Coffee_Shop_Lab.Controllers
{
    public class CoffeeShopController : Controller
    {

        private readonly ICoffeeShop _coffeeshop;

        public CoffeeShopController(ICoffeeShop coffeeshop)
        {

            _coffeeshop = coffeeshop;
        }


        public IActionResult RegisterUser()
        {
            return View();
        }

      public IActionResult FormResult(FormViewModel model)
        {

                var user = new Users();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.Age = model.Age;
                user.DateOfBirth = model.DateOfBirth;
                user.Password = model.Password;
                user.ConfirmPassword = model.ConfirmPassword;

                _coffeeshop.Users.Add(user);
                var viewModel = new FormResultViewModel();
                viewModel.Users = _coffeeshop.Users;
                return View (viewModel);

      }  

       /* private IActionResult FormResultView()
        {
            var viewModel = new FormResultViewModel();
            viewModel.Users = _coffeeshop.Users;


            return View("FormResult", viewModel);
        }    */  

    }
}



