using System.Collections.Generic;

namespace Xamarin.ConsumingAPI.Model
{
    public class ApiResult
    {
        public int Count { get; set; }
        public List<Nave> Results { get; set; }
    }
}
