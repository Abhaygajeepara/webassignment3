using Microsoft.EntityFrameworkCore;
using web_assignment3.DatabaseContext;
using web_assignment3.Model;
using web_assignment3.Model.InputModel;

namespace web_assignment3.Controllers.CartController
{
    public class CartRepository : ICommonInterface
    {
        public CartRepository(MyDatabaseContext myDatabase)
        {
            dbContext = myDatabase;
        }

        public MyDatabaseContext dbContext { get; set; }

        public object AddElement(object _object)
        {
            Cart cartModel = new Cart();
            CartInputModel cartInputModel = _object as CartInputModel;
            cartModel.UserId = cartInputModel.userId;
            cartModel.productId = cartInputModel.productId;
            cartModel.quantity = cartInputModel.quantity;
            
            dbContext.Cart.Add(cartModel);
            dbContext.SaveChanges();
            return cartModel;

        }

        public async Task<Object> DeleteElement(int id)
        {
            var cartItem = await dbContext.Cart.FirstOrDefaultAsync(c => c.Id == id);

            if (cartItem != null)
            {
                dbContext.Cart.Remove(cartItem);
                await dbContext.SaveChangesAsync();
                return cartItem;
            }

            return null;
        }

        public Task<IEnumerable<object>> getAllElements()
        {
            throw new NotImplementedException();
        }

        public async Task<object> GetElementsById(int id)
        {
            return   await dbContext.Cart.Where(c => c.UserId == id).ToListAsync();
        }

        public Task<object> UpdateElement(int id, object _object)
        {
            throw new NotImplementedException();
        }
    }
}
