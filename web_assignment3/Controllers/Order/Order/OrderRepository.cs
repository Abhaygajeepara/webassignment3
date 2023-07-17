using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using web_assignment3.DatabaseContext;
using web_assignment3.Model;
using web_assignment3.Model.InputModel;

namespace web_assignment3.Controllers.Order
{
    public class OrderRepository:ICommonInterface
    {
        public  MyDatabaseContext dbContext { get; set; }
        public OrderRepository(MyDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public object AddElement(object _object)
        {
            OrderInputModel orderInput = _object as OrderInputModel;
            int userId = orderInput.UserId;
            decimal totalAmount = orderInput.TotalAmount;
            string shippingAddress = orderInput.ShippingAddress;
            List<string> items = JsonSerializer.Deserialize<List<string>>(orderInput.Items);

            OrderModel newOrder = new OrderModel
            {
                UserId = userId,
                TotalAmount = totalAmount,
                ShippingAddress = shippingAddress,
                OrderDate = DateTime.UtcNow,
            };

            dbContext.Orders.Add(newOrder);
            dbContext.SaveChanges();

            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (string itemName in items)
            {
                OrderItem newOrderItem = new OrderItem
                {
                    OrderId = newOrder.OrderId,
                    ItemName = itemName
                };

                orderItems.Add(newOrderItem);
                dbContext.OrderItems.Add(newOrderItem);
            }

            dbContext.SaveChanges();

            FullOrderModel fullOrderModel = new FullOrderModel
            {
                order = newOrder,
                items = orderItems,
            };

            return fullOrderModel;
        }

        public Task<object> DeleteElement(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<object>> getAllElements()
        {
            throw new NotImplementedException();
        }

        public async Task<object> GetElementsById(int id)
        {
            
            var order= await dbContext.Orders.FirstOrDefaultAsync(c => c.OrderId == id);
            var itemList = await dbContext.OrderItems.Where(c => c.OrderId == id).ToListAsync();

            if(order != null && itemList != null) {
                var fullOrder = new
                {
                    Order = order,
                    Items = itemList
                };

                return fullOrder;
            }
            return null;
        }

        public Task<object> UpdateElement(int id, object _object)
        {
            throw new NotImplementedException();
        }
    }
}
