using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DemoCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private const int PageSize = 20;

        [HttpGet("all")] // attributed routing
        public ActionResult<IEnumerable<string>> Get()
        {
            return Names.PopularNames;
        }

        [ResponseCache(Duration = 60)]
        [HttpGet("{page}")] // attributed routing
        public ActionResult<IEnumerable<string>> Get(int page)
        {
            return Names.PopularNames.Skip((page - 1) * PageSize).Take(PageSize).ToList();
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
            if (Names.PopularNames.Contains(value))
                return;

            Names.PopularNames.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Names.PopularNames.RemoveAt(id);
            Names.PopularNames.Insert(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Names.PopularNames.RemoveAt(id);
        }
    }
}