using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Controllers;

namespace ContactManager.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            //Arrange
            var rep = new Mock<IRepository<Contact>>();
            var controller = new HomeController(rep.Object);
            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Index_ModelIsACollectionOfContactObjects()
        {
            //Arrange
            var rep = new Mock<IRepository<Contact>>();
            rep.Setup(m => m.List(It.IsAny<QueryOptions<Contact>>())).Returns(new List<Contact>());
            var controller = new HomeController(rep.Object);

            //Act
            var viewResult = (ViewResult)controller.Index();
            var model = viewResult.ViewData.Model as List<Contact>;
            //Assert
            Assert.IsType<List<Contact>>(model);
        }
    }
}
