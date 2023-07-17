using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_assignment3.DatabaseContext;
using web_assignment3.Model;

namespace web_assignment3.Controllers.UserController
{
    public class UserRepository : ICommonInterface
    {
       
        public MyDatabaseContext dbContext { get; set; }

        public UserRepository(MyDatabaseContext databaseContext)
        {
            dbContext = databaseContext;
        }
        public object AddElement(object _object)
        {
            User userModel = new User();
            UserInputModel userInputModel = _object as UserInputModel;
            userModel.username = userInputModel.username;
            userModel.email = userInputModel.email;
            userModel.password = userInputModel.password;
            userModel.shippingAddress = userInputModel.shippingAddress;
            dbContext.Users.Add(userModel);
            dbContext.SaveChanges();
            return userModel;
        }

        public Task<Object> DeleteElement(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<object>> getAllElements()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<Object> GetElementsById(int id)
        {
            var result = await dbContext.Users.FirstOrDefaultAsync(e => e.Id == id);

            return result;
        }

        public async Task<Object> UpdateElement([FromForm] int id,object _object)
        {
            var result = await dbContext.Users.FirstOrDefaultAsync(e => e.Id == id);
            UserInputModel? userInputModel = _object as UserInputModel;
            if (result != null)
            {
                if (userInputModel.username.Length > 0)
                    result.username = userInputModel.username;
                if (userInputModel.email.Length > 0)
                    result.email = userInputModel.email;
                if (userInputModel.password.Length > 0)
                    result.password = userInputModel.password;
                if (userInputModel.shippingAddress.Length > 0)
                    result.shippingAddress = userInputModel.shippingAddress;

                await dbContext.SaveChangesAsync();
                return result;
            }


            return null;
        }
    }
}
