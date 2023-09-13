using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FleetManagementController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public FleetManagementController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.FleetManagement> EntityFleetManagement = _unitofwork.FleetManagement.GetAll().ToList();
            var DtoFleetManagement = _Map.Map<List<DTO.FleetManagement>>(EntityFleetManagement);
            return Ok(DtoFleetManagement);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityFleetManagementType = _unitofwork.FleetManagement.GetByID(Id);
            var DTOFleetManagementType = _Map.Map<DTO.FleetManagement>(EntityFleetManagementType);

            return Ok(DTOFleetManagementType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.FleetManagement FleetManagement)
        {

            var NewFleetManagement = _Map.Map<Entity.FleetManagement>(FleetManagement);
     
            _unitofwork.FleetManagement.Create(NewFleetManagement);
            _unitofwork.Complete();

            FleetManagement.Id = NewFleetManagement.Id;
            return Ok(FleetManagement);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.FleetManagement FleetManagement)
        {


            var EntityFleetManagement = _Map.Map<Entity.FleetManagement>(FleetManagement);
            _unitofwork.FleetManagement.Update(EntityFleetManagement);
            _unitofwork.Complete();
            FleetManagement = _Map.Map<DTO.FleetManagement>(EntityFleetManagement);
            return Ok(FleetManagement);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.FleetManagement FleetManagement)
        {
            var EntityFleetManagement = _unitofwork.FleetManagement.GetByID(FleetManagement.Id);
            if (EntityFleetManagement != null)
            {


               
                _unitofwork.Complete();
                var DTOFleetManagement = _Map.Map<DTO.FleetManagement>(EntityFleetManagement);
                return Ok(DTOFleetManagement);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
