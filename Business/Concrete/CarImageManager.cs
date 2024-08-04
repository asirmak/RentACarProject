using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.ImageHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImageDtoAdd carImageDto)
        {
            IResult result = BusinessRules.Run(CheckIfNumberOfCarImagesExceeded(carImageDto));
            if (result != null)
            {
               return result;
            }
            CarImage carImage = new CarImage();
            carImage.CarId = carImageDto.CarId;
            carImage.Date = DateTime.Now;
            carImage.ImagePath = ImageHelper.AddImageToPath(carImageDto.Image, GlobalVariables.FilePath);

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        private IResult CheckIfNumberOfCarImagesExceeded(CarImageDtoAdd carImageDto)
        {
            if (_carImageDal.GetAll(i => i.CarId == carImageDto.CarId).Count > 5)
            {
                return new ErrorResult(Messages.ImageNumberExceeded);
            }
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            ImageHelper.DeleteImageFromPath(carImage.ImagePath);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ImagesListed);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>
                (_carImageDal.Get(i=>i.Id == carImageId), Messages.ImagesListed);
        }

        public IResult Update(CarImageDtoUpdate carImageDto)
        {
            CarImage carImage = new CarImage();
            carImage.Id = carImageDto.Id;
            carImage.CarId = carImageDto.CarId;
            carImage.Date = DateTime.Now;
            ImageHelper.DeleteImageFromPath(carImage.ImagePath);
            carImage.ImagePath = ImageHelper.AddImageToPath(carImageDto.Image, GlobalVariables.FilePath);

            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.ImageUpdated);
        }
    }
}
