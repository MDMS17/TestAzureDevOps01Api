using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TestAzureDevOps01Api.Controllers
{
    [Route("api/[controller]")]
    public class VoteDataController : ControllerBase
    {

        public VoteDataController()
        {
        }

        // GET api/VoteData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tuple<string, int>>>> Get()
        {
            List<Tuple<string, int>> result = new List<Tuple<string, int>>();

            foreach (var item in GlobalVariables.votes) result.Add(Tuple.Create(item.Key, item.Value));
            return result;
        }

        // PUT api/VoteData
        [HttpPut("{name:alpha}")]
        public async Task<IActionResult> Put(string name)
        {
            GlobalVariables.votes.AddOrUpdate(name, 1, (k, v) => v + 1);

            return new OkResult();
        }

        // DELETE api/VoteData/name
        [HttpDelete("{name:alpha}")]
        public async Task<IActionResult> Delete(string name)
        {
            int removedValue = 0;
            GlobalVariables.votes.TryRemove(name, out removedValue);
            if (removedValue == 0) return new NotFoundResult();
            else return new OkResult();
        }
    }
}
