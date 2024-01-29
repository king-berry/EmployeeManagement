using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Data;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class Employee_TblController : Controller
    {
        private readonly EmployeeManagementContext _context;

        public Employee_TblController(EmployeeManagementContext context)
        {
            _context = context;
        }

        // GET: Employee_Tbl
        public async Task<IActionResult> Index()
        {
            var employeeManagementContext = _context.Employee_Tbl.Include(e => e.Department);
            return View(await employeeManagementContext.ToListAsync());
        }

        // GET: Employee_Tbl/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee_Tbl = await _context.Employee_Tbl
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee_Tbl == null)
            {
                return NotFound();
            }

            return View(employee_Tbl);
        }

        // GET: Employee_Tbl/Create
        public IActionResult Create()
        {
            ViewData["DepartmentID"] = new SelectList(_context.Set<Department_Tbl>(), "Id", "Id");
            return View();
        }

        // POST: Employee_Tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeName,EmployeeCode,rank,DepartmentID")] Employee_Tbl employee_Tbl)
        {
            if (true)
            {
                _context.Add(employee_Tbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentID"] = new SelectList(_context.Set<Department_Tbl>(), "Id", "Id", employee_Tbl.DepartmentID);
            return View(employee_Tbl);
        }

        // GET: Employee_Tbl/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee_Tbl = await _context.Employee_Tbl.FindAsync(id);
            if (employee_Tbl == null)
            {
                return NotFound();
            }
            ViewData["DepartmentID"] = new SelectList(_context.Set<Department_Tbl>(), "Id", "Id", employee_Tbl.DepartmentID);
            return View(employee_Tbl);
        }

        // POST: Employee_Tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeName,EmployeeCode,rank,DepartmentID")] Employee_Tbl employee_Tbl)
        {
            if (id != employee_Tbl.Id)
            {
                return NotFound();
            }

            if (true)
            {
                try
                {
                    _context.Update(employee_Tbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Employee_TblExists(employee_Tbl.Id))
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
            ViewData["DepartmentID"] = new SelectList(_context.Set<Department_Tbl>(), "Id", "Id", employee_Tbl.DepartmentID);
            return View(employee_Tbl);
        }

        // GET: Employee_Tbl/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee_Tbl = await _context.Employee_Tbl
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee_Tbl == null)
            {
                return NotFound();
            }

            return View(employee_Tbl);
        }

        // POST: Employee_Tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee_Tbl = await _context.Employee_Tbl.FindAsync(id);
            if (employee_Tbl != null)
            {
                _context.Employee_Tbl.Remove(employee_Tbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Employee_TblExists(int id)
        {
            return _context.Employee_Tbl.Any(e => e.Id == id);
        }
    }
}
