using System;
using System.Collections.Generic;

namespace Threenine.Specification.Tests;

public class Website
{
    public string Brand { get; set; }
    public string Title { get; set; }
    public Uri Url { get; set; }
    public string Description { get; set; }
    public List<string> Tags { get; set; }

    public string Category { get; set; }
}