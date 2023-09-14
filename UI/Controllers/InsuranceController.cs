using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ServiceReference;

namespace UI.Controllers
{
    public class InsuranceController : Controller
    {
        private readonly IClientContainer _client;
        private readonly TaskActionSoapClient _K2;
        public InsuranceController(IClientContainer client, TaskActionSoapClient k2)
        {
            _client = client;
            _K2 = k2;

        }
        public async Task<IActionResult> Index()
        {
            int user = Convert.ToInt32(Request.Cookies["user"]);
            var AllEmp = await _client.GeneralEmployee.GetByID(user);
            ViewBag.AllEmp = AllEmp.NameEn;
            var insucomp = await _client.InsuranceCompanyType.GetAll();
            ViewBag.insucomp = new SelectList(insucomp, "Id", "NameEn");
            var lookupfleet = await _client.GeneralLookup.GetAll();
            var AllInsuranceType = lookupfleet.Where(e => e.GroupId == 1);
            ViewBag.AllInsuranceType = new SelectList(AllInsuranceType, "Gnid", "NameEn");
            return View();
        }
        public async Task<IActionResult> Save(DTO.InsuranceInfo insuranceInfo)
        {
            int user = Convert.ToInt32(Request.Cookies["user"]);
            insuranceInfo.EmployeeId = user;
            Response forcast;
            insuranceInfo.InsuranceStartDate = DateTime.Now;
            insuranceInfo.InsuranceEndDate = (DateTime.Now).AddYears(4);
            forcast = await _client.InsuranceInfo.Insert(insuranceInfo);
            insuranceInfo = JsonConvert.DeserializeObject<DTO.InsuranceInfo>(forcast.Result.ToString());
            if (forcast.IsSuccess)
            {
                #region GeneralRequests
                DTO.GeneralRequestsService generalRequest = await _client.GeneralRequestsService.InsertGeneralRequest(insuranceInfo.Id, (int)Classes.ServiceTypes.Insurance, (int)Classes.Steps.Requester);
                #endregion
                
                #region ActionHistory
                DTO.GeneralActionsHistory ActionsHistory = await _client.GeneralActionsHistory.InsertGeneralActionHistory(generalRequest.RequestId);
                #endregion

                insuranceInfo.RequestId = generalRequest.RequestId;

                ServiceReference.StartProcessResponse Response = await _K2.StartProcessAsync("Q.Abed", insuranceInfo.Id, generalRequest.RequestId, Classes.Constants.InsuranceWF);
                int ProcessID = int.Parse(Response.Body.StartProcessResult.ToString());
                generalRequest.ProcessId = ProcessID;

                forcast = await _client.InsuranceInfo.Update(insuranceInfo);
            }
            return RedirectToAction("Index");
        }

    }
}
