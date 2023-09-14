using Connecter.Client;
using Microsoft.AspNetCore.Mvc;
using ServiceReference;

namespace UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IClientContainer _client;
        private readonly TaskActionSoapClient _K2Service;
        public AdminController(IClientContainer client, TaskActionSoapClient k2Service)
        {
            _client = client;
            _K2Service = k2Service;

        }
        public async Task<IActionResult> Index()
        {
            string user = Request.Cookies["User"];
            if (user == null)
            {
                return RedirectToAction("SignIn", "Login");
            }
            if (user == "Admin")
            {
                ViewBag.user = 1;
            }
            else
            {
                ViewBag.user = 2;
            }
            IEnumerable<DTO.InsuranceInfo> Insu = await _client.InsuranceInfo.GetAll();
            var emps = await _client.GeneralEmployee.GetAll();
            ViewBag.Emps = emps;
            GetEmployeeTaskListResponse result1 = await _K2Service.GetEmployeeTaskListAsync("Q.Abed", String.Empty, String.Empty, String.Empty, String.Empty, String.Empty);
            K2TaskItem[] Items = result1.Body.GetEmployeeTaskListResult;
            ViewBag.listwf = Items.Where(e => e.ServiceName == "Insurance").ToArray();
            var GR = await _client.GeneralRequestsService.GetAll();
            ViewBag.GR = GR;
            return View(Insu);
        }
       
    }
}
