using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Library.Service;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        IIssueService _issueService;
        public IssueController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/Issue/IssueBook
        [HttpPost("/api/Issue/IssueBook")]
        public void IssueBook([FromBody]string[] value)
        {
            _issueService.BookIssue(value);
        }

        // PUT api/Issue/ReturnBook
        [HttpPut("/api/Issue/ReturnBook")]
        public void ReturnBook(int id, [FromBody] string[] value)
        {
            _issueService.BookReturn(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
