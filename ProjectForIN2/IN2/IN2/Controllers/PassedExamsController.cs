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
    public class PassedExamsController : ApiController
    {
        public PassedExamsController()
        {
            Repository = (IRepository)GlobalConfiguration
               .Configuration
               .DependencyResolver
               .GetService(typeof(IRepository));
        }
        [Route("api/getAllPassedExams")]
        public IEnumerable<POLOZENI_ISPITI> GetAllPassedExams()
        {
            return Repository.ListOfPassedExams;
        }
        
        public IHttpActionResult GetPassedExams(int studentID, int subjectID)
        {
            try
            {
                IEnumerable<POLOZENI_ISPITI> getPassedExamsForStudent;
                if (studentID == 0 && subjectID == 0)
                {
                    return BadRequest();
                }
                else if (subjectID != 0 && studentID != 0)
                {
                    getPassedExamsForStudent = Repository
                    .ListOfPassedExams
                    .Where(e => e
                    .StudentID == studentID && e
                    .PredmetID == subjectID);
                }
                else if (subjectID == 0 && studentID != 0)
                {
                    getPassedExamsForStudent = Repository
                    .ListOfPassedExams
                    .Where(e => e
                    .StudentID == studentID);
                }
                else
                {
                    getPassedExamsForStudent = Repository
                    .ListOfPassedExams
                    .Where(e => e
                    .PredmetID == subjectID);
                }

                if (!getPassedExamsForStudent.Any())
                {
                    return NotFound();
                }

                return Ok(getPassedExamsForStudent);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        
        public IHttpActionResult PostPassedExam(POLOZENI_ISPITI exam)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (exam.StudentID != 0 && exam.PredmetID != 0)
                    {
                        var getStudent = Repository
                            .ListOfStudents
                            .Where(s => s
                            .StudentID == exam
                            .StudentID);

                        var getSubject = Repository
                            .ListOfSubjects
                            .Where(s => s
                            .PredmetID == exam
                            .PredmetID);

                        if (!getStudent.Any() || !getSubject.Any())
                        {
                            return BadRequest();
                        }
                        Repository.SavePassedExam(exam);
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }

                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
        private IRepository Repository { get; set; }
    }
}
