using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using FizzWare.NBuilder;
using Shouldly;
using Xunit;

namespace Threenine.ApiResponse.Tests
{
    public class ListResponseTests
    {
        [Fact]
        [Description("Ensure default properties exist on instantiated object")]
        public void Should_have_default_properties()
        {
            var testClass = new ListResponse<DummyListResponseClass>(null);

            testClass.Items.ShouldBeAssignableTo<IEnumerable<DummyListResponseClass>>();
            testClass.IsValid.ShouldBeAssignableTo<bool>();
            testClass.Page.ShouldBeAssignableTo<int>();
            testClass.PerPage.ShouldBeAssignableTo<int>();
            testClass.Errors.ShouldBeAssignableTo< IList<KeyValuePair<string, string[]>>>();
        }

        [Fact]
        public void Should_set_and_get_properties()
        {
            var testClass =
                new ListResponse<DummyListResponseClass>(Builder<DummyListResponseClass>.CreateListOfSize(100).Build().ToList())
                {
                    Page = 10,
                    PerPage = 10,
                    TotalPages = 10,
                    Size = 100
                };

            testClass.Items.ShouldBeAssignableTo<List<DummyListResponseClass>>();
            testClass.Items.Count.ShouldBe(100);
            testClass.Page.ShouldBe(10);
            testClass.PerPage.ShouldBe(10);
            testClass.TotalPages.ShouldBe(10);
            testClass.Size.ShouldBe(100);
            
            
        }
        
        [Theory, Description("Ensure ListResponse has properties defined")]
        [InlineData("Items", typeof(List<DummyListResponseClass>))]
        [InlineData("Size", typeof(int))]
        [InlineData("Page", typeof(int))]
        [InlineData("PerPage", typeof(int))]
        [InlineData("TotalPages", typeof(int))]
        [InlineData("HasPrevious", typeof(bool))]
        [InlineData("HasNext", typeof(bool))]
        public void Should_have_base_fields_defined(string name, Type type)
        {
            var testClass = typeof(ListResponse<DummyListResponseClass>);
            var prop = testClass.GetProperty(name);

            prop.ShouldSatisfyAllConditions(
                () => prop.ShouldNotBeNull(),
                () => prop?.PropertyType.ShouldBeEquivalentTo(type)
            );
        }
    }
   
    public class DummyListResponseClass
    {
        public string Name { get; set; }
        public string  last { get; set; }
    }
}