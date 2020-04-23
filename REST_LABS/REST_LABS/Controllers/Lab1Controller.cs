using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_LABS_BLL.Implementation;
using REST_LABS_BLL.Interfaces;
using REST_LABS_BLL.Models;

namespace REST_LABS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lab1Controller : ControllerBase
    {
        private ITask1_BL _helper;
        private static Dictionary<string, string> _keyResults = new Dictionary<string, string>();

        public Lab1Controller(ITask1_BL helper)
        {
            _helper = helper;
        }

        [HttpPost]
        [Route("task1")]
        public async Task<ActionResult<string>> ResolveTask1([FromBody] Task1 list)
        {
            try
            {
                var result = await _helper.GetResultTask1Async(list);
                var key = Guid.NewGuid().ToString();

                _keyResults.Add(key, result);

                return Ok("\"" + key + "\"");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("get1/{key}")]
        public async Task<ActionResult<string>> GetResult1(string key)
        {
            try
            {
                if (!_keyResults.ContainsKey(key))
                    throw new Exception("Can not find value");

                var result = _keyResults[key];
                _keyResults.Remove(key);

                return Ok("\"" + result + "\"");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("task2")]
        public async Task<ActionResult<string>> ResolveTask2([FromBody] Task1 lists)
        {
            try
            {
                var result = await _helper.GetResultTask2Async(lists.ElementsData);
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
        [Route("get2/{key}")]
        public async Task<ActionResult<string>> GetResult2(string key)
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