using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coffee_Shop_Lab.DALModels;
using Coffee_Shop_Lab.DomainModels;
using Coffee_Shop_Lab.Models.CoffeeShop;
using Coffee_Shop_Lab.Services;
using Microsoft.AspNetCore.Mvc;

namespace Coffee_Shop_Lab.Controllers
{
    public class CoffeeShopController : Controller
    {

        private readonly ICoffeeShop _coffeeshop;
        private readonly CoffeeShopContext _coffeeShopContext;

        public CoffeeShopController(ICoffeeShop coffeeshop, CoffeeShopContext coffeeShopContext)
        {

            _coffeeshop = coffeeshop;

            _coffeeShopContext = coffeeShopContext;
        }

       

        public IActionResult RegisterUser()
        {
            return View();
        }


        public IActionResult FormResult(FormViewModel model)
        {
            var user = new UsersDAL();
           // var user = new Users();
            //var dalModel = new UsersDAL();

            //dalModel.FirstName = model.FirstName;
            //dalModel.LastName = model.LastName;
            //dalModel.Email = model.Email;
            //dalModel.PhoneNumber = model.PhoneNumber;
            //dalModel.Age = model.Age;
            //dalModel.DateOfBirth = model.DateOfBirth;
            //dalModel.Password = model.Password;
            //dalModel.ConfirmPassword = model.ConfirmPassword;

            //_coffeeShopContext.Users.Add(dalModel);
            //_coffeeShopContext.SaveChanges();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.Age = model.Age;
            user.DateOfBirth = model.DateOfBirth;
            user.Password = model.Password;
            user.ConfirmPassword = model.ConfirmPassword;

            _coffeeShopContext.Users.Add(user);
            _coffeeShopContext.SaveChanges();
            //var viewModel = new FormResultViewModel();
            //viewModel.Users = _coffeeshop.Users;

            return FormResultView();

        }

        public IActionResult MakeNewUser(UsersViewModel users, int id)

        {
            var user = GetUserWhereIdIsFirstOrDefault(id);

            var usersDAL = _coffeeShopContext
                .Users
                .FirstOrDefault(usersDAL => users.UserID == user.UserID);
            usersDAL.FirstName = users.FirstName;
            usersDAL.LastName = users.LastName;
            usersDAL.Email = users.Email;
            usersDAL.PhoneNumber = users.PhoneNumber;
            usersDAL.Age = users.Age;
            usersDAL.DateOfBirth = users.DateOfBirth;
            usersDAL.Password = users.Password;
            usersDAL.ConfirmPassword = users.ConfirmPassword;

           _coffeeShopContext.SaveChanges();

            return FormResultView();
        }

        private UsersViewModel GetUserWhereIdIsFirstOrDefault(int id)
        {
            UsersDAL usersDAL  = _coffeeShopContext.Users
                .Where(users => users.UserID == id)
                .FirstOrDefault();

           var users = new UsersViewModel();
            users.UserID = usersDAL.UserID;
            users.FirstName = usersDAL.FirstName;
            users.Email = usersDAL.Email;
            users.PhoneNumber = usersDAL.PhoneNumber;
            users.Age = usersDAL.Age;
            usersDAL.DateOfBirth = users.DateOfBirth;
            usersDAL.Password = users.Password;
            usersDAL.ConfirmPassword = users.ConfirmPassword;

            return users;
        }


        private IActionResult FormResultView()
        {
        

            var viewModel = new FormResultViewModel();

            var users = _coffeeShopContext.Users.ToList();


            var usersViewModelList = users
                .Select(usersDal => new UsersViewModel()

                { UserID = usersDal.UserID,
                    FirstName = usersDal.FirstName,
                    LastName = usersDal.LastName,
                    Email = usersDal.Email,
                    PhoneNumber = usersDal.PhoneNumber,
                    Age = usersDal.Age,
                    DateOfBirth = usersDal.DateOfBirth,
                    Password = usersDal.Password,
                    ConfirmPassword = usersDal.ConfirmPassword
                }) .ToList();

            viewModel.Users = usersViewModelList;

            return View("FormResult", viewModel);
        }

        public IActionResult Login()
        {

            return View();
        }

        public IActionResult LoginResult(LoginViewModel model)
        {
            var viewModel = new LoginResultViewModel();
            viewModel.UserName = model.UserName;
            viewModel.Password = model.Password;
            return View(viewModel);
        }



        public IActionResult Shop()
        {
            var model = new List<ItemsDAL>();

            model.Add(new ItemsDAL  { Name = "Donut" });
            model.Add(new ItemsDAL { Name = "Banana Nut Bread" });
            model.Add(new ItemsDAL { Name = "Bagel" });
            model.Add(new ItemsDAL { Name = "Iced Coffee" });
            model.Add(new ItemsDAL { Name = "Lemon Ice Tea" });
            model.Add(new ItemsDAL { Name = "Hot Chocolate" });
            model.Add(new ItemsDAL { Name = "Coffee"});
            model.Add(new ItemsDAL { Name = "Pop tart" });
            model.Add(new ItemsDAL { Name = "fruit cup" });
            model.Add(new ItemsDAL { Name = "soup" });


            return View(model);
        }



    }
}



