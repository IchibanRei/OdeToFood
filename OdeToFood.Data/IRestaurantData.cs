using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetResaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's  Pizza", Location = "Maryland", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Curtis's Tandori Kitchen", Location = "California", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 3, Name = "Ethan's Burritos", Location = "Texas", Cuisine = CuisineType.Mexican}
            };
        }
        public IEnumerable<Restaurant> GetResaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase)
                   orderby r.Name
                   select r;
        }
    }
}
