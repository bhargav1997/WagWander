﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WagWander.Models;

namespace WagWander.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var locations = db.Locations.ToList();

            List<MediaItem> MediaItems = db.MediaItems.ToList();
            List<MediaItemDto> MediaItemDtos = new List<MediaItemDto>();

            MediaItems.ForEach(m => MediaItemDtos.Add(new MediaItemDto()
            {
                MediaItemID = m.MediaItemID,
                Title = m.Title,
                Type = m.Type,
                Description = m.Description,
                ReleaseDate = m.ReleaseDate,
                Genre = m.Genre,
                LocationId = m.LocationId,
                LocationName = m.Location.LocationName
            }));

            var locationDtos = locations.Select(location => new LocationDto
            {
                LocationId = location.LocationId,
                LocationName = location.LocationName,
                LocationDescription = location.LocationDescription,
                Category = location.Category,
                Address = location.Address,
                CreatedDate = location.CreatedDate,
                AverageRating = location.Reviews.Any() ? Math.Round(location.Reviews.Average(r => r.Rating), 2) : 0,
                LocationHasPic = location.LocationHasPic,
                PicExtension = location.PicExtension,
            }).ToList();

            List<Pet> Pets = db.Pets.ToList();
            List<PetDto> PetDtos = new List<PetDto>();

            Pets.ForEach(p => PetDtos.Add(new PetDto()
            {
                PetId = p.PetId,
                Name = p.Name,
                Species = p.Species,
                Breed = p.Breed,
                Age = p.Age
            }));

            var viewModel = new WagWanderModel
            {
                Locations = locationDtos,
                MediaItems = MediaItemDtos,
                Pets = PetDtos
            };

            return View(viewModel);
        }

        public ActionResult Media()
        {
            return View();
        }

        public ActionResult Pets()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A CMS for local guides to share information about attractions, restaurants, events, and services in their area.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}