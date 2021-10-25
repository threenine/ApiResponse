using System.Collections.Generic;
using FizzWare.NBuilder;
using Shouldly;
using Xunit;

namespace Threenine.ApiResponse.Tests
{
    public class ResponseTests
    {
        [Fact]
        public void Should_have_default_properties()
        {
            var testClass = new SingleResponse<DummyResponseClass>(null);

            testClass.Item.ShouldBeAssignableTo<DummyResponseClass>();
           
        }
    }
    
    public class DummyResponseClass
    {
        
    }
}