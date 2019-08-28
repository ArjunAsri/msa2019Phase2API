using WebApplication1.Controllers;
using WebApplication1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;

namespace UnitTestScribrAPI
{
    [TestClass]
    public class TasksControllerUnitTests
    {

        public static readonly DbContextOptions<scriberContext> options =
            new DbContextOptionsBuilder<scriberContext>().UseInMemoryDatabase(databaseName: "testDatabase").Options;



        public static readonly IList<Tasks> datavalues = new List<Tasks>
        {
            new Tasks()
            {

                TaskName = "New Task1", TaskPriority = 2, CourseNumber = "100G", TaskDescription = "This is a new task 1", DateAndTime = Convert.ToDateTime("2019-09-20T10:30:00")
            },
            new Tasks()
            {
                TaskName = "New Task2", TaskPriority = 10, CourseNumber = "200G", TaskDescription = "This is a new task 2", DateAndTime = Convert.ToDateTime("2019-10-20T10:30:00")
            }
        };

        [TestInitialize]
        public void SetupDb()
        {
            using (var context = new scriberContext(options))
            {
                // populate the db
                context.Tasks.Add(datavalues[0]);
                context.Tasks.Add(datavalues[1]);
                context.SaveChanges();
            }
        }

        [TestCleanup]
        public void ClearDb()
        {
            using (var context = new scriberContext(options))
            {
                // clear the db
                context.Tasks.RemoveRange(context.Tasks);
                context.SaveChanges();
            };
        }

        [TestMethod]
        public async Task TestGetSuccessfully()
        {
            using (var context = new scriberContext(options))
            {
                TasksController tasksController = new TasksController(context);
                ActionResult<IEnumerable<Tasks>> result = await tasksController.GetTasks();

                Assert.IsNotNull(result);
                // i should really check to make sure the exact transcriptions are in there, but that requires an equality comparer,
                // which requires a whole nested class, thanks to C#'s lack of anonymous classes that implement interfaces
            }
        }

        [TestMethod]
        public async Task TestPutTasksNoContentStatusCode()
        {
            using (var context = new scriberContext(options))
            {
                string newPhrase = "New Task 5";
                Tasks tasks1 = context.Tasks.Where(x => x.TaskName == datavalues[0].TaskName).Single();
                //tasks1 = datavalues[0];
                tasks1.TaskName = newPhrase;
   
                TasksController tasksController1 = new TasksController(context);
                IActionResult result = await tasksController1.PutTasks(tasks1.TaskId, tasks1);
                // PutTasks(tasks1.TaskId, tasks1) as IActionResult

                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(NoContentResult));

                
            }
        }



    };


}


