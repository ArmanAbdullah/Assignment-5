using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Library.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        [HttpPost("/api/Report/checkFine")]
        public float checkFine([FromBody]int id)
        {

            float fine = _reportService.checkFine(id);
            return fine;
        }
        [HttpPost("/api/Report/payFine")]
        public void payFine([FromBody]string[] id)
        {

            _reportService.payFine(id);

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
