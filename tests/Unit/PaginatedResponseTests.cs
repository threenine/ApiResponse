using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using FizzWare.NBuilder;
using Shouldly;
using Xunit;

namespace Threenine.ApiResponse.Tests
{
    public class PaginatedResponseTests
    {
        [Fact]
        [Description("Ensure default properties exist on instantiated object")]
        public void Should_have_default_properties()
        {
            var testClass = new PaginatedResponse<TestPoco>(null);

            testClass.Items.ShouldBeAssignableTo<IEnumerable<TestPoco>>();
            testClass.IsValid.ShouldBeAssignableTo<bool>();
            testClass.Page.ShouldBeAssignableTo<int>();
            testClass.PerPage.ShouldBeAssignableTo<int>();
            testClass.Errors.ShouldBeAssignableTo< IList<KeyValuePair<string, string[]>>>();
        }

        [Fact]
        public void Should_set_and_get_properties()
        {
            var testClass =
                new PaginatedResponse<TestPoco>(Builder<TestPoco>.CreateListOfSize(100).Build().ToList())
                {
                    Page = 10,
                    PerPage = 10,
                    Total = 10,
                    Size = 100
                };

            testClass.Items.ShouldBeAssignableTo<List<TestPoco>>();
            testClass.Items.Count.ShouldBe(100);
            testClass.Page.ShouldBe(10);
            testClass.PerPage.ShouldBe(10);
            testClass.Total.ShouldBe(10);
            testClass.Size.ShouldBe(100);
            
            
        }
        
        [Theory, Description("Ensure PaginatedResponse has properties defined")]
        [InlineData("Items", typeof(IReadOnlyList<TestPoco>))]
        [InlineData("Size", typeof(int))]
        [InlineData("Page", typeof(int))]
        [InlineData("PerPage", typeof(int))]
        [InlineData("Total", typeof(int))]
        [InlineData("HasPrevious", typeof(bool))]
        [InlineData("HasNext", typeof(bool))]
        public void Should_have_base_fields_defined(string name, Type type)
        {
            var testClass = typeof(PaginatedResponse<TestPoco>);
            var prop = testClass.GetProperty(name);

            prop.ShouldSatisfyAllConditions(
                () => prop.ShouldNotBeNull(),
                () => prop?.PropertyType.ShouldBeEquivalentTo(type)
            );
        }
    }
   
   
}