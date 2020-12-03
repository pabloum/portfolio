using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Base;
using Portfolio.Data;
using Portfolio.Entities;

namespace Portfolio.Api.Controllers
{
    public class InformationController : PortfolioBaseController
    {
        private readonly IOldRepository _service;

        public InformationController(IOldRepository service)
        {
            _service = service;
        }
        
        [HttpGet]
        public ActionResult<PersonalInformation> Get()
        {
            var info = _service.GetInformation();
            return Ok(info);
        }
    }
}
