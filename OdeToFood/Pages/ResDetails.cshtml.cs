using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Model;
using OdeToFood.Services;

namespace OdeToFood.Pages
{
    public class ResDetailsModel : PageModel
    {
        private readonly IRestaurantData _restuarantData;

        public Restaurant restaurant { get; set; }

        public ResDetailsModel(IRestaurantData restaurantData)
        {
            _restuarantData = restaurantData;
        }
        public void OnGet(int id)
        {
            restaurant = _restuarantData.GetRestaurant(id);

        }
    }
}