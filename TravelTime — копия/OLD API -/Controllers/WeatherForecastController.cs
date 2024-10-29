using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Reflection;
using System.Xml.Linq;

namespace Vladislav_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly List<string> Summaries = new()
        {
            "2", "3", "1", "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<string> Get()
        {
            return Summaries;
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            if (string.IsNullOrEmpty(name))// есть встроенная проверка на пустое значение и на ( )
            {
                return BadRequest("Ошибка! Пустое имя.");
            }
            else
            {
                Summaries.Add(name);
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Ошибка! Индекс неверный.");
            }
            else
            {
                if (string.IsNullOrEmpty(name))// есть встроенная проверка на пустое значение и на ( )
                {
                    return BadRequest("Ошибка! Пустое имя.");
                }
                else
                {
                    Summaries[index] = name;
                    return Ok();
                }
            }
        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Ошибка! Индекс неверный.");
            }
            else
            {
                Summaries.RemoveAt(index);
                return Ok();
            }
        }
        [HttpGet("{index}")]
        public string Get(int index)
        {
            return Summaries[index];
        }

        [HttpGet("find-bi-name")]
        public int Get(string name)
        {
            return Summaries.Count(x=> x==name);
        }

        [HttpGet("1")]
        public IActionResult GetAll(int? sortStrategy = null)
        {

            var temp = new List<string>(Summaries);
            switch (sortStrategy)
            {
                case null:
                    return Ok(temp);
                case 1:
                    temp.Sort();
                    return Ok(temp);
                case -1:
                    temp.Sort();
                    temp.Reverse();
                    return Ok(temp);
            }
             return BadRequest("Некорректное значение параметра sortStrategy");
        }

      
    }
}
