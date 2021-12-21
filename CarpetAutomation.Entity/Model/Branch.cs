using System;
using System.Collections.Generic;
using System.Text;

namespace CarpetAutomation.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public string Address { get; set; }
        public Company Company { get; set; }
    }
}
