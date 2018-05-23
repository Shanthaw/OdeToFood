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
    public class ResEditModel : PageModel
    {
        private readonly IRestaurantData _restuarantData;

        [BindProperty]
        public Restaurant Restuarant { get; set; }

        public ResEditModel(IRestaurantData restuarantData)
        {
            _restuarantData = restuarantData;
        }
        public IActionResult OnGet(int id)
        {
            Restuarant = _restuarantData.GetRestaurant(id);

            if (Restuarant == null)
            {
                return RedirectToPage("All");
            }
            else
                return Page();


        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _restuarantData.Update(Restuarant);

                return RedirectToPage("ResDetails", new { id = Restuarant.Id });

            }
            else
            {
                return Page();
            }

        }
    }
}