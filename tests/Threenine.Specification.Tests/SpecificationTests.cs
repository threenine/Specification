using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace Threenine.Specification.Tests;

public class SpecificationTests
{

    private readonly List<Website> testWebsites;

    public SpecificationTests()
    {
        testWebsites = new List<Website>
        {
            new()
            {
                Brand = "Spotify",
                Description = "Music Streaming service",
                Tags = new List<string> { "music", "rock" },
                Title = "Spotify",
                Url = new Uri("https://spotify.com")
            },
            new()
            {
                Brand = "Apple",
                Description = "Music Streaming service",
                Tags = new List<string> { "music", "rock" },
                Title = "Apple Music",
                Url = new Uri("https://music.apple.com")
            },
            new()
            {
                Brand = "Google",
                Description = "Music Streaming service",
                Tags = new List<string> { "music", "rock" },
                Title = "Google Play Music",
                Url = new Uri("https://play.google.com")
            },
            new()
            {
                Brand = "Amazon",
                Description = "Music Streaming service",
                Tags = new List<string> { "music", "rock" },
                Title = "Amazon music",
                Url = new Uri("https://music.amazon.com")
            }
        };
        
    }

    [Theory]
    [InlineData("Apple")]
    [InlineData("Amazon")]
    [InlineData("Google")]
    [InlineData("Spotify")]
    public void Should_Satisfy_Search(string brandName)
    {
        ISpecification<Website> Spec =
            new ExpressionSpecification<Website>(o => o.Brand == brandName);
        
        var result = testWebsites.FindAll(o => Spec.SatisfiedBy(o));

        result.ShouldNotBeNull();
        result.Count.ShouldBe(1);
        result[0].ShouldBeOfType<Website>();
        result.ShouldSatisfyAllConditions();

    }
   
}