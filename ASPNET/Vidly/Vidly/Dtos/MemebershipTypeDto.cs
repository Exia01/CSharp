using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MemebershipTypeDto
    {
        // lightweight, only adding the bare information that we need. can create a route if needed
        public byte Id { get; set; }
        public string Name { get; set; }
        public byte DiscountRate { get; set; }
    }
}