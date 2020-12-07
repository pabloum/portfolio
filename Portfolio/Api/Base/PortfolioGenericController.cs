using Microsoft.AspNetCore.Mvc;
using Portfolio.Entities.Base;
using Services;
using System.Collections.Generic;

namespace Portfolio.Api.Base
{
    public abstract class PortfolioGenericController<T> : PortfolioBaseController where T : BaseEntity
    {
        protected readonly IBaseService<T> _service;
        public PortfolioGenericController(IBaseService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<T>> GetAll()
        {
            var entities = _service.GetAll();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public ActionResult<T> Get(int id)
        {
            var entity = _service.Read(id);
            return Ok(entity);
        }

        [HttpPost]
        public ActionResult<string> Post(T entity)
        {
            var response = _service.Create(entity);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, T entity)
        {
            var response = _service.Update(id, entity);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            var response = _service.Delete(id);
            return Ok(response);
        }
    }
}
