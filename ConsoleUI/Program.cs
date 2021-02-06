using System;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            {
                foreach (var category  in categoryManager.GetAll())
                {
                    Console.WriteLine(category.CategoryName);
                }
                
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetAll())

            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
    

    
    

