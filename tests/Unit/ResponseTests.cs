using System;
using System.ComponentModel;
using Shouldly;
using Xunit;

namespace Threenine.ApiResponse.Tests;

public class ResponseTests
{
    [Theory, Description("Ensure Response has properties defined")]
    [InlineData("Item", typeof(TestClass))]
    public void Should_have_base_fields_defined(string name, Type type)
    {
        var testClass = typeof(Response<TestClass>);
        var prop = testClass.GetProperty(name);

        prop.ShouldSatisfyAllConditions(
            () => prop.ShouldNotBeNull(),
            () => prop?.PropertyType.ShouldBeEquivalentTo(type)
        );
    }
}

public class TestClass
{
}