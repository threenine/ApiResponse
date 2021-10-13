using FizzWare.NBuilder;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace Threenine.ApiResponse.Tests
{
    public class LinkTests
    {

        [Fact]
        public void Should_have_the_default_properties()
        {
            var testLink = new Link();

            testLink.Href.ShouldBeAssignableTo<string>();
            testLink.Method.ShouldBeAssignableTo<string>();
            testLink.Rel.ShouldBeAssignableTo<string>();
        }

        [Fact]
        public void Should_serialise_to_json_with_lower_case()
        {
            var testLink = new Link();
            var serialisedLink = JsonConvert.SerializeObject(testLink);
            
            serialisedLink.ShouldContain("href");
            serialisedLink.ShouldContain("method");
            serialisedLink.ShouldContain("rel");
        }

        [Fact]
        public void Should_get_and_set_values_on_properties()
        {
            var testLink = Builder<Link>.CreateNew().Build();
            
            testLink.Href.ShouldNotBeEmpty();
            testLink.Method.ShouldNotBeEmpty();
            testLink.Rel.ShouldNotBeEmpty();
        }
    }
}