﻿using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailsDto
                             {
                                 CarId = c.Id,
                                 CarName = c.Name,
                                 BrandName = b.BrandName,
                                 BrandId = b.Id,
                                 ColorName = co.ColorName,
                                 ColorId = co.Id,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear
                             };

                return filter == null
                ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
