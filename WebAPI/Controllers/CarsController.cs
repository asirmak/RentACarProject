using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Threading;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _carService.Delete(_carService.GetById(id).Data);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }

        [HttpGet("getalldetails")]
        public IActionResult GetAllCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }

        [HttpGet("getdetailsbycarid")]
        public IActionResult GetCarDetailsByCarId(int id)
        {
            var result = _carService.GetCarDetailsByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }

        [HttpGet("getalldetailsbybrandid")]
        public IActionResult GetAllCarDetailsByBrandId(int id)
        {
            var result = _carService.GetAllCarDetailsByBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }

        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }

        [HttpGet("getalldetailsbycolorid")]
        public IActionResult GetAllCarDetailsByColorId(int id)
        {
            var result = _carService.GetAllCarDetailsByColorId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }

        [HttpGet("getbycolorid")]
        public IActionResult GetByColorId(int id)
        {
            var result = _carService.GetCarsByColorId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }

        [HttpGet("getallcarsdetailsbyrentaldate")]
        public IActionResult GetAllCarsDetailByRentalDate(DateTime rentDate, DateTime returnDate)
        {
            var result = _carService.GetAllCarsDetailByRentalDate(rentDate, returnDate);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
    }
}
