using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Swart.DomainDrivenDesign.Domain;
using Swart.DomainDrivenDesign.Repositories.Exceptions;
using Swart.DomainDrivenDesign.UnitTests.Fakes;

namespace Swart.DomainDrivenDesign.UnitTests.Repositories
{
    [TestFixture]
    public class RepositoryBaseTests
    {
        private MemoryRepository _repository;
        
        [SetUp]
        public void Setup()
        {   
            _repository = new MemoryRepository(); 
        }

        [Test]
        public void Add_ValideEntity_IdUpdated()
        {
            // Arrange            
            var entityMock = new Mock<IEntity<Guid>>();
            entityMock.Setup(x => x.Validate()).Returns(new List<ValidationResult>());
            entityMock.SetupProperty(x => x.Id);
            var entity = entityMock.Object; 

            // Act
            _repository.Add(entity);

            // Assert
            Assert.AreNotEqual(Guid.Empty, entity.Id);
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public void Add_InvalideEntity_ValidationExceptionThrown()
        {
            // Arrange            
            var entityMock = new Mock<IEntity<Guid>>();
            entityMock.Setup(x => x.Validate()).Returns(new List<ValidationResult> {new ValidationResult("any error")});
            entityMock.SetupProperty(x => x.Id);
            var entity = entityMock.Object;

            // Act
            _repository.Add(entity);
        }

        [TearDown]
        public void TearDown()
        {
            
        }
    }
}
