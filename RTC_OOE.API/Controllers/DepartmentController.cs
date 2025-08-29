using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RTC_OEE_Management_API.Models.DTO;
using RTC_OEE_Management_API.Models.Entities;
using RTC_OEE_Management_API.Repo.GenericEntity;

namespace RTC_OOE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentRepo _departmentRepo = new DepartmentRepo();
        private readonly FactoryRepo _factoryRepo = new FactoryRepo();
        private readonly MachineRepo _machineRepo = new MachineRepo();
        private readonly MachineModelCycleRepo _machineModelCycleRepo = new MachineModelCycleRepo();
        private readonly MachineStatusLogRepo _machineStatusLogRepo = new MachineStatusLogRepo();
        private readonly ModelRepo _modelRepo = new ModelRepo();
        private readonly PermissionRepo _permissionRepo = new PermissionRepo();
        private readonly PlannedDowntimeRepo _plannedDowntimeRepo = new PlannedDowntimeRepo();
        private readonly ProductionCountRepo _productionCountRepo = new ProductionCountRepo();
        private readonly ShiftRepo _shiftRepo = new ShiftRepo();
        private readonly UnplannedDowntimeReasonRepo _unplannedDowntimeReasonRepo = new UnplannedDowntimeReasonRepo();
        private readonly UserPermissionRepo _userPermissionRepo = new UserPermissionRepo();
        private readonly ZoneRepo _zoneRepo = new ZoneRepo();


        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                var result = _departmentRepo.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] DepartmentDTO department)
        {
            try
            {
                var departmentnew = new Department();
                departmentnew.dept_code = department.dept_code;
                departmentnew.dept_name = department.dept_name;
                var result = _departmentRepo.Create(departmentnew);
                return Ok( new{
                    result = result,
                    data = department
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("factory")]
        public IActionResult GetFactory()
        {
            try
            {

                var result = _factoryRepo.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("factoryPost")]
        public IActionResult PostFactory([FromBody] Factory factory)
        {
            try
            {
                var result = _factoryRepo.Create(factory);
                return Ok(new { result = result, factory = factory });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("machine")]
        public IActionResult GetMachine()
        {
            try
            {

                var result = _machineRepo.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("modelRepo")]
        public IActionResult GetModelRepo()
        {
            try
            {

                var result = _modelRepo.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("machineModelCycle")]
        public IActionResult GetmachineModelCycleRepo()
        {
            try
            {

                var result = _machineModelCycleRepo.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("machineStatusLogRepo")]
        public IActionResult GetmachineStatusLogRepo()
        {
            try
            {

                var result = _machineStatusLogRepo.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("permissionRepo")]
        public IActionResult GetPermissionRepo()
        {
            try
            {

                var result = _permissionRepo.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("plannedDowntimeRepo")]
        public IActionResult GetplannedDowntimeRepo()
        {
            try
            {

                var result = _plannedDowntimeRepo.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
