using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant() { Id = 1, Name = "La Frontera", Location = "Bountiful", Cuisine = CuisineType.Mexican },
                new Restaurant() { Id = 2, Name = "Great China Wall", Location = "Ogden", Cuisine = CuisineType.Chinese },
                new Restaurant() { Id = 3, Name = "Bucca Di Beppo", Location = "Salt Lake City", Cuisine = CuisineType.Italian}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
