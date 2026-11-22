using AutoServiceWeb.Data;
using AutoServiceWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoServiceWeb.Controllers
{
    public class ServiceOrdersController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceOrdersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.ServiceOrders
                .Include(o => o.Vehicle)
                .ToListAsync();

            return View(orders);
        }

        public async Task<IActionResult> Create()
        {
            await LoadVehicles();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceOrder order)
        {
            ModelState.Remove("Vehicle");

            if (ModelState.IsValid)
            {
                _context.ServiceOrders.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            await LoadVehicles(order.VehicleId);
            return View(order);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.ServiceOrders.FindAsync(id);

            if (order == null) return NotFound();

            await LoadVehicles(order.VehicleId);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceOrder order)
        {
            if (id != order.Id) return NotFound();

            ModelState.Remove("Vehicle");

            if (ModelState.IsValid)
            {
                _context.Update(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            await LoadVehicles(order.VehicleId);
            return View(order);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var order = await _context.ServiceOrders
                .Include(o => o.Vehicle)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();

            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.ServiceOrders.FindAsync(id);

            if (order != null)
            {
                _context.ServiceOrders.Remove(order);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task LoadVehicles(int? selectedId = null)
        {
            var vehicles = await _context.Vehicles.ToListAsync();

            ViewBag.VehicleId = new SelectList(
                vehicles,
                "Id",
                "LicensePlate",
                selectedId
            );
        }
    }
}