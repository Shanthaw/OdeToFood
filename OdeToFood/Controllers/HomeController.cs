using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Model;
using OdeToFood.Services;
using OdeToFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    [Authorize]
    public class HomeController:Controller
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData,IGreeter greeter)
        {
            this._restaurantData = restaurantData;
            this._greeter = greeter;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay();

            return View(model);
        }
        public IActionResult Details(int id)
        {

            var model = _restaurantData.GetRestaurant(id);
            if (model == null)
            {
                return View("NotFound");


            }
            else
            {
                return View(model);
            }

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestuarent = new Restaurant
                {
                    Name = model.Name,
                    Cuisine = model.Cuisine
                };

                newRestuarent = _restaurantData.Add(newRestuarent);

                return RedirectToAction(nameof(Details), new { Id = newRestuarent.Id });
            }

            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var restuarant =_restaurantData.GetRestaurant(id);
            if (restuarant == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var viewModel = new RestaurantEditViewModel
                {
                    Id = restuarant.Id,
                    Name = restuarant.Name,
                    Cuisine = restuarant.Cuisine
                           
                };

                return View(viewModel);
            }
        }
        public IActionResult Edit(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var restuarant = new Restaurant {

                    Cuisine = model.Cuisine,
                    Id = model.Id,
                    Name = model.Name
                };
                _restaurantData.Update(restuarant);
                return RedirectToAction("Details", "Home", new { id = restuarant.Id });

            }
            else
            {
                return View();

            }


        }
    }
}
