using System.Text.Json;
using API.Application.Repositories;
using API.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace API.Controllers
{
    public class HomeController : ControllerBase {
        private readonly IDataService _dataService;

        public HomeController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost("save")]
        public IActionResult SaveData(Data inputData)
        {
            _dataService.SaveData(inputData);
            return Ok("Data saved successfully.");
        }

        [HttpGet("read")]
        public IActionResult ReadData()
        {
            var dataList = _dataService.ReadData();
            return Ok(dataList);
        }
    }
    
}

