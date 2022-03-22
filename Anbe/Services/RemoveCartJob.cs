using Anbe.Data;
using Anbe.Models;
using Microsoft.EntityFrameworkCore;
using Quartz;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Anbe
{
    [DisallowConcurrentExecution]
    public class RemoveCartJob : IJob
    {

        public Task Execute(IJobExecutionContext context)
        {
            var option = new DbContextOptionsBuilder<AnbeContext>();
            option.UseSqlServer(@"Server=.;Database=Nazar1988Product;Trusted_Connection=True;MultipleActiveResultSets=true");

            using (AnbeContext _ctx = new AnbeContext(option.Options))
            {
                var orders = _ctx.Orders.Where(o => !o.IsFinaly && o.CreateDate < DateTime.Now.AddHours(-24)).ToList();
                foreach (var order in orders)
                {
                    var orderDetail = _ctx.OrderDetails.Where(od => od.OrderId == order.OrderId).ToList();

                    foreach (var detail in orderDetail)
                    {
                        var Product = _ctx.Products.Find(detail.ProductId);
                        Product.ProductTotal += detail.Count;
                        _ctx.Products.Update(Product);
                    }
                    _ctx.Remove(order);
                }

                _ctx.SaveChanges();
            }
            return Task.CompletedTask;
        }
    }
}
