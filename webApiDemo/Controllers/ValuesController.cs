using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeesDAL;
using System.Collections;

namespace webApiDemo.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<Employee> Get()
        {
            using (testEntities employeeEntity = new testEntities())
                return employeeEntity.Employees.ToList<Employee>();
        }

        // GET api/values/5
        
        [Route("api/values/{id:int}",Name ="getEmployeeById")]
        public Employee Get(int id)
        {
            using (testEntities empentity = new testEntities())
                return empentity.Employees.FirstOrDefault(e => e.Id == id);
        }

        // POST api/values
        public List<Employee> Post([FromBody]Employee employee)
        {
            /*if (!ModelState.IsValid)
            {
                return employee.l
            }*/
            using (testEntities empentity = new testEntities())
            {
                empentity.Employees.Add(employee);
                empentity.SaveChanges();
                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, new Uri(Url.Link("getEmployeeById", new { id = employee.Id })));
                // response.Headers.Location = new Uri(Url.Link("getEmployeeById",new { id = employee.Id }));
                //return response;
                //using (testEntities employeeEntity = new testEntities())
                List<Employee> l = new List<Employee>();
                l.Add(empentity.Employees.FirstOrDefault(e => e.Id == employee.Id));
                    return l;
            }
        }

        // PUT api/values/5
        [Route("api/values/{id:int}", Name = "hello")]
        public List<Employee> Put(int id)
        {
            Employee stud;
            using (testEntities empentity = new testEntities())
            {
                //empentity.Employees.Add(employee);
                //empentity.SaveChanges();
                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, new Uri(Url.Link("getEmployeeById", new { id = employee.Id })));
                // response.Headers.Location = new Uri(Url.Link("getEmployeeById",new { id = employee.Id }));
                //return response;
                //using (testEntities employeeEntity = new testEntities())

                /* var original = empentity.Employees.FirstOrDefault(e => e.Id == id);

                 if (original != null)
                 {
                     Employee en = new Employee();
                     en.Id = original.Id;
                     en.Name = original.Name;
                     en.Gender = original.Gender;
                     en.DepartmentId = original.DepartmentId;
                     en.City = "hello";
                    original.City = "hola";
                    empentity.Employees.Add(original);
                    empentity.Entry(original).State = System.Data.Entity.EntityState.Modified;
                    empentity.SaveChanges();
                }
                */


                stud = empentity.Employees.Where(s => s.Id ==id).FirstOrDefault<Employee>();

                stud.Name = "Updated Student1";
                //Employee em = 

                //l.Add(em);
                //return l;
            }
            using (testEntities tcs = new testEntities())
            {
                //3. Mark entity as modified
                tcs.Entry(stud).State = System.Data.Entity.EntityState.Modified;

                //4. call SaveChanges
                tcs.SaveChanges();
                return tcs.Employees.ToList<Employee>();
            }

           
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }


}
