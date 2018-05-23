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
    public class ResCreateModel : PageModel
    {
        private IRestaurantData _restuarantData;

        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }

       
        public ResCreateModel(IRestaurantData restuarantData)
        {
            _restuarantData = restuarantData;
        }
        public void OnGet()
        {

        }
        [ValidateAntiForgeryToken]
        public void OnPost(Restaurant resCreateModel)
        {
            var resturarent = new Restaurant
            {
                Cuisine = resCreateModel.Cuisine,
                Name = resCreateModel.Name
            };

            _restuarantData.Add(resturarent);
            Response.Redirect("all");
        }
    }
}