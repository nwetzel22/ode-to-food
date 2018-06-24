using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.Data;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext _odeToFoodDbContext;

        public SqlRestaurantData(OdeToFoodDbContext odeToFoodDbContext)
        {
            _odeToFoodDbContext = odeToFoodDbContext;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _odeToFoodDbContext.Add(newRestaurant);
            _odeToFoodDbContext.SaveChanges();
            return newRestaurant;
        }

        public Restaurant Get(int id)
        {
            return _odeToFoodDbContext.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _odeToFoodDbContext.Restaurants.OrderBy(r => r.Name);
        }
    }
}
