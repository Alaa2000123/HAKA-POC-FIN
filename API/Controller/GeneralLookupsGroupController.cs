using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralLookupsGroupController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public GeneralLookupsGroupController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.GeneralLookupsGroup> EntityGeneralLookupsGroup = _unitofwork.GeneralLookupsGroup.GetAll().ToList();
            var DtoGeneralLookupsGroup = _Map.Map<List<DTO.GeneralLookupsGroup>>(EntityGeneralLookupsGroup);
            return Ok(DtoGeneralLookupsGroup);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityGeneralLookupsGroupType = _unitofwork.GeneralLookupsGroup.GetByID(Id);
            var DTOGeneralLookupsGroupType = _Map.Map<DTO.GeneralLookupsGroup>(EntityGeneralLookupsGroupType);

            return Ok(DTOGeneralLookupsGroupType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.GeneralLookupsGroup GeneralLookupsGroup)
        {

            var NewGeneralLookupsGroup = _Map.Map<Entity.GeneralLookupsGroup>(GeneralLookupsGroup);

            _unitofwork.GeneralLookupsGroup.Create(NewGeneralLookupsGroup);
            _unitofwork.Complete();

            GeneralLookupsGroup.Gid = NewGeneralLookupsGroup.Gid;
            return Ok(GeneralLookupsGroup);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.GeneralLookupsGroup GeneralLookupsGroup)
        {


            var EntityGeneralLookupsGroup = _Map.Map<Entity.GeneralLookupsGroup>(GeneralLookupsGroup);
            _unitofwork.GeneralLookupsGroup.Update(EntityGeneralLookupsGroup);
            _unitofwork.Complete();
            GeneralLookupsGroup = _Map.Map<DTO.GeneralLookupsGroup>(EntityGeneralLookupsGroup);
            return Ok(GeneralLookupsGroup);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.GeneralLookupsGroup GeneralLookupsGroup)
        {
            var EntityGeneralLookupsGroup = _unitofwork.GeneralLookupsGroup.GetByID(GeneralLookupsGroup.Gid);
            if (EntityGeneralLookupsGroup != null)
            {



                _unitofwork.Complete();
                var DTOGeneralLookupsGroup = _Map.Map<DTO.GeneralLookupsGroup>(EntityGeneralLookupsGroup);
                return Ok(DTOGeneralLookupsGroup);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
