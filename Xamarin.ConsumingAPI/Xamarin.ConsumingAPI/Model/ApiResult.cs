using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.ConsumingAPI.Model
{
    public class ApiResult
    {
        public int Count { get; set; }
        public List<Nave> Results { get; set; }
    }
}
