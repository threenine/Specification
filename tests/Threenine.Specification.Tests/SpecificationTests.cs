using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    [Theory, Description("Single predicate specification")]
    [InlineData("Apple")]
    [InlineData("Amazon")]
    [InlineData("Google")]
    [InlineData("Spotify")]
    public void Should_Satisfy_Single_Expression(string brandName)
    {
        ISpecification<Website> Spec =
            new SingleSpecification<Website>(o => o.Brand == brandName);
        
        var result = testWebsites.FindAll(o => Spec.SatisfiedBy(o));

        result.ShouldNotBeNull();
        result.Count.ShouldBe(1);
        result[0].ShouldBeOfType<Website>();
        result.ShouldSatisfyAllConditions();
    }

    [Theory, Description("Or Clause of a composite predicate specification")]
    [InlineData("Apple", "Amazon")]
    [InlineData("Amazon", "Spotify")]
    public void Should_Satisfy_Or_Specification(string brandName1, string brandName2)
    {
        var Spec1 =
            new ExpressionSpecification<Website>(o => o.Brand == brandName1);

        var Spec2 =
            new ExpressionSpecification<Website>(o => o.Brand == brandName2);

        var result = testWebsites.FindAll(o => Spec1.Or(Spec2).SatisfiedBy(o));

        result.ShouldNotBeNull();
        result.Count.ShouldBe(2);
        result[0].ShouldBeOfType<Website>();
        result.ShouldSatisfyAllConditions();
    }
    
    [Theory, Description("Not Clause of a composite predicate specification")]
    [InlineData("music", "Amazon")]
    [InlineData("rock", "Spotify")]
    public void Should_Satisfy_Not_Specification(string tag, string brandName)
    {
        var spec1 =
            new ExpressionSpecification<Website>(o => o.Tags.Contains(tag));

        var spec2 =
            new ExpressionSpecification<Website>(o => o.Brand == brandName);

        var result = testWebsites.FindAll(o => spec1.Not(spec2).SatisfiedBy(o));

        result.ShouldNotBeNull();
        result.Count.ShouldBe(3);
        result[0].ShouldBeOfType<Website>();
        result.ShouldSatisfyAllConditions();
    }
    [Theory, Description("And Clause of a composite predicate specification")]
    [InlineData("music", "Amazon")]
    [InlineData("rock", "Spotify")]
    public void Should_Satisfy_And_Specification(string tag, string brandName)
    {
        var spec1 =
            new ExpressionSpecification<Website>(o => o.Tags.Contains(tag));

        var spec2 =
            new ExpressionSpecification<Website>(o => o.Brand == brandName);

        var result = testWebsites.FindAll(o => spec1.And(spec2).SatisfiedBy(o));

        result.ShouldNotBeNull();
        result.Count.ShouldBe(1);
        result[0].ShouldBeOfType<Website>();
        result.ShouldSatisfyAllConditions();
    }
}