﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Model;
using OdeToFood.Services;

namespace OdeToFood.Pages
{
    public class AllModel : PageModel
    {
        private IRestaurantData _restaurantData;
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public AllModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public void OnGet()
        {
            Restaurants = _restaurantData.GetAll();
        }
    }
}