using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService 
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
        IDataResult<CarImage> GetById(int carImageId);
        IResult Add(CarImageDtoAdd carImageDto);
        IResult Update(CarImageDtoUpdate carImageDto);
        IResult Delete(CarImage carImage);
    }
}
