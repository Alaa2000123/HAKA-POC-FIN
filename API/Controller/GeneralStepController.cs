using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralStepController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public GeneralStepController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.GeneralStep> EntityGeneralStep = _unitofwork.GeneralStep.GetAll().ToList();
            var DtoGeneralStep = _Map.Map<List<DTO.GeneralStep>>(EntityGeneralStep);
            return Ok(DtoGeneralStep);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityGeneralStepType = _unitofwork.GeneralStep.GetByID(Id);
            var DTOGeneralStepType = _Map.Map<DTO.GeneralStep>(EntityGeneralStepType);

            return Ok(DTOGeneralStepType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.GeneralStep GeneralStep)
        {

            var NewGeneralStep = _Map.Map<Entity.GeneralStep>(GeneralStep);

            _unitofwork.GeneralStep.Create(NewGeneralStep);
            _unitofwork.Complete();

            GeneralStep.Stid = NewGeneralStep.Stid;
            return Ok(GeneralStep);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.GeneralStep GeneralStep)
        {


            var EntityGeneralStep = _Map.Map<Entity.GeneralStep>(GeneralStep);
            _unitofwork.GeneralStep.Update(EntityGeneralStep);
            _unitofwork.Complete();
            GeneralStep = _Map.Map<DTO.GeneralStep>(EntityGeneralStep);
            return Ok(GeneralStep);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.GeneralStep GeneralStep)
        {
            var EntityGeneralStep = _unitofwork.GeneralStep.GetByID(GeneralStep.Stid);
            if (EntityGeneralStep != null)
            {



                _unitofwork.Complete();
                var DTOGeneralStep = _Map.Map<DTO.GeneralStep>(EntityGeneralStep);
                return Ok(DTOGeneralStep);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
