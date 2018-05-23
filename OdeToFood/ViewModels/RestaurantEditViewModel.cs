using OdeToFood.Model;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.ViewModels
{
    public class RestaurantEditViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public CuisineType Cuisine { get; set; }

    }
}
