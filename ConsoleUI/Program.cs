using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemoryDal;
using Entities.Concrete;
using System;
using System.ComponentModel;
using System.Linq;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.Add(new Rental() { Id = 2, CarId = 1, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = null });

            Console.WriteLine(result.Success + " " + result.Message);

            /*
            if (result.Success)
            {
                Console.WriteLine(result.Message);
                foreach (var item in result.Data)
                {
                    Console.WriteLine(result.FirstName + " " + result.LastName);
                }
            }*/

            //var result = carManager.GetCarDetails();

            //if (result.Success == true)
            //{
            //    Console.WriteLine(result.Message);
            //    foreach (var item in result.Data)
            //    {
            //        Console.WriteLine(item.BrandName + " " + item.CarName +
            //        " " + item.ColorName + " " + item.DailyPrice);
            //    }
            //}

        }
    }
}
