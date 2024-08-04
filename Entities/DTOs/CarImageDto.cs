using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarImageDtoAdd
    {
        public IFormFile Image { get; set; }
        public int CarId { get; set; }
    }
}
