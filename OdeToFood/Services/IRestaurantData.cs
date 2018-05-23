using OdeToFood.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetRestaurant(int id);
        Restaurant Add(Restaurant restaurant);
        Restaurant Update(Restaurant restaurant);
    }
}
