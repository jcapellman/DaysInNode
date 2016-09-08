using System;

using Microsoft.AspNetCore.Mvc;

namespace Day1InNode.WebAPI.Controllers {
    [Route("api/[controller]")]
    public class TestController : Controller {
        [HttpGet]
        public DateTime Get() {
            return DateTime.Now;
        }
    }
}