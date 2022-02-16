using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));

            var result = productManager.GetProductDetails();
            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " / " + product.CategoryName);


                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            

            Console.WriteLine("*********************************");

            ProductManager productManager2 = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));

            foreach (var product in productManager.GetAllByCategoryId(2).Data)
            {
                Console.WriteLine(product.ProductName);
            }

            Console.WriteLine("***************************************");
            
            
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            var result2 = categoryManager.GetAll();

            if (result2.Success == true)
            {
                foreach (var category in result2.Data)
                {
                    Console.WriteLine(category.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result2.Message);
            }

           

        }
    }
}
