using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralRequestsServiceController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public GeneralRequestsServiceController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.GeneralRequestsService> EntityGeneralRequestsService = _unitofwork.GeneralRequestsService.GetAll().ToList();
            var DtoGeneralRequestsService = _Map.Map<List<DTO.GeneralRequestsService>>(EntityGeneralRequestsService);
            return Ok(DtoGeneralRequestsService);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityGeneralRequestsServiceType = _unitofwork.GeneralRequestsService.GetByID(Id);
            var DTOGeneralRequestsServiceType = _Map.Map<DTO.GeneralRequestsService>(EntityGeneralRequestsServiceType);

            return Ok(DTOGeneralRequestsServiceType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.GeneralRequestsService GeneralRequestsService)
        {

            var NewGeneralRequestsService = _Map.Map<Entity.GeneralRequestsService>(GeneralRequestsService);

            _unitofwork.GeneralRequestsService.Create(NewGeneralRequestsService);
            _unitofwork.Complete();

            GeneralRequestsService.RequestId = NewGeneralRequestsService.RequestId;
            return Ok(GeneralRequestsService);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.GeneralRequestsService GeneralRequestsService)
        {


            var EntityGeneralRequestsService = _Map.Map<Entity.GeneralRequestsService>(GeneralRequestsService);
            _unitofwork.GeneralRequestsService.Update(EntityGeneralRequestsService);
            _unitofwork.Complete();
            GeneralRequestsService = _Map.Map<DTO.GeneralRequestsService>(EntityGeneralRequestsService);
            return Ok(GeneralRequestsService);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.GeneralRequestsService GeneralRequestsService)
        {
            var EntityGeneralRequestsService = _unitofwork.GeneralRequestsService.GetByID(GeneralRequestsService.RequestId);
            if (EntityGeneralRequestsService != null)
            {



                _unitofwork.Complete();
                var DTOGeneralRequestsService = _Map.Map<DTO.GeneralRequestsService>(EntityGeneralRequestsService);
                return Ok(DTOGeneralRequestsService);
            }
            else
            {
                return NotFound();
            }


        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult InsertGeneralRequest(int TableID, int ServiceTypeID, int StepID)
        { 
            var EntityGeneralRequestsService = _unitofwork.GeneralRequestsService.InsertGeneralRequest(TableID, ServiceTypeID, StepID);
            if (EntityGeneralRequestsService != null)
            {
                _unitofwork.Complete();
                return Ok(EntityGeneralRequestsService);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
