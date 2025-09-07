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
    public class PlannedDowntimeManageController : ControllerBase
    {
        private readonly PlannedDowntimeRepo _plannedDowntimeRepo = new PlannedDowntimeRepo();
        private readonly IMapper mapper;
        public PlannedDowntimeManageController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        [HttpGet("planned_downtimes")]
        public IActionResult GetPlannedDowntimes()
        {
            try
            {
                var plannedDowntimes = _plannedDowntimeRepo.GetAll();
                var result = mapper.Map<List<PlannedDowntimeDTO>>(plannedDowntimes);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("planned_downtime")]
        public IActionResult GetPlannedDowntime(int id)
        {
            try
            {
                var plannedDowntime = _plannedDowntimeRepo.GetByID(id);
                var result = mapper.Map<PlannedDowntimeDTO>(plannedDowntime);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("save_data")]
        public IActionResult SaveDate([FromBody] PlannedDowntimeDTO plannedDowntimeDTO)
        {
            try
            {
                var plannedDowntime = mapper.Map<PlannedDowntime>(plannedDowntimeDTO);
                if (plannedDowntimeDTO.downtime_id > 0)
                {

                    var result = _plannedDowntimeRepo.UpdateFieldsByID(plannedDowntimeDTO.downtime_id, plannedDowntime);
                    var data = mapper.Map<PlannedDowntimeDTO>(plannedDowntime);
                    return Ok(new
                    {
                        status = 1,
                        result = result,
                        data = data
                    });
                }
                else
                {
                    var result = _plannedDowntimeRepo.CreateAsync(plannedDowntime);
                    var data = mapper.Map<PlannedDowntimeDTO>(plannedDowntime);
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
