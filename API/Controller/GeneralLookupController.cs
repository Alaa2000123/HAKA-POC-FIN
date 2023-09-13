using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralLookupController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public GeneralLookupController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.GeneralLookup> EntityGeneralLookup = _unitofwork.GeneralLookup.GetAll().ToList();
            var DtoGeneralLookup = _Map.Map<List<DTO.GeneralLookup>>(EntityGeneralLookup);
            return Ok(DtoGeneralLookup);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityGeneralLookupType = _unitofwork.GeneralLookup.GetByID(Id);
            var DTOGeneralLookupType = _Map.Map<DTO.GeneralLookup>(EntityGeneralLookupType);

            return Ok(DTOGeneralLookupType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.GeneralLookup GeneralLookup)
        {

            var NewGeneralLookup = _Map.Map<Entity.GeneralLookup>(GeneralLookup);

            _unitofwork.GeneralLookup.Create(NewGeneralLookup);
            _unitofwork.Complete();

            GeneralLookup.Gnid = NewGeneralLookup.Gnid;
            return Ok(GeneralLookup);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.GeneralLookup GeneralLookup)
        {


            var EntityGeneralLookup = _Map.Map<Entity.GeneralLookup>(GeneralLookup);
            _unitofwork.GeneralLookup.Update(EntityGeneralLookup);
            _unitofwork.Complete();
            GeneralLookup = _Map.Map<DTO.GeneralLookup>(EntityGeneralLookup);
            return Ok(GeneralLookup);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.GeneralLookup GeneralLookup)
        {
            var EntityGeneralLookup = _unitofwork.GeneralLookup.GetByID(GeneralLookup.Gnid);
            if (EntityGeneralLookup != null)
            {



                _unitofwork.Complete();
                var DTOGeneralLookup = _Map.Map<DTO.GeneralLookup>(EntityGeneralLookup);
                return Ok(DTOGeneralLookup);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
