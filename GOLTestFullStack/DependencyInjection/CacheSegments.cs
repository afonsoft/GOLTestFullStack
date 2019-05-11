using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace GOLTestFullStack.Api.DependencyInjection
{
    public class CacheSegments
    {

        private readonly IMemoryCache _cache;

        public CacheSegments(IMemoryCache cache)
        {
            _cache = cache;
        }

    }
}
