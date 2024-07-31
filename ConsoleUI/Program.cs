using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.BrandName + " " + item.CarName +
                    " " + item.ColorName + " " + item.DailyPrice);
                }
            }

        }
    }
}
