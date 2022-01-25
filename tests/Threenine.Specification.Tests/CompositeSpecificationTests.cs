using System;
using System.Collections.Generic;
using Xunit;

namespace Threenine.Specification.Tests;

public class CompositeSpecificationTests
{

    [Fact]
    public void Should_Get_From_CompositeSpecification()
    {
     //   var spec = new CompositeSpecification<Website>();
        
    }
    
    
    

    private List<Website> TestWebsites => new List<Website>
    {
        new()
        {
            Brand = "Spotify",
            Description = "Music Streaming service",
            Tags = new List<string> { "music", "podcasts", },
            Title = "Spotify",
            Url = new Uri("https://spotify.com"),
            Category = "Streaming"
        },
        new()
        {
            Brand = "Podbean",
            Description = "Podcast streaming service",
            Tags = new List<string> { "podcasts" },
            Title = "Podbean.com",
            Url = new Uri("https://podbean.com"),
            Category = "Streaming"
        },
        new()
        {
            Brand = "Netflix",
            Description = "Movie Streaming service",
            Tags = new List<string> { "movies", "videos", "documentaries" },
            Title = "Netflix",
            Url = new Uri("https://netflix.com"),
            Category = "Streaming"
        },
        new()
        {
            Brand = "Amazon",
            Description = "Music Streaming service",
            Tags = new List<string> { "music" },
            Title = "Amazon music",
            Url = new Uri("https://music.amazon.com"),
            Category = "Streaming"
        },
        new()
        {
            Brand = "RSS",
            Description = "Podcast streaming service",
            Tags = new List<string> { "podcasts" },
            Title = "RSS.com",
            Url = new Uri("https://rss.com"),
            Category = "Streaming"
        }
    };
}