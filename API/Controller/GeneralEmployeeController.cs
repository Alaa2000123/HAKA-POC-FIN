using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralEmployeeController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public GeneralEmployeeController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.GeneralEmployee> EntityGeneralEmployee = _unitofwork.GeneralEmployee.GetAll().ToList();
            var DtoGeneralEmployee = _Map.Map<List<DTO.GeneralEmployee>>(EntityGeneralEmployee);
            return Ok(DtoGeneralEmployee);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityGeneralEmployeeType = _unitofwork.GeneralEmployee.GetByID(Id);
            var DTOGeneralEmployeeType = _Map.Map<DTO.GeneralEmployee>(EntityGeneralEmployeeType);

            return Ok(DTOGeneralEmployeeType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.GeneralEmployee GeneralEmployee)
        {

            var NewGeneralEmployee = _Map.Map<Entity.GeneralEmployee>(GeneralEmployee);

            _unitofwork.GeneralEmployee.Create(NewGeneralEmployee);
            _unitofwork.Complete();

            GeneralEmployee.Id = NewGeneralEmployee.Id;
            return Ok(GeneralEmployee);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.GeneralEmployee GeneralEmployee)
        {


            var EntityGeneralEmployee = _Map.Map<Entity.GeneralEmployee>(GeneralEmployee);
            _unitofwork.GeneralEmployee.Update(EntityGeneralEmployee);
            _unitofwork.Complete();
            GeneralEmployee = _Map.Map<DTO.GeneralEmployee>(EntityGeneralEmployee);
            return Ok(GeneralEmployee);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.GeneralEmployee GeneralEmployee)
        {
            var EntityGeneralEmployee = _unitofwork.GeneralEmployee.GetByID(GeneralEmployee.Id);
            if (EntityGeneralEmployee != null)
            {



                _unitofwork.Complete();
                var DTOGeneralEmployee = _Map.Map<DTO.GeneralEmployee>(EntityGeneralEmployee);
                return Ok(DTOGeneralEmployee);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
