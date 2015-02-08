using System;
using NUnit.Framework;
using Swart.DomainDrivenDesign.UnitTests.Fakes;

namespace Swart.DomainDrivenDesign.UnitTests.Domain
{    
    [TestFixture]
    public class EntityTests
    {
        #region EntitiesWithSameId
        [Test]
        public void Equals_EntitiesWithSameId_ReturnsTrue()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            var entityLeft = new SampleEntity { Id = id };
            var entityRight = new SampleEntity { Id = id };

            //Act
            var result = entityLeft.Equals(entityRight);

            //Assert
            Assert.True(result);
        }

        [Test]
        public void EqualsOperator_EntitiesWithSameId_ReturnsTrue()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            var entityLeft = new SampleEntity { Id = id };
            var entityRight = new SampleEntity { Id = id };

            //Act            
            var resul = entityLeft == entityRight;

            //Assert
            Assert.True(resul);
        }

        [Test]
        public void NotEqualsOperator_EntitiesWithSameId_ReturnsFalse()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            var entityLeft = new SampleEntity { Id = id };
            var entityRight = new SampleEntity { Id = id };

            //Act            
            var resul = entityLeft != entityRight;

            //Assert
            Assert.False(resul);
        }
        #endregion

        #region EntitiesWithDiffIds
        [Test]
        public void Equals_EntitiesWithDiffIds_ReturnsFalse()
        {
            //Arrange            
            var entityLeft = new SampleEntity { Id = Guid.NewGuid() };
            var entityRight = new SampleEntity { Id = Guid.NewGuid() };

            //Act
            var result = entityLeft.Equals(entityRight);

            //Assert
            Assert.False(result);
        }

        [Test]
        public void EqualsOperator_EntitiesWithDiffIds_ReturnsFalse()
        {
            //Arrange            
            var entityLeft = new SampleEntity { Id = Guid.NewGuid() };
            var entityRight = new SampleEntity { Id = Guid.NewGuid() };

            //Act
            var result = entityLeft == entityRight;

            //Assert
            Assert.False(result);
        }

        [Test]
        public void NotEqualsOperator_EntitiesWithDiffIds_ReturnsTrue()
        {
            //Arrange            
            var entityLeft = new SampleEntity { Id = Guid.NewGuid() };
            var entityRight = new SampleEntity { Id = Guid.NewGuid() };

            //Act
            var result = entityLeft != entityRight;

            //Assert
            Assert.True(result);
        }
        #endregion        

        #region CompareEntityToItSelf
        [Test]
        public void Equals_CompareEntityToItSelf_ReturnsTrue()
        {
            //Arrange            
            var entityLeft = new SampleEntity { Id = Guid.NewGuid() };
            var entityRight = entityLeft;

            //Act
            var result = entityLeft.Equals(entityRight);

            //Assert
            Assert.True(result);
        }

        [Test]
        public void EqualsOperator_CompareEntityToItSelf_ReturnsTrue()
        {
            //Arrange            
            var entityLeft = new SampleEntity { Id = Guid.NewGuid() };
            var entityRight = entityLeft;

            //Act
            var result = entityLeft == entityRight;

            //Assert
            Assert.True(result);
        }

        [Test]
        public void NotEqualsOperator_CompareEntityToItSelf_ReturnsFalse()
        {
            //Arrange            
            var entityLeft = new SampleEntity { Id = Guid.NewGuid() };
            var entityRight = entityLeft;

            //Act
            var result = entityLeft != entityRight;

            //Assert
            Assert.False(result);
        }
        #endregion        

        [Test]
        public void Equals_CompareEntityToNull_ReturnsFalse()
        {
            //Arrange            
            var entity = new SampleEntity { Id = Guid.NewGuid() };            

            //Act
            var result = entity.Equals(null);

            //Assert
            Assert.False(result);
        }
    }
}
