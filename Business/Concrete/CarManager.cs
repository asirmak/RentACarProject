using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Security;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IRentalService _rentalService;

        public CarManager(ICarDal carDal, IRentalService rentalService)
        {
            _carDal = carDal;
            _rentalService = rentalService;
        }

        [SecuredOperation("car.add, admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(b=> b.Id == carId), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(), Messages.CarsListed);
        }
        public IDataResult<List<CarDetailsDto>> GetCarDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(car => car.CarId == carId), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b=> b.BrandId == brandId), Messages.CarsListed);
        }

        public IDataResult<List<Car>>GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b=> b.ColorId == colorId), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailsDto>> GetAllCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(b => b.BrandId == brandId), Messages.CarsListed);
        }
        public IDataResult<List<CarDetailsDto>> GetAllCarDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(b => b.ColorId == colorId), Messages.CarsListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<CarDetailsDto>> GetAllCarsDetailByRentalDate(DateTime rentDate, DateTime returnDate)
        {
            List<int> carsInPeriod = _rentalService.GetAllByRentalDate(rentDate, returnDate).Data.Select(r=> r.CarId).Distinct().ToList();

            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(c=> !carsInPeriod.Contains(c.CarId)));
        }
    }
}
