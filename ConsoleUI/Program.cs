using Business.Concrete;
using DataAccess.Concrete.InMemoryDal;
using Entities.Concrete;
using System;
using System.ComponentModel;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Car car1 = new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 1000, Description = "Uygun", ModelYear = 1999 };

            carManager.Update(car1);
            
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.ModelYear);
            }
            
            
        }
    }
}
