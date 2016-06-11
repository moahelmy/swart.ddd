using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Swart.DomainDrivenDesign.Domain;
using Swart.DomainDrivenDesign.UnitTests.Fakes;

namespace Swart.DomainDrivenDesign.UnitTests.Repositories
{
    [TestFixture]
    [Category("Unit Test")]
    public class RepositoryBaseTests
    {
        private MemoryRepository _repository;
        
        [SetUp]
        public void Setup()
        {   
            _repository = new MemoryRepository(); 
        }

        [Test]
        public void Add_Null_ReturnError()
        {
            // Act
            var result = _repository.Add((IEntity<Guid>) null);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Succeed, Is.False);
        }

        [Test]
        public void Add_ValideEntity_IdUpdated()
        {
            // Arrange            
            var entity = _CreateValidEntity();

            // Act
            var result = _repository.Add(entity);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Succeed, Is.True);            
            Assert.That(entity.Id, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public void Add_InvalideEntity_ReturnErrors()
        {
            // Arrange                        
            var entity = _CreateInvalidEntity();

            // Act
            var result = _repository.Add(entity);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Succeed, Is.False);            
        }

        [Test]
        public void Add_ListWithInvalidEntity_NoAdd()
        {
            // Arranage
            var entities = new List<IEntity<Guid>>
            {
                _CreateValidEntity(),
                _CreateInvalidEntity()
            };

            // Act
            var result = _repository.Add(entities);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Succeed, Is.False);
        }

        [Test]
        public void Update_Null_ReturnError()
        {
            // Act
            var result = _repository.Update((IEntity<Guid>)null);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Succeed, Is.False);
        }


        [Test]
        public void Update_ValideEntity_Succeed()
        {
            // Arrange            
            var entity = _CreateValidEntity();

            // Act
            _repository.Add(entity);
            var result = _repository.Update(entity);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Succeed, Is.True);
            Assert.That(entity.Id, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public void Update_InvalideEntity_ReturnErrors()
        {
            // Arrange                        
            var entityMock = _CreateValidEntityMock();

            // Act
            _repository.Add(entityMock.Object);
            entityMock.Setup(x => x.Validate()).Returns(new List<ValidationResult> { new ValidationResult("any error") });
            var result = _repository.Add(entityMock.Object);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Succeed, Is.False);
        }

        [Test]
        public void Delete_Null_ReturnError()
        {
            // Act
            var result = _repository.Delete((IEntity<Guid>)null);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Succeed, Is.False);
        }

        [Test]
        public void Get_IdNotFound_ErrorReturned()
        {
            // Arrange            

            // Act
            var result = _repository.Get(Guid.NewGuid());

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Succeed, Is.False);            
        }

        [Test]
        public void Get_IdFound_EntityReturned()
        {
            // Arrange
            var entity = _CreateValidEntity();
            _repository.Add(entity);

            // Act
            var result = _repository.Get(entity.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Succeed, Is.True);
        }        

        private Mock<IEntity<Guid>> _CreateValidEntityMock()
        {
            var entityMock = new Mock<IEntity<Guid>>();
            entityMock.Setup(x => x.Validate()).Returns(new List<ValidationResult>());
            entityMock.SetupProperty(x => x.Id);
            return entityMock;
        }

        private IEntity<Guid> _CreateValidEntity()
        {
            var entityMock = new Mock<IEntity<Guid>>();
            entityMock.Setup(x => x.Validate()).Returns(new List<ValidationResult>());
            entityMock.SetupProperty(x => x.Id);
            return entityMock.Object;
        }

        private IEntity<Guid> _CreateInvalidEntity()
        {
            var entityMock = new Mock<IEntity<Guid>>();
            entityMock.Setup(x => x.Validate()).Returns(new List<ValidationResult> { new ValidationResult("any error") });
            entityMock.SetupProperty(x => x.Id);
            return entityMock.Object;
        }

        [TearDown]
        public void TearDown()
        {
            
        }
    }
}
