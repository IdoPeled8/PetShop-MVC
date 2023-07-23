


//namespace ProjectAspNetCore.Test;

//[TestClass]
//public class ProjectUnitTest
//{
//    [TestMethod]
//    public void AddAnimal_Should_Add_Animal_To_Database()
//    {
//        // Arrange
//        var options = new DbContextOptionsBuilder<PetShopContext>()
//            .UseInMemoryDatabase(databaseName: "TestDatabase")
//            .Options;

//        using (var context = new PetShopContext(options))
//        {
//            var animalRepository = new AnimalRepository(context);
//            var animal = new Animal {AnimalId = 11, Name = "Cat", Age = 3,Description = "asdasd", CategoryId = 1 };

//            // Act
//            await animalRepository.AddAsync(animal);
//        }

//        // Assert
//        using (var context = new PetShopContext(options))
//        {
//            var addedAnimal = context.Animals!.FirstOrDefault(a => a.Name == "Cat");
//            Assert.IsNotNull(addedAnimal);
//            Assert.AreEqual(3, addedAnimal.Age);
//        }
//    }
//}