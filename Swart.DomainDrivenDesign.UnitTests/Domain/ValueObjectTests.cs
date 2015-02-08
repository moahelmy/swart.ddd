using NUnit.Framework;
using Swart.DomainDrivenDesign.UnitTests.Fakes;

namespace Swart.DomainDrivenDesign.UnitTests.Domain
{
    [TestFixture]
    public class ValueObjectTests
    {
        #region SameValueObject
        [Test]
        public void Equals_SameValueObject_ReturnsTrue()
        {
            //Arrange
            var address1 = new Address(streetLine1: "streetLine1", streetLine2: "streetLine2", city: "city", zipCode: "zipcode");
            var address2 = address1;

            //Act            
            var result = address1.Equals(address2);

            //Assert
            Assert.True(result);
        }

        [Test]
        public void EqualsOperator_SameValueObject_ReturnsTrue()
        {
            //Arrange
            var address1 = new Address(streetLine1: "streetLine1", streetLine2: "streetLine2", city: "city", zipCode: "zipcode");
            var address2 = address1;

            //Act            
            var result = address1 == address2;

            //Assert
            Assert.True(result);
        }

        [Test]
        public void NotEqualsOperator_SameValueObject_ReturnsFalse()
        {
            //Arrange
            var address1 = new Address(streetLine1: "streetLine1", streetLine2: "streetLine2", city: "city", zipCode: "zipcode");
            var address2 = address1;

            //Act            
            var result = address1 != address2;

            //Assert
            Assert.False(result);
        }
        #endregion

        #region IdenticalData
        [Test]
        public void Equals_IdenticalData_ReturnsTrue()
        {
            //Arrange
            var address1 = new Address(streetLine1: "streetLine1", streetLine2: "streetLine2", city: "city", zipCode: "zipcode");
            var address2 = new Address(streetLine1: "streetLine1", streetLine2: "streetLine2", city: "city", zipCode: "zipcode");

            //Act
            var resultEquals = address1.Equals(address2);
            var resultEqualsSimetric = address2.Equals(address1);

            //Assert
            Assert.True(resultEquals && resultEqualsSimetric);
        }

        [Test]
        public void EqualsOperator_IdenticalData_ReturnsTrue()
        {
            //Arraneg
            var address1 = new Address(streetLine1: "streetLine1", streetLine2: "streetLine2", city: "city", zipCode: "zipcode");
            var address2 = new Address(streetLine1: "streetLine1", streetLine2: "streetLine2", city: "city", zipCode: "zipcode");

            //Act
            var resultEquals = (address1 == address2);
            var resultEqualsSimetric = (address2 == address1);

            //Assert            
            Assert.True(resultEquals && resultEqualsSimetric);
        }

        [Test]
        public void NotEqualsOperator_IdenticalData_ReturnsFalse()
        {
            //Arraneg
            var address1 = new Address(streetLine1: "streetLine1", streetLine2: "streetLine2", city: "city", zipCode: "zipcode");
            var address2 = new Address(streetLine1: "streetLine1", streetLine2: "streetLine2", city: "city", zipCode: "zipcode");

            //Act
            var resultEquals = (address1 != address2);
            var resultEqualsSimetric = (address2 != address1);

            //Assert
            Assert.False(resultEquals || resultEqualsSimetric);
        }       
        #endregion

        #region DiferentData
        [Test]
        public void Equals_DiferentData_ReturnsFalse()
        {
            //Arrange
            var address1 = new Address(streetLine1: "streetLine1", streetLine2: "streetLine2", city: "city", zipCode: "zipcode");
            var address2 = new Address(streetLine1: "streetLine2", streetLine2: "streetLine1", city: "city", zipCode: "zipcode");

            //Act
            var result = address1.Equals(address2);
            var resultSimetric = address2.Equals(address1);

            //Assert
            Assert.False(result || resultSimetric);            
        }

        [Test]
        public void NotEqualsOperator_DiferentData_ReturnsFalse()
        {
            //Arrange
            var address1 = new Address(streetLine1: "streetLine1", streetLine2: "streetLine2", city: "city", zipCode: "zipcode");
            var address2 = new Address(streetLine1: "streetLine2", streetLine2: "streetLine1", city: "city", zipCode: "zipcode");

            //Act
            var result = (address1 != address2);
            var resultSimetric = (address2 != address1);

            //Assert
            Assert.True(result && resultSimetric);            
        }

