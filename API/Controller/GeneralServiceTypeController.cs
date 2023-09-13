using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralServiceTypeController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public GeneralServiceTypeController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.GeneralServiceType> EntityGeneralServiceType = _unitofwork.ServiceType.GetAll().ToList();
            var DtoGeneralServiceType = _Map.Map<List<DTO.GeneralServiceType>>(EntityGeneralServiceType);
            return Ok(DtoGeneralServiceType);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityGeneralServiceTypeType = _unitofwork.ServiceType.GetByID(Id);
            var DTOGeneralServiceTypeType = _Map.Map<DTO.GeneralServiceType>(EntityGeneralServiceTypeType);

            return Ok(DTOGeneralServiceTypeType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.GeneralServiceType GeneralServiceType)
        {

            var NewGeneralServiceType = _Map.Map<Entity.GeneralServiceType>(GeneralServiceType);

            _unitofwork.ServiceType.Create(NewGeneralServiceType);
            _unitofwork.Complete();

            GeneralServiceType.Stid = NewGeneralServiceType.Stid;
            return Ok(GeneralServiceType);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.GeneralServiceType GeneralServiceType)
        {


            var EntityGeneralServiceType = _Map.Map<Entity.GeneralServiceType>(GeneralServiceType);
            _unitofwork.ServiceType.Update(EntityGeneralServiceType);
            _unitofwork.Complete();
            GeneralServiceType = _Map.Map<DTO.GeneralServiceType>(EntityGeneralServiceType);
            return Ok(GeneralServiceType);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.GeneralServiceType GeneralServiceType)
        {
            var EntityGeneralServiceType = _unitofwork.ServiceType.GetByID(GeneralServiceType.Stid);
            if (EntityGeneralServiceType != null)
            {



                _unitofwork.Complete();
                var DTOGeneralServiceType = _Map.Map<DTO.GeneralServiceType>(EntityGeneralServiceType);
                return Ok(DTOGeneralServiceType);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
