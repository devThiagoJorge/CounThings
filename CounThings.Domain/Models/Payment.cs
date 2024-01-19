using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounThings.Domain.Models
{
    public class Payment
    {
        public int Id { get; private set; }
        public double AmountPaid { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int ActivityId { get; private set; }
        public Activity Activity { get; private set; }
    }
}
