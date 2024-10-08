﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailsDto
    {
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public double DailyPrice { get; set; }
        public int CarId { get; set; }
        public string Description { get; set; }
        public int ModelYear { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
    }
}
