using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Entityframework;
using Entities;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProductDal productDal = new EfProductDal();
            IProductService productManager = new ProductManager(productDal);

            var result = productManager.GetAll();
            if (result.Success)
            {
                foreach (Product product in result.Data)
                {
                    Console.WriteLine("{0} : {1}, {2}", product.ProductId, product.ProductName, product.UnitPrice);
                }
                Console.WriteLine("GetAllSuccess: {0}", result.Message);
            }
            else 
            {
                Console.WriteLine("GetAllError: {0}", result.Message);
            }
        }
    }
}