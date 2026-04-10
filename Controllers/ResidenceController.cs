using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AirBB.Models.DomainModels;
using AirBB.Models.ViewModels;
using AirBB.Models.DataLayer;
using AirBB.Models.Utilities;

namespace AirBB.Controllers
{
    public class ResidenceController : Controller
    {
        private readonly AirBBContext context;

        public ResidenceController(AirBBContext ctx) => context = ctx;

        // Phase 1 routing test action for Homes link
        public IActionResult List(string id = "All")
        {
            return Content($"Area=Public, Controller=Residence, Action=List, ID={id}");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var session = new AirBBSession(HttpContext.Session);

            var model = new ResidenceViewModel
            {
                Criteria = session.GetFilter() ?? new(),
                Residence = context.Residences?
                    .Include(r => r.Location)
                    .FirstOrDefault(r => r.ResidenceId == id) ?? new Residence()
            };

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Reserve(int id)
        {
            var session = new AirBBSession(HttpContext.Session);
            var cookies = new AirBBCookies(Request, Response);

            var residence = context.Residences?
                .Include(r => r.Location)
                .FirstOrDefault(r => r.ResidenceId == id);

            if (residence == null)
                return RedirectToAction("Index", "Home");

            var reservation = new Reservation
            {
                ReservationId = context.Reservations?.Any() == true
                    ? context.Reservations.Max(r => r.ReservationId) + 1
                    : 1,
                ResidenceId = residence.ResidenceId,
                Residence = residence,
                ReservationStartDate = DateTime.Today,
                ReservationEndDate = DateTime.Today.AddDays(2)
            };

            context.Reservations?.Add(reservation);
            context.SaveChanges();

            var reservations = session.GetReservations(context) ?? new List<Reservation>();
            reservations.Add(reservation);
            session.SetReservations(reservations);

            cookies.SetReservationIds(reservations);

            TempData["message"] = $"{residence.Name} reserved successfully!";
            return RedirectToAction("Index", "Home");
        }
    }
}