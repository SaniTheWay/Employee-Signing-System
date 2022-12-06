using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Employee_Signing_System.Models;

namespace Employee_Signing_System.Controllers
{
    public class TempBadgeController : Controller
    {
        private readonly EmployeeSigningSystemContext _context;

        public TempBadgeController(EmployeeSigningSystemContext context)
        {
            _context = context;
        }

        // GET: TempBadge
        public async Task<IActionResult> Queue()
        {
              return View(await _context.EmployeeTempBadges.ToListAsync());
        }

        // GET: TempBadge/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.EmployeeTempBadges == null)
            {
                return NotFound();
            }

            var employeeTempBadge = await _context.EmployeeTempBadges
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeTempBadge == null)
            {
                return NotFound();
            }

            return View(employeeTempBadge);
        }

        // GET: TempBadge/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TempBadge/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeFirstName,EmployeeLastName,TempBadge,SignInT,SignOutT,AssignT")] EmployeeTempBadge employeeTempBadge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeTempBadge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeTempBadge);
        }

        // GET: TempBadge/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.EmployeeTempBadges == null)
            {
                return NotFound();
            }

            var employeeTempBadge = await _context.EmployeeTempBadges.FindAsync(id);
            if (employeeTempBadge == null)
            {
                return NotFound();
            }
            return View(employeeTempBadge);
        }

        // POST: TempBadge/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,EmployeeFirstName,EmployeeLastName,TempBadge,SignInT,SignOutT,AssignT")] EmployeeTempBadge employeeTempBadge)
        {
            if (id != employeeTempBadge.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeTempBadge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeTempBadgeExists(employeeTempBadge.Id))
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
            return View(employeeTempBadge);
        }

        // GET: TempBadge/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.EmployeeTempBadges == null)
            {
                return NotFound();
            }

            var employeeTempBadge = await _context.EmployeeTempBadges
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeTempBadge == null)
            {
                return NotFound();
            }

            return View(employeeTempBadge);
        }

        // POST: TempBadge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.EmployeeTempBadges == null)
            {
                return Problem("Entity set 'EmployeeSigningSystemContext.EmployeeTempBadges'  is null.");
            }
            var employeeTempBadge = await _context.EmployeeTempBadges.FindAsync(id);
            if (employeeTempBadge != null)
            {
                _context.EmployeeTempBadges.Remove(employeeTempBadge);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeTempBadgeExists(string id)
        {
          return _context.EmployeeTempBadges.Any(e => e.Id == id);
        }
    }
}
