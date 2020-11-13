using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAzureDevOps01Api
{
    public static class GlobalVariables
    {
        public static ConcurrentDictionary<string, int> votes = new ConcurrentDictionary<string, int>(new Dictionary<string, int>() { { "Pizza", 1 }, { "Burger", 1 }, { "Sandwitch", 1 }, { "Tortillas", 1 } });
    }
}
