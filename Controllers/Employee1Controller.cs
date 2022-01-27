using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalureProject2.Context;
using WalureProject2.Models;

namespace WalureProject2.Controllers
{
    public class Employee1Controller : Controller
    {
        private readonly Employee1DBContext _context;

        public Employee1Controller(Employee1DBContext context)
        {
            _context = context;
        }
        // GET: Employee1Controller
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.ToListAsync();
            return View(employees);
        }
         [HttpGet]
        // Search
        // GET: Employee1Controller
        public IActionResult ShowSearchForm()
        {
            
            return View();
        }
        // POST
        [HttpPost]
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
           
            return View("Index",await _context.Employees.Where(j=>j.Name.Contains(SearchPhrase)).ToListAsync());

           
        }

        //AddOrEdit Get Method
        [HttpGet]
        //public async Task<IActionResult> AddOrEdit(int? Id)

        public IActionResult Create()
        {
            return View();
        }



        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employeees)
        {
            employeees.Date = DateTime.Now;
            _context.Employees.Add(employeees);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Employees/Delete/1
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == Id);

            return View(employee);
        }

        // POST: Employees/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {
            var employee = await _context.Employees.FindAsync(Id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Employee Details
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == Id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }


        [HttpGet]
        // GET Update
        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _context.Employees.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employees)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(employees);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employees);








             
        }
    }
}