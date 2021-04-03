using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vehicle_Details.Data;
using Vehicle_Details.Models;

namespace Vehicle_Details.Controllers
{
    public class VehicleRegistrationsController : Controller
    {
        private readonly MvcVehicleRegoContext _context;

        public VehicleRegistrationsController(MvcVehicleRegoContext context)
        {
            _context = context;
        }

        // GET: VehicleRegistrations
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleRegistration.ToListAsync());
        }

        // GET: VehicleRegistrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleRegistration = await _context.VehicleRegistration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleRegistration == null)
            {
                return NotFound();
            }

            return View(vehicleRegistration);
        }

        // GET: VehicleRegistrations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleRegistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Manufacturer,Year,Weight")] VehicleRegistration vehicleRegistration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleRegistration);
        }

        // GET: VehicleRegistrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleRegistration = await _context.VehicleRegistration.FindAsync(id);
            if (vehicleRegistration == null)
            {
                return NotFound();
            }
            return View(vehicleRegistration);
        }

        // POST: VehicleRegistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Manufacturer,Year,Weight")] VehicleRegistration vehicleRegistration)
        {
            if (id != vehicleRegistration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleRegistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleRegistrationExists(vehicleRegistration.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleRegistration);
        }

        // GET: VehicleRegistrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleRegistration = await _context.VehicleRegistration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleRegistration == null)
            {
                return NotFound();
            }

            return View(vehicleRegistration);
        }

        // POST: VehicleRegistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleRegistration = await _context.VehicleRegistration.FindAsync(id);
            _context.VehicleRegistration.Remove(vehicleRegistration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleRegistrationExists(int id)
        {
            return _context.VehicleRegistration.Any(e => e.Id == id);
        }
    }
}
