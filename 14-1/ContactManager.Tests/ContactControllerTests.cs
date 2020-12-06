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
    public class ContactControllerTests
    {
        [Fact]
        public void Add_ReturnsTwoViewDataDictionaryItems()
        {
            //Arrange
            var unit = GetAddUnitOfWork();
            var controller = new ContactController(unit);

            int expectedCount = 2;
            string expectedAction = "Add";
            //Act
            ViewResult result = controller.Add();
            int actualCount = result.ViewData.Count;
            string actualAction = result.ViewData["Action"].ToString();
            var categories = (List<Category>)result.ViewData["Categories"];

            //Assert
            Assert.Equal(expectedCount, actualCount);
            Assert.Equal(expectedAction, actualAction);
            Assert.IsType<List<Category>>(categories);
        }
        [Fact]
        public void Edit_POST_InvalidData_ReturnsViewResult()
        {
            // Arrange
            var unit = GetEditUnitOfWork();
            var controller = new ContactController(unit);
            controller.ModelState.AddModelError("", "Error");

            //Act
            var result = controller.Edit(new Contact());

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        private IUnitOfWork GetAddUnitOfWork()
        {
            var rep = new Mock<IRepository<Category>>();
            rep.Setup(m => m.List(It.IsAny<QueryOptions<Category>>())).Returns(new List<Category>());

            var unit = new Mock<IUnitOfWork>();
            unit.Setup(m => m.Categories).Returns(rep.Object);
            return unit.Object;
        }

        private IUnitOfWork GetEditUnitOfWork()
        {
            var contactRep = new Mock<IRepository<Contact>>();
            
            var categoryrep = new Mock<IRepository<Category>>();
                categoryrep.Setup(m => m.List(It.IsAny<QueryOptions<Category>>())).Returns(new List<Category>());

            var unit = new Mock<IUnitOfWork>();
            unit.Setup(m => m.Contacts).Returns(contactRep.Object);
            unit.Setup(m => m.Categories).Returns(categoryrep.Object);
            return unit.Object;
        }
    }
}
