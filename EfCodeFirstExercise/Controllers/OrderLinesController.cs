using EfCodeFirstExercise.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstExercise.Controllers
{
    public class OrderLinesController
    {
        private /*readonly*/ AppDbContext _context = null;
        private async Task CalculateOrderTotal(int orderId)
        {
            _context = new AppDbContext();
            var order = await _context.Orders.FindAsync(orderId); // reading the order
            if (order == null) throw new Exception("Order not found for calculation"); // making sure the order exists
            var orderLines = await _context.OrderLines.Where(ol => ol.OrderId == orderId).ToListAsync();

            decimal total = 0;
            foreach(var line in orderLines)
            {
                total += line.Quantity * line.Product.Price;
            }
            order.Total = total;
            await _context.SaveChangesAsync();
        }

        public async Task<OrderLine> Get(int id)
        {
            return await _context.OrderLines.FindAsync(id);
        }

        public async Task<OrderLine> Create(OrderLine orderLine)
        {
            if (orderLine == null) throw new Exception("OrderLine cannot be null");

            await _context.OrderLines.AddAsync(orderLine);
            await _context.SaveChangesAsync();
            await CalculateOrderTotal(orderLine.OrderId);
            
            return orderLine; // we return the same data we passed in to
        }

        public async Task Update(int id, OrderLine orderLine)
        {
            if (orderLine == null) throw new Exception("OrderLine cannot be null");
            if (id != orderLine.Id) throw new Exception("OrderLine not found");

            _context.Entry(orderLine).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            await CalculateOrderTotal(orderLine.OrderId);
        }

        public async Task Delete( OrderLine orderLine)
        {
            if (orderLine == null) throw new Exception("Orderline cannot be null");
            _context.OrderLines.Remove(orderLine);
            await _context.SaveChangesAsync();
        }

        public async Task Delete (int id)
        {
            var ordLine = Get(id);
            if (ordLine == null) throw new Exception("OrderLine does not exist");
            await Delete(ordLine.Result);
        }


        public OrderLinesController()
        {
            _context = new AppDbContext();
        }
    }
}
