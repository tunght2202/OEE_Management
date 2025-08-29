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
    public class MachineManageController : ControllerBase
    {
        private readonly MachineRepo _machineRepo = new MachineRepo();
        private readonly IMapper mapper;
        public MachineManageController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet("machines")]
        public IActionResult GetMachines()
        {
            try
            {
                var machines = _machineRepo.GetAll();
                var result = mapper.Map<List<MachineDTO>>(machines);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("machine")]
        public IActionResult GetMachine(int id)
        {
            try
            {
                var machine = _machineRepo.GetByID(id);
                var result = mapper.Map<MachineDTO>(machine);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("save_data")]
        public IActionResult SaveDate([FromBody] MachineDTO machineDTO)
        {
            try
            {
                var machine = mapper.Map<Machine>(machineDTO);
                if (machineDTO.zone_id > 0)
                {

                    var result = _machineRepo.UpdateFieldsByID(machineDTO.machine_id, machine);
                    var data = mapper.Map<MachineDTO>(machine);
                    return Ok(new
                    {
                        status = 1,
                        result = result,
                        data = data
                    });
                }
                else
                {
                    var result = _machineRepo.CreateAsync(machine);
                    var data = mapper.Map<MachineDTO>(machine);
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
