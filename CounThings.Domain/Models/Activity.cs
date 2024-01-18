using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounThings.Domain.Models
{
    public class Activity
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = "";
        public int Quantity { get; private set; }
        public double? Amount { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool ItsCalculable { get; private set; }

        public Activity(string name, int quantity, double amount, bool itsCalculable)
        {
            Name = name;
            Quantity = quantity;
            ItsCalculable= itsCalculable;

            if(ItsCalculable)
            {
                Amount = amount;
            }

            CreatedAt = DateTime.Now;
        }

        public void UpdateQuantity()
        {
            Quantity = Quantity  + 1;
        }
    }
}
