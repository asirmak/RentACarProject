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


            //Car car1 = new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 1000, Description = "Uygun", ModelYear = 2022 };
            //Car car2 = new Car { Id = 2, Name = "Talisman", BrandId = 1, ColorId = 1, DailyPrice = 1500, Description = "Uygun Degil", ModelYear = 2018 };
            //Car car3 = new Car { Id = 3, Name = "Kangoo", BrandId = 1, ColorId = 1, DailyPrice = 1700, Description = "Uygun", ModelYear = 2021 };
            //Car car4 = new Car { Id = 4, Name = "A4", BrandId = 2, ColorId = 1, DailyPrice = 1800, Description = "Uygun", ModelYear = 2019 };
            //Car car5 = new Car { Id = 5, Name = "RS6", BrandId = 2, ColorId = 1, DailyPrice = 2200, Description = "Uygun Degil", ModelYear = 2024 };

            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine(item.Name);
            //}

            //foreach (var item in brandManager.GetAll())
            //{
            //    Console.WriteLine(item.BrandName);
            //}

            //foreach (var item in colorManager.GetAll())
            //{
            //    Console.WriteLine(item.ColorName);
            //}

            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.BrandName + " " + item.CarName +
                    " " + item.ColorName + " " + item.DailyPrice);
            }


        }
    }
}
