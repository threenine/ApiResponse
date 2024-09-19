using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Shouldly;
using Xunit;

namespace Threenine.ApiResponse.Tests;

public class OperationResultTests
{
    [Fact]
    [Description("Ensure default properties exist on instantiated object")]
    public void Should_have_successful_result()
    {
        var result = CreateOperationResult();

        var poo = result.Match<TestPoco>(onSuccess: pass => pass.ShouldBeOfType<TestPoco>(), onFailure: fail => null);

        poo.FirstName.ShouldBe("John");
        poo.LastName.ShouldBe("Smith");
    }

    [Fact]
    [Description("Ensure default properties exist on instantiated object")]
    public void Should_have_unsuccessful_result()
    {
        var result = CreateError("error");

        List<string> errors = [];
        var error = result.Match<TestPoco>(
            onSuccess: pass => null,
            onFailure: fail =>
            {
                errors = fail;
                return null;
            }
        );

        errors.ShouldNotBeEmpty();
        errors.ShouldContain("error");
    }

    private static OperationResult<TestPoco> CreateOperationResult()
    {
        return new OperationResult<TestPoco>(new TestPoco() { FirstName = "John", LastName = "Smith" });
    }

    private static OperationResult<TestPoco> CreateError(params string[] values)
    {
        return new OperationResult<TestPoco>(null,
            values.ToList());
    }
}