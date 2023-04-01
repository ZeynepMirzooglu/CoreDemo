using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class EmployeeTestController: Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44329/api/Default");
            var jsonString=await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ClassEmployee>>(jsonString);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(ClassEmployee classEmployee)
        {
            var httpClient = new HttpClient();
            var jsonEmployee=JsonConvert.SerializeObject(classEmployee);
            StringContent content = new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
            var responseMessage=await httpClient.PostAsync("https://localhost:44329/api/Default",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(classEmployee);
        }
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage=await httpClient.GetAsync("https://localhost:44329/api/Default/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonEmployee = await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<ClassEmployee>(jsonEmployee); 
                return View(value);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(ClassEmployee classEmployee)
        {
            var httpClient = new HttpClient();
            var jsonEmployee=JsonConvert.SerializeObject(classEmployee);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44329/api/Default",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(classEmployee);
        }
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44329/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
    public class ClassEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
