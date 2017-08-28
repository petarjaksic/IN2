using Microsoft.VisualStudio.TestTools.UnitTesting;
using IN2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using IN2.Models;
using Moq;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace IN2.Controllers.Tests
{
    [TestClass()]
    public class StudentControllerTests
    {
        [TestMethod()]
        public void GetStudentsTest()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }
        ////[TestMethod()]
        //public void StudentControllerTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void StudentControllerTest1()
        //{
        //    Assert.Fail();
        //}
        [TestMethod]
        public async Task GetStudentTest2()
        {

            var config = new HttpConfiguration();
            //configure web api
            config.MapHttpAttributeRoutes();

            using (var server = new HttpServer(config))
            {

                var client = new HttpClient(server);

                string url = "http://localhost:51745/api/getStudent/2";

                using (var response = await client.GetAsync(url))
                {
                    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                }
            }            
        }
    }
}