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
    public class ScaleController : ControllerBase
    {

        [HttpGet()]
        public ActionResult<long> Get()
        {
            var endTime = DateTime.Now.AddSeconds(10);

            while (true)
            {
                if (DateTime.Now >= endTime)
                    break;
            }

            return 1;
        }
    }
}
