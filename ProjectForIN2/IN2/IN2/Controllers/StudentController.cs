using IN2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace IN2.Controllers
{
    public class StudentController : ApiController
    {
        public StudentController()
        {
            Repository = (IRepository)GlobalConfiguration
               .Configuration
               .DependencyResolver
               .GetService(typeof(IRepository));
        }

        public IEnumerable<STUDENT> GetStudents()
        {
            return Repository.ListOfStudents;
        }
        [Route("api/getStudent/{studentID}")]
        public IHttpActionResult GetStudent(int studentID)
        {
            try
            {
                var getStudent = Repository.GetStudent(studentID);
                //var getStudent = Repository
                //    .ListOfStudents.Where(s => s
                //    .StudentID == studentID)
                //    .FirstOrDefault();

                if (getStudent == null)
                {
                    return NotFound();
                }

                return Ok(getStudent);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult PostStudent([FromBody]STUDENT student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Repository.SaveStudent(student);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
                return Ok(true);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        public async Task DeleteStudent(int studentId)
        {
            await Repository.DeleteStudent(studentId);
        }

        private IRepository Repository { get; set; }
    }
}
