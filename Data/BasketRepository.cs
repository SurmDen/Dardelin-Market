using DardelinMarket.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DardelinMarket.Data
{
    public class BasketRepository : IBasketRepository
    {
        public BasketRepository(DataContext context)
        {
            this.context = context;
        }

        private DataContext context;

        public void AddProductToBasket(BusketModel model, long custId, bool isPlus)
        {
            Busket busket = context.Buskets.Include(b => b.BusketModels).First(b => b.CustomerId == custId);

            Console.WriteLine(busket.BusketModels.Count()+"  is count of busket models!!!!!!!!");

            bool ifExists = false;

            if (busket.BusketModels.Count() != 0)
            {
                foreach (var b in busket.BusketModels)
                {
                    if (b.ProdId == model.ProdId)
                    {
                        if (isPlus)
                        {
                            b.Count++;
                        }
                        else
                        {
                            b.Count--;
                        }

                        context.BusketModels.Update(b);

                        context.SaveChanges();

                        ifExists = true;
                    }
                }
            }

            if (!ifExists)
            {
                model.Count = 1;

                model.Busket = busket;

                context.BusketModels.Add(model);

                context.SaveChanges();
            }
        }

        public bool CreateOrder(long custId)
        {
            Customer customer = context.Customers.Include(c => c.Orders).First(c => c.Id == custId);

            Busket busket = context.Buskets.Include(b => b.BusketModels).First(b => b.CustomerId == custId);

            Order order = new Order();



            if (busket.BusketModels.Count() != 0)
            {
                order.Customer = customer;

                context.Orders.Add(order);

                foreach (var m in busket.BusketModels)
                {
                    OrderModel model = new OrderModel()
                    {
                        Order = order,

                        ProdId = m.ProdId,

                        Count = m.Count
                    };

                    context.OrderModels.Add(model);

                }

                context.SaveChanges();

                context.RemoveRange(busket.BusketModels);

                context.SaveChanges();

                return true;
            }

            return false;
        }

        public void DeleteProductFromBasket(long prodId, long custId)
        {
            Busket busket = context.Buskets.Include(b => b.BusketModels).First(b => b.CustomerId == custId);

            BusketModel model = busket.BusketModels.First(bm =>bm.ProdId == prodId);

            context.BusketModels.Remove(model);

            context.SaveChanges();
        }

        public void ShipOrder(long orderId)
        {
            Order order = context.Orders.First(o => o.Id == orderId);

            if (order.IsShipped == false)
            {
                order.IsShipped = true;

                context.Orders.Update(order);

                context.SaveChanges();
            }
        }
    }
}
