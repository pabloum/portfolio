using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Base;
using Portfolio.Data;
using Portfolio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Api.Controllers
{
    public class InformationController : PortfolioBaseController
    {
        private readonly IRepository repository;

        public InformationController(IRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult<PersonalInformation> Get()
        {
            var info = repository.GetInformation();
            return Ok(info);
        }
    }
}
