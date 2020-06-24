using System;
using System.Collections.Generic;
using System.Text;

namespace HildenCo.Core.Contracts
{
    public class ProductInfoRequest
    {
        public string Slug { get; set; }

        // simulate a fake delay from the remote service
        public int Delay { get; set; }
    }
}
