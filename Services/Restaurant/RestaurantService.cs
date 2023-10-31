using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RestaurantRaterMVC.Data;
using Microsoft.EntityFrameworkCore.SqlServer;
using RestaurantRaterMVC.Models.Restaurant;

namespace RestaurantRaterMVC.Services.Restuarant
{
	public class RestaurantService
	{
		private RestaurantDbContext _context;
        public RestaurantService(RestaurantDbContext context)
        {
            _context = context;
        }    

		public async Task<List<RestaurantListItem>> GetAllRestaurants()
		{
			List<RestaurantListItem> restaurants = await _context.Restaurants
			.Include(r => r.Ratings)
			.Select(r  => new RestaurantListItem()
			 {
				Id = r.Id,
				Name = r.Name,
				Score = r.Score,
			 }).ToListAsync();
		return restaurants;
		}

		public async Task<bool> CreateRestaurant(RestaurantCreate model)
		{
			Restaurant restaurant = new Restaurant()
			{
				Name = model.Name,
				Location = model.Location,
			};
			_context.Restaurants.Add(restaurant);
			return await _context.SaveChangesAsync() == 1;
		}
	}  	
}
		