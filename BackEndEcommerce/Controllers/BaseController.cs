using BackEndEcommerce.Models;
using BackEndEcommerce.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEndEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : class
    {
        public readonly eCommerceContext context;
        public IRepository<T> repository;

        public BaseController(eCommerceContext _context, IRepository<T> _repository)
        {
            context = _context;
            repository = _repository;
        }

        // GET: api/[Controller]
        [HttpGet]
        public ActionResult<ApiResponses> GetEntity()
        {
            ApiResponses response = new ApiResponses()
            {
                Success = true,
            };

            try
            {
                IEnumerable<T> Data = repository.Get();
                response.Data = Data;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                response.Success = false;
            }

            return response;
        }

        // GET: api/[Controller]/1 
        [HttpGet("{Id}")]
        public virtual ActionResult<ApiResponses> GetEntity(int Id)
        {
            ApiResponses response = new ApiResponses()
            {
                Success = true
            };

            try
            {
                response.Data = repository.Get(Id);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                response.Success = false;
            }

            return response;
        }

        [HttpPut]
        public virtual ActionResult<ApiResponses> PutEntity([FromQuery] int Id)
        {
            ApiResponses response = new ApiResponses()
            {
                Success = true,
            };

            T request = null;

            try
            {
                if (repository.Get(Id) == null)
                {
                    response.Success = false;
                    return response;
                }
                else
                {
                    request = repository.Get(Id);
                }
      
                repository.Update(request);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                response.Success = false;
                response.Message = ex.Message.ToString();
            }

            return response;
        }

        // POST: api/Base
        [HttpPost]
        public virtual ActionResult<ApiResponses> PostEntity(T request)
        {
            ApiResponses response = new ApiResponses()
            {
                Success = true,
            };

            try
            {
                repository.Insert(request);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                response.Success = false;
            }

            return response;
        }
        // DELETE: api/Base/5
        [HttpDelete]
        public virtual ActionResult<ApiResponses> DeleteEntity([FromQuery] int Id)
        {
            ApiResponses response = new ApiResponses()
            {
                Success = true,
            };

            try
            {
                if (repository.Get(Id) == null)
                {
                    response.Success = false;
                    return response;
                }

                repository.Delete(repository.Get(Id));
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
                response.Success = false;
            }

            return response;
        }
    }
}
