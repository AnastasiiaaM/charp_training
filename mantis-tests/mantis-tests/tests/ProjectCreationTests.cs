using System;
using System.Collections.Generic;
using System.Security.Principal;
using mantis_tests.Mantis;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [SetUp]
        public void Init()
        {
            app.Api.DeleteExistingProject(account, new ProjectData("New project"));
        }

        [Test]
        public void ProjectCreationTest()
        {
            List<ProjectData> oldProjectsList = app.Api.GetProjectsList(account);

            ProjectData project = new ProjectData("New project")
            {
                Status = "development",
                Visibility = "public",
                Enabled = "True",
                Description = "Test Description",
            };

            app.Api.CreateNewProject(account, project);

            Assert.AreEqual(oldProjectsList.Count + 1, app.Api.GetCountProjects(account));

            List<ProjectData> newProjectsList = app.Api.GetProjectsList(account);

            project.Visibility = "публичный";
            oldProjectsList.Add(project);
            oldProjectsList.Sort();
            newProjectsList.Sort();

            Assert.AreEqual(oldProjectsList, newProjectsList);
        }

    }
}
