using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CSharpHacks.Tests
{
    public class GenericsTests
    {
        [Fact]
        public void object_is_expected_type()
        {
            //Arrange
            var data = new GenericsHacks.ObjectOne();
            
            //Act
            var result = GenericsHacks.LimitTypeOfGeneric<GenericsHacks.ObjectOne>(data.GetType());
            
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void object_is_not_expected_type()
        {
            //Arrange
            var data = 0;

            //Act
            var result = GenericsHacks.LimitTypeOfGeneric<int>(data.GetType());

            //Assert
            Assert.False(result);
        }
    }
}
