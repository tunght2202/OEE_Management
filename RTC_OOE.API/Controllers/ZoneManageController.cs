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
    public class ZoneManageController : ControllerBase
    {
        private readonly ZoneRepo _zoneRepo = new ZoneRepo();
        private readonly IMapper mapper;
        public ZoneManageController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        [HttpGet("zones")]
        public IActionResult GetZones()
        {
            try
            {
                var zones = _zoneRepo.GetAll();
                var result = mapper.Map<List<ZoneDTO>>(zones);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("zone")]
        public IActionResult GetZone(int id)
        {
            try
            {
                var zone = _zoneRepo.GetByID(id);
                var result = mapper.Map<ZoneDTO>(zone);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("save_data")]
        public IActionResult SaveDate([FromBody] ZoneDTO zoneDTO)
        {
            try
            {
                var zone = mapper.Map<Zone>(zoneDTO);
                if (zoneDTO.zone_id > 0)
                {
                    
                    var result = _zoneRepo.UpdateFieldsByID(zoneDTO.zone_id, zone);
                    var data = mapper.Map<ZoneDTO>(zone);
                    return Ok(new
                    {
                        status = 1,
                        result = result,
                        data = data
                    });
                }
                else
                {
                    var result = _zoneRepo.CreateAsync(zone);
                    var data = mapper.Map<ZoneDTO>(zone);
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
