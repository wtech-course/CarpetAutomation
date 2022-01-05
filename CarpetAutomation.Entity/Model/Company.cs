using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarpetAutomation.Entities
{
    public class Company
    {
        public Company()
        {
            Branchs = new Collection<Branch>();
        }
        public int Id { get; set; }
        public int CompanyNumber { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<Branch> Branchs { get; set; }
    }
}
