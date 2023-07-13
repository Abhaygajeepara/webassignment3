using Microsoft.AspNetCore.Mvc;
using web_assignment3.DatabaseContext;



    public interface ICommonInterface
    {
      MyDatabaseContext dbContext { get; set; }
    Task<IEnumerable<Object>> getAllElements();
        Task<ActionResult> GetElementsById(int id);
        Task<ActionResult> AddElement(Object _object);
        Task<ActionResult> UpdateElement(Object _object);
        void DeleteElement(int id);
    }

