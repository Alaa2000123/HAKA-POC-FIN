using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralActionController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public GeneralActionController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.GeneralAction> EntityGeneralAction = _unitofwork.GeneralAction.GetAll().ToList();
            var DtoGeneralAction = _Map.Map<List<DTO.GeneralAction>>(EntityGeneralAction);
            return Ok(DtoGeneralAction);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityGeneralActionType = _unitofwork.GeneralAction.GetByID(Id);
            var DTOGeneralActionType = _Map.Map<DTO.GeneralAction>(EntityGeneralActionType);

            return Ok(DTOGeneralActionType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.GeneralAction GeneralAction)
        {

            var NewGeneralAction = _Map.Map<Entity.GeneralAction>(GeneralAction);

            _unitofwork.GeneralAction.Create(NewGeneralAction);
            _unitofwork.Complete();

            GeneralAction.Aid = NewGeneralAction.Aid;
            return Ok(GeneralAction);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.GeneralAction GeneralAction)
        {


            var EntityGeneralAction = _Map.Map<Entity.GeneralAction>(GeneralAction);
            _unitofwork.GeneralAction.Update(EntityGeneralAction);
            _unitofwork.Complete();
            GeneralAction = _Map.Map<DTO.GeneralAction>(EntityGeneralAction);
            return Ok(GeneralAction);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.GeneralAction GeneralAction)
        {
            var EntityGeneralAction = _unitofwork.GeneralAction.GetByID(GeneralAction.Aid);
            if (EntityGeneralAction != null)
            {



                _unitofwork.Complete();
                var DTOGeneralAction = _Map.Map<DTO.GeneralAction>(EntityGeneralAction);
                return Ok(DTOGeneralAction);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
