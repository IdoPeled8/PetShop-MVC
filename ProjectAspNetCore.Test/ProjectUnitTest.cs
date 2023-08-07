

using NUnit.Framework;
using Moq;
using PetShopLogic;
using PetShopModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using PetShopDAL.Repository;

namespace ProjectAspNetCore.Test
{
    [TestFixture]
    public class AnimalLogicTests
    {
        private AnimalLogic? _animalLogic;
        private Mock<IAnimalRepository>? _animalRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _animalRepositoryMock = new Mock<IAnimalRepository>();
            _animalLogic = new AnimalLogic(_animalRepositoryMock.Object);
        }

        [Test]
        public async Task GetAnimalsWithMostComments_ShouldCall_GetAnimalsWithMostComments_OnRepository()
        {
            // Arrange
            var animalsWithMostComments = new List<Animal> { new Animal(), new Animal(), new Animal() };
            _animalRepositoryMock?.Setup(x => x.GetAnimalsWithMostComments()).ReturnsAsync(animalsWithMostComments);

            // Act
            var result = await _animalLogic.GetAnimalsWithMostComments();

            // Assert
            _animalRepositoryMock?.Verify(x => x.GetAnimalsWithMostComments(), Times.Once);
            NUnit.Framework.Assert.AreEqual(3, result.Count);
        }

        [Test]
        public async Task GetAnimalByIdAsync_ShouldCall_GetByIdAsync_OnRepository()
        {
            // Arrange
            int animalId = 1;
            var animal = new Animal { AnimalId = animalId };
            _animalRepositoryMock?.Setup(x => x.GetByIdAsync(animalId)).ReturnsAsync(animal);

            // Act
            var result = await _animalLogic.GetAnimalByIdAsync(animalId);

            // Assert
            _animalRepositoryMock.Verify(x => x.GetByIdAsync(animalId), Times.Once);
            NUnit.Framework.Assert.IsNotNull(result);
            NUnit.Framework.Assert.AreEqual(animalId, result.AnimalId);
        }

        [Test]
        public async Task GetAllAnimalsAsync_ShouldCall_GetAllAsync_OnRepository()
        {
            // Arrange
            var animals = new List<Animal> { new Animal(), new Animal(), new Animal() };
            _animalRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(animals);

            // Act
            var result = await _animalLogic.GetAllAnimalsAsync();

            // Assert
            _animalRepositoryMock.Verify(x => x.GetAllAsync(), Times.Once);
            NUnit.Framework.Assert.AreEqual(3, result.Count);
        }

        [Test]
        public async Task GetAnimalsByCategoryAsync_ShouldCall_GetByCategoryAsync_OnRepository()
        {
            // Arrange
            int categoryId = 1;
            var animalsInCategory = new List<Animal> { new Animal(), new Animal() };
            _animalRepositoryMock.Setup(x => x.GetByCategoryAsync(categoryId)).ReturnsAsync(animalsInCategory);

            // Act
            var result = await _animalLogic.GetAnimalsByCategoryAsync(categoryId);

            // Assert
            _animalRepositoryMock.Verify(x => x.GetByCategoryAsync(categoryId), Times.Once);
            NUnit.Framework.Assert.AreEqual(2, result.Count);
        }

        [Test]
        public async Task AddCommentToAnimalAsync_ShouldCall_AddCommentAsync_OnRepository()
        {
            // Arrange
            int animalId = 1;
            string commentText = "This is a comment";
            _animalRepositoryMock.Setup(x => x.AddCommentAsync(commentText, animalId)).Returns(Task.CompletedTask);

            // Act
            await _animalLogic.AddCommentToAnimalAsync(commentText, animalId);

            // Assert
            _animalRepositoryMock.Verify(x => x.AddCommentAsync(commentText, animalId), Times.Once);
        }

        [Test]
        public async Task AddAnimalAsync_ShouldCall_AddAsync_OnRepository()
        {
            // Arrange
            var animal = new Animal { AnimalId = 1, Name = "Dog" };
            _animalRepositoryMock.Setup(x => x.AddAsync(animal)).Returns(Task.CompletedTask);

            // Act
            await _animalLogic.AddAnimalAsync(animal);

            // Assert
            _animalRepositoryMock.Verify(x => x.AddAsync(animal), Times.Once);
        }

        // Additional tests for other methods in AnimalLogic can be added in a similar manner.
    }
}
