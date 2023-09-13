using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceCompanyTypeController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public InsuranceCompanyTypeController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.InsuranceCompanyType> EntityInsuranceCompanyType = _unitofwork.InsuranceCompanyType.GetAll().ToList();
            var DtoInsuranceCompanyType = _Map.Map<List<DTO.InsuranceCompanyType>>(EntityInsuranceCompanyType);
            return Ok(DtoInsuranceCompanyType);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityInsuranceCompanyTypeType = _unitofwork.InsuranceCompanyType.GetByID(Id);
            var DTOInsuranceCompanyTypeType = _Map.Map<DTO.InsuranceCompanyType>(EntityInsuranceCompanyTypeType);

            return Ok(DTOInsuranceCompanyTypeType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.InsuranceCompanyType InsuranceCompanyType)
        {

            var NewInsuranceCompanyType = _Map.Map<Entity.InsuranceCompanyType>(InsuranceCompanyType);

            _unitofwork.InsuranceCompanyType.Create(NewInsuranceCompanyType);
            _unitofwork.Complete();

            InsuranceCompanyType.Id = NewInsuranceCompanyType.Id;
            return Ok(InsuranceCompanyType);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.InsuranceCompanyType InsuranceCompanyType)
        {


            var EntityInsuranceCompanyType = _Map.Map<Entity.InsuranceCompanyType>(InsuranceCompanyType);
            _unitofwork.InsuranceCompanyType.Update(EntityInsuranceCompanyType);
            _unitofwork.Complete();
            InsuranceCompanyType = _Map.Map<DTO.InsuranceCompanyType>(EntityInsuranceCompanyType);
            return Ok(InsuranceCompanyType);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.InsuranceCompanyType InsuranceCompanyType)
        {
            var EntityInsuranceCompanyType = _unitofwork.InsuranceCompanyType.GetByID(InsuranceCompanyType.Id);
            if (EntityInsuranceCompanyType != null)
            {



                _unitofwork.Complete();
                var DTOInsuranceCompanyType = _Map.Map<DTO.InsuranceCompanyType>(EntityInsuranceCompanyType);
                return Ok(DTOInsuranceCompanyType);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
