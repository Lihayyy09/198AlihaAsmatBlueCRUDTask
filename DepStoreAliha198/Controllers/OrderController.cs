using DepStoreAliha198.Data;
using DepStoreAliha198.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepStoreAliha198.Controllers
{
    public class OrderController : Controller
    {
        StoreDB _data;
        public OrderController(StoreDB data)
        {
            _data = data;

        }
        public IActionResult ViewOrder()
        {

            return View(_data.Orders.ToList());
        }
        public IActionResult CreateOrder()
        {
            return View("CreateOder");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateOrder(OrderModel order)
        {
            if (ModelState.IsValid)
            {
               _data.Orders.Add(order);
                await _data.SaveChangesAsync();
                return RedirectToAction("ViewOrder");
            }

            return View("CreateOder",order);
        }
        
        public async Task<IActionResult> DeleteOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _data.Orders
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OrderModel order = await _data.Orders.FindAsync(id);
            _data.Orders.Remove(order);
            await _data.SaveChangesAsync();
            return RedirectToAction("ViewOrder");
        }

        private bool OrderExists(int id)
        {
            return _data.Orders.Any(e => e.ID == id);
        }
    }
}
