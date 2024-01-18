using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounThings.Domain.Commands.Requests
{
    public class CreateActivityRequest
    {
        public string Name { get; private set; } = "";
        public int Quantity { get; private set; }
        public double? Amount { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public bool ItsCalculable { get; private set; }
    }
}