        [Test]
        public void EqualsOperator_DiferentData_ReturnsTrue()
        {
            //Arrange
            var address1 = new Address(streetLine1: "streetLine1", streetLine2: "streetLine2", city: "city", zipCode: "zipcode");
            var address2 = new Address(streetLine1: "streetLine2", streetLine2: "streetLine1", city: "city", zipCode: "zipcode");

            //Act
            var result = (address1 == address2);
            var resultSimetric = (address2 == address1);

            //Assert
            Assert.False(result || resultSimetric);            
        }        
        #endregion        

        #region SameDataInDiferentProperties
        [Test]
        public void Equals_SameDataInDiferentProperties_ReturnsFalse()
        {
            //Arrange
            var address1 = new Address("streetLine1", "streetLine2", null, null);
            var address2 = new Address("streetLine2", "streetLine1", null, null);

            //Act
            var result = address1.Equals(address2);
            var resultSimetric = address2.Equals(address1);

            //Assert
            Assert.False(result || resultSimetric);
        }

        [Test]
        public void EqualsOperator_SameDataInDiferentProperties_ReturnsFalse()
        {
            //Arrange
            var address1 = new Address("streetLine1", "streetLine2", null, null);
            var address2 = new Address("streetLine2", "streetLine1", null, null);

            //Act
            var result = (address1 == address2);
            var resultSimetric = (address2 == address1);

            //Assert
            Assert.False(result || resultSimetric);
        }

        [Test]
        public void NotEqualsOperator_SameDataInDiferentProperties_ReturnsTrue()
        {
            //Arrange
            var address1 = new Address("streetLine1", "streetLine2", null, null);
            var address2 = new Address("streetLine2", "streetLine1", null, null);

            //Act
            var result = (address1 != address2);
            var resultSimetric = (address2 != address1);

            //Assert
            Assert.True(result && resultSimetric);
        } 
        #endregion

        #region GetHashCode
        [Test]
        public void GetHashCode_IdenticalData_ProducesIdeniticalHashCode()
        {
            //Arrange
            var address1 = new Address(streetLine1: "streetLine1", streetLine2: "streetLine2", city: "city", zipCode: "zipcode");
            var address2 = new Address(streetLine1: "streetLine1", streetLine2: "streetLine2", city: "city", zipCode: "zipcode");

            //Act
            var hashCode1 = address1.GetHashCode();
            var hashCode2 = address2.GetHashCode();

            //Assert
            Assert.AreEqual(hashCode1, hashCode2);
        }

        [Test]
        public void GetHashCode_DiferentData_ProducesDifferentHashCode()
        {
            //Arrange
            var address1 = new Address(streetLine1: "streetLine1", streetLine2: "streetLine2", city: "city", zipCode: "zipcode");
            var address2 = new Address(streetLine1: "streetLine11", streetLine2: "streetLine21", city: "city1", zipCode: "zipcode1");

            //Act
            var hashCode1 = address1.GetHashCode();
            var hashCode2 = address2.GetHashCode();

            //Assert
            Assert.AreNotEqual(hashCode1, hashCode2);
        }

        [Test]
        public void GetHashCode_DiferentDataInDiferentProperties_ProduceDiferentHashCode()
        {
            //Arrange
            var address1 = new Address("streetLine1", "streetLine2", null, null);
            var address2 = new Address("streetLine2", "streetLine1", null, null);

            //Act
            int address1HashCode = address1.GetHashCode();
            int address2HashCode = address2.GetHashCode();


            //Assert
            Assert.AreNotEqual(address1HashCode, address2HashCode);
        }

        [Test]
        public void GetHashCode_SameDataInDiferentProperties_ProduceDiferentHashCode()
        {
            //Arrange
            var address1 = new Address("streetLine1", null, null, "streetLine1");
            var address2 = new Address(null, "streetLine1", "streetLine1", null);

            //Act
            int address1HashCode = address1.GetHashCode();
            int address2HashCode = address2.GetHashCode();


            //Assert
            Assert.AreNotEqual(address1HashCode, address2HashCode);
        }

        [Test]
        public void GetHashCode_SameData_SameHashCode()
        {
            //Arrange
            var address1 = new Address("streetLine1", "streetLine2", null, null);
            var address2 = new Address("streetLine1", "streetLine2", null, null);

            //Act
            int address1HashCode = address1.GetHashCode();
            int address2HashCode = address2.GetHashCode();


            //Assert
            Assert.AreEqual(address1HashCode, address2HashCode);
        }
        #endregion
        
        [Test]
        public void Equality_SelfReference_NotProduceInfiniteLoop()
        {
            //Arrange
            var aReference = new SelfReference();
            var bReference = new SelfReference();

            //Act
            aReference.Value = bReference;
            bReference.Value = aReference;

            //Assert
            Assert.AreNotEqual(aReference, bReference);
        }
    }
}
