using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;
using OdeToFood.Model;

namespace OdeToFood.Services
{
    public class SqlRestuarantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext _context;

        public SqlRestuarantData(OdeToFoodDbContext context)
        {
            this._context = context;
        }
        public Restaurant Add(Restaurant restaurant)
        {
            _context.Add(restaurant);
            _context.SaveChanges();
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restuaranets.OrderBy(r => r.Name);
        }

        public Restaurant GetRestaurant(int id)
        {
            return _context.Restuaranets.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant restaurant)
        {
            _context.Attach(restaurant).State = EntityState.Modified;
            _context.SaveChanges();
            return restaurant;
        }
    }
}
