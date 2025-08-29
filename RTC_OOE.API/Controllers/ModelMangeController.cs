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
    public class ModelMangeController : ControllerBase
    {
        private readonly ModelRepo _modelRepo = new ModelRepo();
        private readonly IMapper mapper;
        public ModelMangeController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        [HttpGet("models")]
        public IActionResult GetModels()
        {
            try
            {
                var models = _modelRepo.GetAll();
                var result = mapper.Map<List<ModelDTO>>(models);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("model")]
        public IActionResult GetModel(int id)
        {
            try
            {
                var model = _modelRepo.GetByID(id);
                var result = mapper.Map<ModelDTO>(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("save_data")]
        public IActionResult SaveDate([FromBody] ModelDTO modelDTO)
        {
            try
            {
                var model = mapper.Map<Model>(modelDTO);
                if (modelDTO.model_id > 0)
                {

                    var result = _modelRepo.UpdateFieldsByID(modelDTO.model_id, model);
                    var data = mapper.Map<ModelDTO>(model);
                    return Ok(new
                    {
                        status = 1,
                        result = result,
                        data = data
                    });
                }
                else
                {
                    var result = _modelRepo.CreateAsync(model);
                    var data = mapper.Map<ModelDTO>(model);
                    return Ok(new
                    {
                        status = 1,
                        result = result,
                        data = data
                    });
                }


            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    status = 0,
                    message = ex.Message
                });
            }
        }
    }
}
