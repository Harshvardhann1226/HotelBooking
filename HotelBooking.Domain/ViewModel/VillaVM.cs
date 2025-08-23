using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.ViewModel
{
    public class VillaVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Price { get; set; }
        public string? Sqft { get; set; }
        public string? Occupency { get; set; }
        public string? ImageUrl { get; set; }
    }
}
