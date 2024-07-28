using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemoryDal
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> cars;

        public InMemoryCarDal()
        {
            cars = new List<Car>()
            {
                new Car{Id = 1, BrandId = 1, ColorId =1, DailyPrice = 1000, Description = "Uygun", ModelYear=2022},
                new Car{Id = 2, BrandId = 1, ColorId =1, DailyPrice = 1500, Description = "Uygun Degil", ModelYear=2018},
                new Car{Id = 3, BrandId = 1, ColorId =1, DailyPrice = 1700, Description = "Uygun", ModelYear=2021},
                new Car{Id = 4, BrandId = 2, ColorId =1, DailyPrice = 1800, Description = "Uygun", ModelYear=2019},
                new Car{Id = 5, BrandId = 2, ColorId =1, DailyPrice = 2200, Description = "Uygun Degil", ModelYear=2024},

            };
        }

        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(int carId)
        {
            Car carToDelete = cars.SingleOrDefault(c => c.Id == carId);
            cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public Car GetById(int carId)
        {
            return cars.SingleOrDefault(c => c.Id == carId);
        }

        public void Update(Car car)
        {
            Car carToUpdate = cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
