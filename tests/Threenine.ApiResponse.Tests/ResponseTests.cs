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
            var testClass = new Response<DummyResponseClass>(null);

            testClass.Item.ShouldBeAssignableTo<DummyResponseClass>();
            testClass.Links.ShouldBeAssignableTo<IEnumerable<Link>>();
        }

        [Fact]
        public void Should_return_links_list()
        {
            var testClass = new  Response<DummyResponseClass>(null)
            {
                Links = Builder<Link>.CreateListOfSize(4).Build()
                
            };

            testClass.Links.ShouldBeAssignableTo<IList<Link>>();
            testClass.Links.Count.ShouldBe(4);
        }
    }
    
    public class DummyResponseClass
    {
        
    }
}