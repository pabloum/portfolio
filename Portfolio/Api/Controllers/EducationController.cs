using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Base;
using Portfolio.Data;
using Portfolio.Entities.DTOs;
using Portfolio.Entities.Entities;
using Services;

namespace Portfolio.Api.Controllers
{
    public class EducationController : PortfolioGenericController<Education>
    {
        public EducationController(IBaseService<Education> service) : base(service)
        {
        }
    }
}
