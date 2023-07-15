using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_assignment3.DatabaseContext;
using web_assignment3.Model;

namespace web_assignment3.Controllers.ProductController
{
    public class ProductRepository : ICommonInterface
    {
     public   MyDatabaseContext dbContext { get ; set ; }
        public ProductRepository(MyDatabaseContext databaseContext) {
        
            dbContext = databaseContext ;   
        }
        public object AddElement(object _object)
        {
            Product productModel = new Product();
            ProductInputModel productInputModel =  _object as ProductInputModel;
            productModel.description = productInputModel.description;
            productModel.image = productInputModel.image;
            productModel.pricing = productInputModel.pricing;
            productModel.shippingCost = productInputModel.shippingCost;


            dbContext.Products.Add(productModel);
            dbContext.SaveChanges();
            return productModel;
        }

        public Task<Object> DeleteElement(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<object>> getAllElements()
        {
               return await dbContext.Products.ToListAsync();
        }

        public async Task<object> GetElementsById(int id)
        {
            var result = await dbContext.Products.FirstOrDefaultAsync(e => e.Id == id);

            return result;
        }

        public async Task<Object> UpdateElement(int id, object _object )
        {
            var result = await dbContext.Products.FirstOrDefaultAsync(e => e.Id == id);
            ProductInputModel productInputModel = _object as ProductInputModel;
            if (result != null)
            {
                if (productInputModel.description.Length > 0)
                    result.description = productInputModel.description;
                if (productInputModel.image.Length > 0)
                    result.image = productInputModel.image;
                if (((long)productInputModel.pricing) > 0)
                    result.pricing = productInputModel.pricing;
                if (((long)productInputModel.shippingCost) > 0)
                    result.shippingCost = productInputModel.shippingCost;
                await dbContext.SaveChangesAsync();
                return result;
            }


            return null;
        }
    }
}
