using BlogApiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController: ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var context = new Context();
            var value = context.Employees.ToList();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var context = new Context();
            context.Add(employee);
            context.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using var context = new Context();
            var employee = context.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }else
            {
                return Ok(employee);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            using var context = new Context();
            var employee = context.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            else
            {
                context.Remove(employee);
                context.SaveChanges();
                return Ok(employee);
            }
        }
        [HttpPut]
        public IActionResult EmployeeUpdate(Employee employee)
        {
            using var context = new Context();
            var updateEmployee=context.Find<Employee>(employee.Id);
            if (updateEmployee==null)
            {
                return NotFound();

            }
            else
            {
                updateEmployee.Name=employee.Name;
                context.Update(updateEmployee);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
    
