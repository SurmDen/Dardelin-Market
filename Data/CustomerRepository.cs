using DardelinMarket.Infrastructure;
using DardelinMarket.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DardelinMarket.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private DataContext context;

        public CustomerRepository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            IEnumerable<Customer> customers = context.Customers.Include(c => c.Orders).ThenInclude(o => o.OrderModels);

            if (customers.Count()!= 0)
            {
                foreach (Customer c in customers)
                {
                    if (c.Orders != null)
                    {
                        foreach (Order order in c.Orders)
                        {
                            order.Customer = null;

                            if (order.OrderModels.Count() != 0)
                            {
                                foreach (OrderModel orderModel in order.OrderModels)
                                {
                                    orderModel.Order = null;
                                }
                            }
                        }
                    }
                }
            }

            return customers;
        }


        public bool CreateCustomer(Customer customer)
        {
            customer.Password = PasswordHesher.GenerateHesh(customer.Password);

            customer.Role = "User";

            foreach (var cus in context.Customers)
            {
                if (cus.Password == customer.Password || cus.Email == customer.Email)
                {
                    return false;
                }
            }

            customer.Busket = new Busket();

            context.Customers.Add(customer);

            context.SaveChanges();

            return true;
        }

        public void DeleteCustomer(long customerId)
        {
            Customer customer = context.Customers.First(c => c.Id == customerId);

            context.Customers.Remove(customer);

            context.SaveChanges();
        }

        public Customer GetCustomerById(long id)
        {
            Customer customer = context.Customers.Include(c=>c.Orders).First(c => c.Id == id);

            return customer;
        }

        public Customer GetCustomerByNameAndEmail(string name, string email)
        {
            Customer customer = context.Customers.
                Include(c => c.Orders).
                Include(c => c.Busket).
                ThenInclude(b => b.BusketModels).
                First(c => c.Name == name && c.Email == email);

            return customer;
        }

        public Customer GetCustomerByNameAndPassword(string name, string password)
        {
            try
            {
                Customer customer = context.Customers.Include(c => c.Orders).
                First(c => c.Name == name && c.Password == PasswordHesher.GenerateHesh(password));

                foreach (var order in customer.Orders)
                {
                    order.Customer = null;
                }

                return customer;
            }
            catch
            {
                return null;
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            if (!string.IsNullOrEmpty(customer.Password))
            {
                customer.Password = PasswordHesher.GenerateHesh(customer.Password);
            }

            context.Customers.Update(customer);

            context.SaveChanges();
        }

        public IEnumerable<IpDataModel> GetIpDataModels()
        {
            return context.IpDataModels;
        }

        public void AddIpDataModel(string ip, string date, string city, long dick)
        {
            IEnumerable<IpDataModel> ipDataModels = context.IpDataModels;

            if (ipDataModels.Count() != 0)
            {
                foreach (var ipData in ipDataModels)
                {
                    if (ipData.IpAddress == ip)
                    {
                        ipData.Count++;

                        ipData.Time = date;

                        if (ipData.City == "underfind")
                        {
                            ipData.City = city;
                        }

                        context.IpDataModels.Update(ipData);

                        context.SaveChanges();

                        return;
                    }
                }
            }

            IpDataModel dataModel = new IpDataModel()
            {
                IpAddress = ip,

                Time = date,

                City = city,

                Dick_Lendth = dick,

                Count = 1
            };

            context.IpDataModels.Add(dataModel);

            context.SaveChanges();
        }
    }
}
