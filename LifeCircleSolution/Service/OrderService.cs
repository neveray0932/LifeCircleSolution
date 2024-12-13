namespace LifeCircleSolution.Service
{
    public class OrderService : IScopeOrderService, ITransientOrderService, ISingletonOrderService
    {
        private readonly string _id;

        public OrderService()
        {
            _id = Guid.NewGuid().ToString();
        }

        public string GetId()
        {
            return _id;
        }
    }
}
