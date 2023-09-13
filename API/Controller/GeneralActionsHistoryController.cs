using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralActionsHistoryController : ControllerBase
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _Map;
        public GeneralActionsHistoryController(IUnitofwork unitofwork, IMapper Map)
        {
            _unitofwork = unitofwork;
            _Map = Map;
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult GetAll()
        {
            List<Entity.GeneralActionsHistory> EntityGeneralActionsHistory = _unitofwork.GeneralActionsHistory.GetAll().ToList();
            var DtoGeneralActionsHistory = _Map.Map<List<DTO.GeneralActionsHistory>>(EntityGeneralActionsHistory);
            return Ok(DtoGeneralActionsHistory);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetByID(int Id)
        {
            var EntityGeneralActionsHistoryType = _unitofwork.GeneralActionsHistory.GetByID(Id);
            var DTOGeneralActionsHistoryType = _Map.Map<DTO.GeneralActionsHistory>(EntityGeneralActionsHistoryType);

            return Ok(DTOGeneralActionsHistoryType);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Insert(DTO.GeneralActionsHistory GeneralActionsHistory)
        {

            var NewGeneralActionsHistory = _Map.Map<Entity.GeneralActionsHistory>(GeneralActionsHistory);

            _unitofwork.GeneralActionsHistory.Create(NewGeneralActionsHistory);
            _unitofwork.Complete();

            GeneralActionsHistory.Id = NewGeneralActionsHistory.Id;
            return Ok(GeneralActionsHistory);

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(DTO.GeneralActionsHistory GeneralActionsHistory)
        {


            var EntityGeneralActionsHistory = _Map.Map<Entity.GeneralActionsHistory>(GeneralActionsHistory);
            _unitofwork.GeneralActionsHistory.Update(EntityGeneralActionsHistory);
            _unitofwork.Complete();
            GeneralActionsHistory = _Map.Map<DTO.GeneralActionsHistory>(EntityGeneralActionsHistory);
            return Ok(GeneralActionsHistory);
        }


        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(DTO.GeneralActionsHistory GeneralActionsHistory)
        {
            var EntityGeneralActionsHistory = _unitofwork.GeneralActionsHistory.GetByID(GeneralActionsHistory.Id);
            if (EntityGeneralActionsHistory != null)
            {



                _unitofwork.Complete();
                var DTOGeneralActionsHistory = _Map.Map<DTO.GeneralActionsHistory>(EntityGeneralActionsHistory);
                return Ok(DTOGeneralActionsHistory);
            }
            else
            {
                return NotFound();
            }


        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult InsertGeneralActionHistory(int GeneralRequestID)
        {
            var EntityGeneralActionHistory = _unitofwork.GeneralActionsHistory.InsertGeneralActionHistory(GeneralRequestID);
            if (EntityGeneralActionHistory != null)
            {
                _unitofwork.Complete();
                return Ok(EntityGeneralActionHistory);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
