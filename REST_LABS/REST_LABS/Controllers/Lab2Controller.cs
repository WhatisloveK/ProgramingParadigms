using Microsoft.AspNetCore.Mvc;
using REST_LABS_BLL.Interfaces;
using REST_LABS_BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_LABS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lab2Controller: Controller
    {
        private ITask2_BL _helper;
        private static Dictionary<string, string> _keyResults = new Dictionary<string, string>();

        public Lab2Controller(ITask2_BL helper)
        {
            _helper = helper;
        }

        [HttpPost]
        [Route("task")]
        public async Task<ActionResult<string>> SolveTask([FromBody] Task2 list)
        {
            try
            {
                var result = await _helper.GetResultTask2Async(list);
                var key = Guid.NewGuid().ToString();

                _keyResults.Add(key, result);

                return Ok("\"" + key + "\"");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get/{key}")]
        public async Task<ActionResult<string>> GetResult(string key)
        {
            try
            {
                if (!_keyResults.ContainsKey(key))
                    throw new Exception("Can not find value");

                var result = _keyResults[key];
                _keyResults.Remove(key);

                return Ok("\"" + result + "\"");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}
