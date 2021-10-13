using System.Collections.Generic;
using System.ComponentModel;
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
            testClass.Errors.ShouldBeAssignableTo<IReadOnlyCollection<string>>();
        }

        [Fact]
        public void Should_set_and_get_properties()
        {
            var testClass =
                new ListResponse<DummyListResponseClass>(Builder<DummyListResponseClass>.CreateListOfSize(10).Build())
                {
                    Page = 10,
                    PerPage = 10,
                    TotalPages = 10
                };

            testClass.Items.ShouldBeAssignableTo<IList<DummyListResponseClass>>();
            testClass.Items.Count.ShouldBe(10);
            testClass.Page.ShouldBe(10);
            testClass.PerPage.ShouldBe(10);
            testClass.TotalPages.ShouldBe(10);
            
            
        }
    }

    public class DummyListResponseClass
    {
    }
}