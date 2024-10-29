using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Vladislav_API.Controllers
{
    public class Data
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Degree { get; set; }
        public string Location { get; set; }

    }
    [ApiController]
    [Route("[controller]")]
    public class ForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public  List<Data> weatherDatas = new()
        {
            new Data() {Id = 1, Date = "21.01.2022",Degree=10,Location="Мурманск" },
            new Data() {Id = 23, Date = "10.08.2019",Degree=-20,Location="Пермь" },
            new Data() {Id = 24, Date = "05.11.2020",Degree=15,Location="Омск" },
            new Data() {Id = 25, Date = "07.02.2021",Degree=0,Location="Томск" },
            new Data() {Id = 30, Date = "30.05.2022",Degree=3,Location="Калининград" },
        };

        private readonly ILogger<ForecastController> _logger;


        [HttpGet("GetAll")]
        public List<Data> GetAll()
        {
            return weatherDatas;//Возвращение всех записей списка
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            for (int i = 0; i < weatherDatas.Count; i++)//цикл,который обходит каждый элемент массива weatherDatas
            {
                if (weatherDatas[i].Id == id)//в случае, если id равны
                { 
                    return Ok(weatherDatas[i]);
                }    
            }
            return BadRequest("Такая запись не обнаружена");//Возвращение всех записей списка
        }

        [HttpPost]
        public IActionResult Add(Data data)
        {
            if (data.Id<0)
                return BadRequest("id-положительная величина");
            for (int i = 0; i < weatherDatas.Count; i++)//цикл,который обходит каждый элемент массива weatherDatas
            {
                if (weatherDatas[i].Id == data.Id)//в случае, если id равны
                {
                    return BadRequest("Запись с таким Id уже есть");
                }
            }
            weatherDatas.Add(data);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Data data)
        {
            if (data.Id < 0)
                return BadRequest("id-положительная величина");
            for (int i = 0; i < weatherDatas.Count; i++)//цикл,который обходит каждый элемент массива weatherDatas
            {
                if (weatherDatas[i].Id == data.Id)//в случае, если id равны
                {
                    weatherDatas[i] = data;
                    return Ok();    
                }
            }
            return BadRequest("Такая запись не обнаружена");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            for (int i = 0; i < weatherDatas.Count; i++)//цикл,который обходит каждый элемент массива weatherDatas
            {
                if (weatherDatas[i].Id == id)//в случае, если id равны
                {
                    weatherDatas.RemoveAt(i);
                    return Ok();
                }
            }
            return BadRequest("Такая запись не обнаружена");
        }

        [HttpGet("find-by-city")]
        public IActionResult GetByCityName(string location) 
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Location == location)
                {
                    return Ok("Запись с указанным городом имеется в нашем списке");
                }
            }
            return Ok("Запись с указанным городом не обнаружено");
        }
        //********************************************************************
        
    }

}
