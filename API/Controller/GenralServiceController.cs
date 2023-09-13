using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenralServiceController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public GenralServiceController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.GenralService> EntityGenralService = _unitofwork.GenralService.GetAll().ToList();
            var DtoGenralService = _Map.Map<List<DTO.GenralService>>(EntityGenralService);
            return Ok(DtoGenralService);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityGenralServiceType = _unitofwork.GenralService.GetByID(Id);
            var DTOGenralServiceType = _Map.Map<DTO.GenralService>(EntityGenralServiceType);

            return Ok(DTOGenralServiceType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.GenralService GenralService)
        {

            var NewGenralService = _Map.Map<Entity.GenralService>(GenralService);

            _unitofwork.GenralService.Create(NewGenralService);
            _unitofwork.Complete();

            GenralService.Sid = NewGenralService.Sid;
            return Ok(GenralService);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.GenralService GenralService)
        {


            var EntityGenralService = _Map.Map<Entity.GenralService>(GenralService);
            _unitofwork.GenralService.Update(EntityGenralService);
            _unitofwork.Complete();
            GenralService = _Map.Map<DTO.GenralService>(EntityGenralService);
            return Ok(GenralService);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.GenralService GenralService)
        {
            var EntityGenralService = _unitofwork.GenralService.GetByID(GenralService.Sid);
            if (EntityGenralService != null)
            {



                _unitofwork.Complete();
                var DTOGenralService = _Map.Map<DTO.GenralService>(EntityGenralService);
                return Ok(DTOGenralService);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
