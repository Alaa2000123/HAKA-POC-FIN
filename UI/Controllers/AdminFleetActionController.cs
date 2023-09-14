using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceReference;

namespace UI.Controllers
{
    public class AdminFleetActionController : Controller
    {
        private readonly IClientContainer _client;
        private readonly TaskActionSoapClient _K2Service;
        public AdminFleetActionController(IClientContainer client, TaskActionSoapClient k2Service)
        {
            _client = client;
            _K2Service = k2Service;

        }
        public async Task<IActionResult> Index(int Id)
        {
            
            var flee = await _client.FleetManagement.GetByID(Id);
            
            var emps = await _client.GeneralEmployee.GetByID(Convert.ToInt32(flee.EmployeeId));
            ViewBag.AllEmp = emps.NameEn;
            GetEmployeeTaskListResponse result1 = await _K2Service.GetEmployeeTaskListAsync("Q.Abed", String.Empty, String.Empty, String.Empty, String.Empty, String.Empty);
            K2TaskItem[] Items = result1.Body.GetEmployeeTaskListResult;
            K2TaskItem item = Items.FirstOrDefault(e => e.ServiceName == "Fleet Management" && e.Folio == (Id).ToString());
            List<DTO.GeneralAction> actions = new List<DTO.GeneralAction>();
            IEnumerable<DTO.GeneralAction> allActions = await _client.GeneralAction.GetAll();

            foreach (var action in item.Actions)
            {
                var firstaction = allActions.FirstOrDefault(e => e.ActionNameEn == action);
                if (firstaction != null)
                {
                    actions.Add(firstaction);
                }
            }
            ViewBag.AllActions = new SelectList(actions, "Aid", "ActionNameEn");
            ActionTake actionTake = new ActionTake()
            {
                folio = Id,
            };
            return View(actionTake);
        }
        public async Task<IActionResult> Save(ActionTake actionTake)
        {
            var flee = await _client.FleetManagement.GetByID(actionTake.folio);

            #region GeneralRequests
            DTO.GeneralRequestsService generalRequest = await _client.GeneralRequestsService.GetByID(Convert.ToInt32(flee.RequestId));
            #endregion
            string action = "";
            if (actionTake.ActionId == 1)
            {
                action = "Approve";
                generalRequest.StepId = generalRequest.StepId + 1;
            }
            else if (actionTake.ActionId == 2)
            {
                action = "Reject";
                generalRequest.StepId = 5;
            }
            else if (actionTake.ActionId == 3)
            {
                action = "Complete";
                generalRequest.StepId = generalRequest.StepId + 1;
            }
            #region ActionHistory
            DTO.GeneralActionsHistory ActionsHistory = await _client.GeneralActionsHistory.InsertGeneralActionHistory(generalRequest.RequestId);
            #endregion


            GetEmployeeTaskListResponse result1 = await _K2Service.GetEmployeeTaskListAsync("Q.Abed", String.Empty, String.Empty, String.Empty, String.Empty, String.Empty);
            K2TaskItem[] Items = result1.Body.GetEmployeeTaskListResult;
            K2TaskItem item = Items.FirstOrDefault(e => e.ServiceName == "Fleet Management" && e.Folio == (actionTake.folio).ToString());

            ActionWorklistItemResponse response = await _K2Service.ActionWorklistItemAsync(item.serialNumber, action, "Q.Abed");
            var result = response.Body.ActionWorklistItemResult;

            var GR = await _client.GeneralRequestsService.Update(generalRequest);

            return RedirectToAction("Index", "AdminFleet");
        }
    }
}
