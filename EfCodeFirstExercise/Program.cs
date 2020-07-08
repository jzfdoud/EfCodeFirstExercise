using EfCodeFirstExercise.Controllers;
using EfCodeFirstExercise.Models;
using System;
using System.Threading.Tasks;

namespace EfCodeFirstExercise
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await TestOrder();
        }

        static async Task TestCustomer()
        {
            var custCtrl = new CustomersController();

            //var cust = new Customer()
            //{
            //    Id = 0,
            //    IsNationalAccount = false,
            //    Name = "Max Technical",
            //    State = "OH",
            //    TotalSales = 1000
            //};
            //cust = await custCtrl.Create(cust);

            //var customers = await custCtrl.GetAll();

            //var cust2 = await custCtrl.Get(2);

            await custCtrl.Remove(2);

        }

        static async Task TestProduct()
        {
            var prodCtrl = new ProductsController();
            var prod = new Product()
            {
                Id = 0,
                Name = "Echo Show 5",
                Price = 129.99m,
                InStock = true
            };

            //prod = await prodCtrl


        }

        static async Task TestOrder()
        {
            var ordCtrl = new OrdersController();
            var orders = await ordCtrl.GetAll();
        }
    }
}
//quantity is in orderline props. pk, 2 fk(order, product), quantity