using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarImageDtoUpdate
    {
        public int Id { get; set; }
        public IFormFile Image { get; set; }
        public int CarId { get; set; }
    }
}
