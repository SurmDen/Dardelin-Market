using DardelinMarket.Data;

namespace DardelinMarket.Interfaces
{
    public interface IBasketRepository
    {
        public void AddProductToBasket(BusketModel model, long custId, bool isPlus);

        public void DeleteProductFromBasket(long prodId, long custId);

        public bool CreateOrder(long custId);

        public void ShipOrder(long orderId);
    }
}
