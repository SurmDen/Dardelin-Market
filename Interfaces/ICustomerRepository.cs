using DardelinMarket.Data;

namespace DardelinMarket.Interfaces
{
    public interface ICustomerRepository
    {
        public IEnumerable<Customer> GetAllCustomers();

        public bool CreateCustomer(Customer customer);

        public void UpdateCustomer(Customer customer);

        public void DeleteCustomer(long customerId);

        public Customer GetCustomerById(long id);

        public Customer GetCustomerByNameAndEmail(string name, string email);

        public Customer GetCustomerByNameAndPassword(string name, string password);

        public IEnumerable<IpDataModel> GetIpDataModels();

        public void AddIpDataModel(string ip, string date , string city, long dick);
    }
}
