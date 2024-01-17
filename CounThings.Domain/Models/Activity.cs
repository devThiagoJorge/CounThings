using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounThings.Domain.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool ItsCalculable { get; set; }
    }
}
