using Microsoft.AspNetCore.Mvc;
using MojaSzafa.Controllers;
using MojaSzafa.Models;
using MojaSzafa.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MojaSzafa.TESTS.UnitTests
{
    /// <summary>
    /// Class implementing tests for application CRUD testing
    /// </summary>
    public class WardrobeControllerTests
    {
        [Fact]
        public void Index_ReturnsListOfItems()
        {
            //Arrange
            var items = new List<Clothing>();
            items.Add(new Clothing { Name = "testShirt1", Material = "testMaterial1", Color = "testColor1", DateAdded = DateTime.Now });
            items.Add(new Clothing { Name = "testShirt2", Material = "testMaterial2", Color = "testColor1", DateAdded = DateTime.Now });
            items.Add(new Clothing { Name = "testShirt3", Material = "testMaterial3", Color = "testColor3", DateAdded = DateTime.Now });
            var mockRepository = new Mock<IClothingRepository>();
            mockRepository.Setup(repository => repository.GetAll()).Returns(items.AsQueryable());
            var controller = new WardrobeController(mockRepository.Object);

            //Act
            //Assert
            var result = controller.Index("", null, "", "");
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Clothing>>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());

            var resultFiltering = controller.Index("testColor1", null, "testColor1", "");
            var viewResultFiltering = Assert.IsType<ViewResult>(resultFiltering);
            var modelFiltering = Assert.IsAssignableFrom<IEnumerable<Clothing>>(viewResultFiltering.ViewData.Model);
            Assert.Equal(2, modelFiltering.Count());

            var resultOrdering = controller.Index("", null, "", "name_desc");
            var viewResultOrdering = Assert.IsType<ViewResult>(resultOrdering);
            var modelOrdering = Assert.IsAssignableFrom<IEnumerable<Clothing>>(viewResultOrdering.ViewData.Model);
            Assert.Equal(items.OrderByDescending(i => i.Name), modelOrdering.ToList());
            
        }

        [Fact]
        public void Add_InvalidObject()
        {
            //Arrange
            var mockRepository = new Mock<IClothingRepository>();
            var controller = new WardrobeController(mockRepository.Object);
            var clothing = new Clothing() { Name = "", Material = "testMaterial0", Color = "testColor0", DateAdded = DateTime.Now };
            controller.ModelState.AddModelError("Name", "Required");

            //Act
            var badResponse = controller.Add(clothing);

            //Assert
            Assert.IsType<ViewResult>(badResponse);
        }

        [Fact]
        public void Add_ValidObject()
        {
            //Arrange
            var mockRepository = new Mock<IClothingRepository>();
            var controller = new WardrobeController(mockRepository.Object);
            var clothing = new Clothing() { Name = "", Material = "testMaterial0", Color = "testColor0", DateAdded = DateTime.Now };

            //Act
            var response = controller.Add(clothing);

            //Assert
            Assert.IsType<RedirectToActionResult>(response);
        }

        [Fact]
        public void Edit_NullId()
        {
            //Arrange
            var mockRepository = new Mock<IClothingRepository>();
            var controller = new WardrobeController(mockRepository.Object);
            int? id = null;

            //Act
            var response = controller.Edit(id);

            //Assert
            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public void Edit_NonExistingId()
        {
            //Arrange
            var mockRepository = new Mock<IClothingRepository>();
            var controller = new WardrobeController(mockRepository.Object);
            int id = -1;

            //Act
            var response = controller.Edit(id);

            //Assert
            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public void Edit_ExistingId()
        {
            //Arrange
            int id = 900729;
            var clothing = new Clothing() {Id = id, Name = "testName0", Material = "testMaterial0", Color = "testColor0", DateAdded = DateTime.Now };
            var mockRepository = new Mock<IClothingRepository>();
            mockRepository.Setup(repository => repository.GetById(id)).Returns(clothing);
            var controller = new WardrobeController(mockRepository.Object);

            //Act
            var response = controller.Edit(id);

            //Assert
            Assert.IsType<ViewResult>(response);
        }

        [Fact]
        public void Edit_InvalidObject()
        {
            //Arrange
            int id = 900729;
            var clothing = new Clothing() { Id = id, Name = "", Material = "testMaterial0", Color = "testColor0", DateAdded = DateTime.Now };
            var mockRepository = new Mock<IClothingRepository>();
            mockRepository.Setup(repository => repository.GetById(id)).Returns(clothing);
            var controller = new WardrobeController(mockRepository.Object);
            controller.ModelState.AddModelError("Name", "Required");

            //Act
            var response = controller.Edit(id, clothing);

            //Assert
            Assert.IsType<ViewResult>(response);
        }

        [Fact]
        public void Edit_ValidObject()
        {
            //Arrange
            int id = 900729;
            var clothing = new Clothing() { Id = id, Name = "testName0", Material = "testMaterial0", Color = "testColor0", DateAdded = DateTime.Now };
            var mockRepository = new Mock<IClothingRepository>();
            mockRepository.Setup(repository => repository.GetById(id)).Returns(clothing);
            var controller = new WardrobeController(mockRepository.Object);

            //Act
            var response = controller.Edit(id, clothing);

            //Assert
            Assert.IsType<RedirectToActionResult>(response);
        }

        [Fact]
        public void Delete_NullId()
        {
            //Arrange
            int? id = null;
            var mockRepository = new Mock<IClothingRepository>();
            var controller = new WardrobeController(mockRepository.Object);

            //Act
            var response = controller.Delete(id);

            //Assert
            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public void Delete_NonExistingId()
        {
            //Arrange
            var mockRepository = new Mock<IClothingRepository>();
            var controller = new WardrobeController(mockRepository.Object);
            int id = -1;

            //Act
            var response = controller.Delete(id);

            //Assert
            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public void Delete_ExistingId()
        {
            //Arrange
            int id = 900729;
            var clothing = new Clothing() { Id = id, Name = "testName0", Material = "testMaterial0", Color = "testColor0", DateAdded = DateTime.Now };
            var mockRepository = new Mock<IClothingRepository>();
            mockRepository.Setup(repository => repository.GetById(id)).Returns(clothing);
            var controller = new WardrobeController(mockRepository.Object);

            //Act
            var response = controller.Delete(id);

            //Assert
            Assert.IsType<RedirectToActionResult>(response);
        }


        [Fact]
        public void BlankTest()
        {
            //Arrange
            var mockRepository = new Mock<IClothingRepository>();
            var controller = new WardrobeController(mockRepository.Object);

            //Act

            //Assert
            Assert.True(!false);
        }
    }
}
