using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ServiceReference;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientContainer _client;
        private readonly TaskActionSoapClient _K2;
        public HomeController(IClientContainer client, TaskActionSoapClient k2)
        {
            _client = client;
            _K2 = k2;

        }
        public async Task<IActionResult> Index()
        {
            int user = Convert.ToInt32(Request.Cookies["user"]);
            var AllEmp = await _client.GeneralEmployee.GetByID(user);
            ViewBag.AllEmp = AllEmp.NameEn;
            var lookupfleet = await _client.GeneralLookup.GetAll();
            var AllFleetManagementType = lookupfleet.Where(e => e.GroupId == 2);
            ViewBag.AllFleetManagementType = new SelectList(AllFleetManagementType, "Gnid", "NameEn");
            return View();
        }

        public async Task<IActionResult> Save(DTO.FleetManagement FleetManagement)
        {
            int user = Convert.ToInt32(Request.Cookies["user"]);
            FleetManagement.EmployeeId = user;
            Response forcast;
            forcast = await _client.FleetManagement.Insert(FleetManagement);
            FleetManagement = JsonConvert.DeserializeObject<DTO.FleetManagement>(forcast.Result.ToString());
            if (forcast.IsSuccess)
            {
                #region GeneralRequests
                DTO.GeneralRequestsService generalRequest = await _client.GeneralRequestsService.InsertGeneralRequest(FleetManagement.Id, (int)Classes.ServiceTypes.FleetManagement, (int)Classes.Steps.Requester);
                #endregion

                #region ActionHistory
                DTO.GeneralActionsHistory ActionsHistory = await _client.GeneralActionsHistory.InsertGeneralActionHistory(generalRequest.RequestId);
                #endregion

                FleetManagement.RequestId = generalRequest.RequestId;

                ServiceReference.StartProcessResponse Response = await _K2.StartProcessAsync("Q.Abed", FleetManagement.Id, generalRequest.RequestId, Classes.Constants.FleetManagementWF);
                int ProcessID = int.Parse(Response.Body.StartProcessResult.ToString());
                generalRequest.ProcessId = ProcessID;

                forcast = await _client.FleetManagement.Update(FleetManagement);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Welcomepage()
        {
            var CUser = Request.Cookies["user"];
            if (CUser == "Admin" || CUser == "Manager")
            {
                ViewBag.User = "1";
            }
            else
            {
                var User = await _client.GeneralEmployee.GetByID(Convert.ToInt32(CUser));
                ViewBag.User = User.NameEn;
            }
            return View();

        }
        public IActionResult IDashboard()
        {
            return View();
        }
        public IActionResult IDashboard2()
        {
            return View();
        }
    }
}