using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> GetById(int carId);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<List<CarDetailsDto>> GetCarDetailsByCarId(int carId);
        IDataResult<List<CarDetailsDto>> GetAllCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailsDto>> GetAllCarDetailsByColorId(int colorId);
        IDataResult<List<CarDetailsDto>> GetAllCarsDetailByRentalDate(DateTime rentDate, DateTime returnDate);

    }
}
