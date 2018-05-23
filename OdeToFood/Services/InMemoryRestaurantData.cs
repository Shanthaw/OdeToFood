using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Model;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant{  Id=1, Name="Scott's Piza"},
                new Restaurant{ Id=2, Name="Shantha hotel"},
                new Restaurant{ Id =3, Name="King's Indian"}
            };
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(restaurant);
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(a => a.Name);
        }

        public Restaurant GetRestaurant(int id)
        {
          return  _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }
    }
}
