using System;

namespace RestaurantRaterMVC.Data
{
	public class Rating
	{
		public int Id {  get; set; }
		public int RestaurantId {  get; set; }
		public double FoodScore {  get; set; }
		public double CleanlinessScore {  get; set; }
		public double AtomsphereScore {  get; set; }
		public virtual Restaurant Restaurant { get; set; }
	}
}
