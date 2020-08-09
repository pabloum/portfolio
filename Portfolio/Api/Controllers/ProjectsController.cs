using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Api.Controllers
{
    public class ProjectsController : PortfolioBaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("We are working on this Endpoint");
        }
    }
}
