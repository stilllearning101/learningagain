using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Collections.Generic;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductsRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Products> Products
        {
            get { return context.Products; }
        }
        public void SaveProduct(Products product)
        {
            if (product.ProductID == null)
            {
                context.Products.Add(product);
            }
            else
            {
                Products dbEntry = context.Products.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            context.SaveChanges(); // adds product to the repository if the product ID is 0. 
            // otherwise it applies changes to the existing entry in the database.
            // because of the if and else statement in above.
        }
        public Products DeleteProduct(int? productID)
        {
            Products dbEntry = context.Products.Find(productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
/*I know I need to perform an update when I receive a Product parameter that has a ProductID that is not zero. I do
this by getting a Product object from the repository with the same ProductID and updating each of the properties so
they match the parameter object.
I can do this because the Entity Framework keeps track of the objects that it creates from the database. The
object passed to the SaveChanges method is created by the MVC Framework using the default model binder, which
means that the Entity Framework does not know anything about the parameter object and will not apply an update
to the database. There are lots of ways of resolving this issue and I have taken the simplest one, which is to locate the
corresponding object that the Entity Framework does know about and update it explicitly.
An alternative approach would be to create a custom model binder that only obtains objects from the repository.
This may seem like a more elegant approach, but it would require me to add a find capability to the repository
interface so I could locate Product objects by ProductID values.
 */
