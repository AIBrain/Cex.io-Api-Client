using System;
using System.Linq;

namespace Nextmethod.Cex
{
    using Entities;

    /// <summary>
    /// Marker interface for Extension Methods
    /// </summary>
    internal interface ICexClient
    {

        ApiCredentials Credentials { get; set; }

        Func<Uri> BasePathFactory { get; }
        
        TimeSpan? Timeout { get; set; }

    }
}
