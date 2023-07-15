using Microsoft.AspNetCore.Mvc;
using web_assignment3.DatabaseContext;



    public interface ICommonInterface
    {
      MyDatabaseContext dbContext { get; set; }
    Task<IEnumerable<Object>> getAllElements();
        Task<Object> GetElementsById(int id);
        Object AddElement(Object _object);
        Task<Object> UpdateElement(int id,Object _object);
        Task<Object> DeleteElement(int id);
    }

