using AutoServiceWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoServiceWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.VehicleCount = await _context.Vehicles.CountAsync();
            ViewBag.OrderCount = await _context.ServiceOrders.CountAsync();

            ViewBag.NewOrders = await _context.ServiceOrders
                .CountAsync(o => o.Status == "Yeni");

            ViewBag.CompletedOrders = await _context.ServiceOrders
                .CountAsync(o => o.Status == "Hazırdır");

            return View();
        }
    }
}