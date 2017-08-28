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
    public class SubjectController : ApiController
    {
        public SubjectController()
        {
            Repository = (IRepository)GlobalConfiguration
               .Configuration
               .DependencyResolver
               .GetService(typeof(IRepository));
        }
        
        public IEnumerable<PREDMET> GetSubjects()
        {
            return Repository.ListOfSubjects;
        }
        [Route("api/getSubject/{subjectID}")]
        public IHttpActionResult GetSubject(int subjectID)
        {
            try
            {
                var getSubject = Repository.GetSubject(subjectID);

                if (getSubject == null)
                {
                    return NotFound();
                }

                return Ok(getSubject);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult PostSubject(PREDMET subject)
        {
            if (ModelState.IsValid)
            {
                Repository.SaveSubject(subject);
                return Ok(true);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        public async Task<IHttpActionResult> DeleteSubject(int subjectID)
        {
            var getSubject = Repository.GetSubject(subjectID);

            if (getSubject == null)
            {
                return BadRequest();
            }

            await Repository.DeleteSubject(subjectID);
            return Ok();
        }

        private IRepository Repository { get; set; }
    }
}
