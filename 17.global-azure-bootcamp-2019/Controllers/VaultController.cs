using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace managed.identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaultController : ControllerBase
    {
        private IConfiguration config;

        public VaultController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpGet()]
        public ActionResult<string> Get()
        {
            return config["Bootcamp:Secret"];
        }
    }
}
