using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenralStatusController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public GenralStatusController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.GenralStatus> EntityGenralStatus = _unitofwork.GeneralStatus.GetAll().ToList();
            var DtoGenralStatus = _Map.Map<List<DTO.GenralStatus>>(EntityGenralStatus);
            return Ok(DtoGenralStatus);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityGenralStatusType = _unitofwork.GeneralStatus.GetByID(Id);
            var DTOGenralStatusType = _Map.Map<DTO.GenralStatus>(EntityGenralStatusType);

            return Ok(DTOGenralStatusType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.GenralStatus GenralStatus)
        {

            var NewGenralStatus = _Map.Map<Entity.GenralStatus>(GenralStatus);

            _unitofwork.GeneralStatus.Create(NewGenralStatus);
            _unitofwork.Complete();

            GenralStatus.Id = NewGenralStatus.Id;
            return Ok(GenralStatus);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.GenralStatus GenralStatus)
        {


            var EntityGenralStatus = _Map.Map<Entity.GenralStatus>(GenralStatus);
            _unitofwork.GeneralStatus.Update(EntityGenralStatus);
            _unitofwork.Complete();
            GenralStatus = _Map.Map<DTO.GenralStatus>(EntityGenralStatus);
            return Ok(GenralStatus);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.GenralStatus GenralStatus)
        {
            var EntityGenralStatus = _unitofwork.GeneralStatus.GetByID(GenralStatus.Id);
            if (EntityGenralStatus != null)
            {



                _unitofwork.Complete();
                var DTOGenralStatus = _Map.Map<DTO.GenralStatus>(EntityGenralStatus);
                return Ok(DTOGenralStatus);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
