﻿using System;
using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Models.Restaurant;
using RestaurantRaterMVC.Services;

namespace RestaurantRaterMVC.Controllers
{
	public class RestaurantController : Controller
	{
		private IRestaurantService _service;
		public RestaurantController(IRestaurantService service)
		{
			_service = service;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			List<RestaurantListItem> restaurants = await _service.GetAllRestaurants();
			return View(restaurants);
		}

		public async Task<IActionResult> Create()
		{			
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(RestaurantCreate model)
		{
			if (ModelState.IsValid)
				return View(model);

			await _service.CreateResturant(model);
			return RedirectToAction(nameof(Index));
		}
	}
}
