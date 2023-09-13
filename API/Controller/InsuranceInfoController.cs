using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceInfoController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public InsuranceInfoController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.InsuranceInfo> EntityInsuranceInfo = _unitofwork.InsuranceInfo.GetAll().ToList();
            var DtoInsuranceInfo = _Map.Map<List<DTO.InsuranceInfo>>(EntityInsuranceInfo);
            return Ok(DtoInsuranceInfo);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityInsuranceInfoType = _unitofwork.InsuranceInfo.GetByID(Id);
            var DTOInsuranceInfoType = _Map.Map<DTO.InsuranceInfo>(EntityInsuranceInfoType);

            return Ok(DTOInsuranceInfoType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.InsuranceInfo InsuranceInfo)
        {

            var NewInsuranceInfo = _Map.Map<Entity.InsuranceInfo>(InsuranceInfo);

            _unitofwork.InsuranceInfo.Create(NewInsuranceInfo);
            _unitofwork.Complete();

            InsuranceInfo.Id = NewInsuranceInfo.Id;
            return Ok(InsuranceInfo);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.InsuranceInfo InsuranceInfo)
        {


            var EntityInsuranceInfo = _Map.Map<Entity.InsuranceInfo>(InsuranceInfo);
            _unitofwork.InsuranceInfo.Update(EntityInsuranceInfo);
            _unitofwork.Complete();
            InsuranceInfo = _Map.Map<DTO.InsuranceInfo>(EntityInsuranceInfo);
            return Ok(InsuranceInfo);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.InsuranceInfo InsuranceInfo)
        {
            var EntityInsuranceInfo = _unitofwork.InsuranceInfo.GetByID(InsuranceInfo.Id);
            if (EntityInsuranceInfo != null)
            {



                _unitofwork.Complete();
                var DTOInsuranceInfo = _Map.Map<DTO.InsuranceInfo>(EntityInsuranceInfo);
                return Ok(DTOInsuranceInfo);
            }
            else
            {
                return NotFound();
            }


        }
    }
}
