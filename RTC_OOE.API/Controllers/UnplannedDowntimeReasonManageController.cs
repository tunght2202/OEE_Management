using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RTC_OEE_Management_API.Models.DTO;
using RTC_OEE_Management_API.Models.Entities;
using RTC_OEE_Management_API.Repo.GenericEntity;

namespace RTC_OOE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnplannedDowntimeReasonManageController : ControllerBase
    {
        private readonly UnplannedDowntimeReasonRepo _unplannedDowntimeReasonRepo = new UnplannedDowntimeReasonRepo();
        private readonly IMapper mapper;
        public UnplannedDowntimeReasonManageController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        [HttpGet("unplanned_downtime_Reasons")]
        public IActionResult GetUnplannedDowntimeReasons()
        {
            try
            {
                var unplannedDowntimeReasons = _unplannedDowntimeReasonRepo.GetAll();
                var result = mapper.Map<List<UnplannedDowntimeReasonDTO>>(unplannedDowntimeReasons);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("unplanned_downtime_reason")]
        public IActionResult GetUnplannedDowntimeReason(int id)
        {
            try
            {
                var unplannedDowntimeReason = _unplannedDowntimeReasonRepo.GetByID(id);
                var result = mapper.Map<UnplannedDowntimeReasonDTO>(unplannedDowntimeReason);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("save_data")]
        public IActionResult SaveDate([FromBody] UnplannedDowntimeReasonDTO unplannedDowntimeReasonDTO)
        {
            try
            {
                var unplannedDowntimeReason = mapper.Map<UnplannedDowntimeReason>(unplannedDowntimeReasonDTO);
                if (unplannedDowntimeReasonDTO.reason_id > 0)
                {

                    var result = _unplannedDowntimeReasonRepo.UpdateFieldsByID(unplannedDowntimeReasonDTO.reason_id, unplannedDowntimeReason);
                    var data = mapper.Map<UnplannedDowntimeReasonDTO>(unplannedDowntimeReason);
                    return Ok(new
                    {
                        status = 1,
                        result = result,
                        data = data
                    });
                }
                else
                {
                    var result = _unplannedDowntimeReasonRepo.CreateAsync(unplannedDowntimeReason);
                    var data = mapper.Map<UnplannedDowntimeReasonDTO>(unplannedDowntimeReason);
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
