using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RTC_OEE_Management_API.Models.DTO;
using RTC_OEE_Management_API.Models.Entities;
using RTC_OEE_Management_API.Repo.GenericEntity;

namespace RTC_OOE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryManageController : ControllerBase
    {
        private readonly FactoryRepo _factoryRepo = new FactoryRepo();
        private readonly IMapper mapper;
        public FactoryManageController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        [HttpGet("factories")]
        public IActionResult GetFactories()
        {
            try
            {

                var result = _factoryRepo.GetAll();
                var factoryDto = mapper.Map<List<FactoryDTO>>(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("factory")]
        public IActionResult GetFactory(int id)
        {
            try
            {

                var factory = _factoryRepo.GetByID(id);
                var result = mapper.Map<FactoryDTO>(factory);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("factoryPost")]
        public IActionResult PostFactory([FromBody] FactoryDTO factoryDTO)
        {
            try
            {
                var factory = mapper.Map<Factory>(factoryDTO);

                if( factory.factory_id > 0 )
                {
                    _factoryRepo.UpdateFieldsByID(factory.factory_id, factory);
                    return Ok(new
                    {
                        status = 1,
                        data = factory
                    });
                }

                _factoryRepo.CreateAsync(factory);
                return Ok(new
                {
                    status = 1,
                    data = factory
                });
            }
            catch (Exception ex)
            {
                return Ok(new { status = 0, message = ex.Message, error = ex.ToString() });
            }
        }
    }
}
