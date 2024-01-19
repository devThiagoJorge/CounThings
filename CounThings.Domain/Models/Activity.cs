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
        public double Total { get; private set; } = 0;
        public DateTime CreatedAt { get; private set; }
        public bool ItsCalculable { get; private set; }
        public ICollection<Payment>? Payments { get; }


        public Activity(string name, bool itsCalculable)
        {
            int firstCreation = 1;

            Name = name;
            Quantity = firstCreation;
            ItsCalculable= itsCalculable;
            CreatedAt = DateTime.Now;
        }

        public void UpdateQuantityActivity(bool addNew)
        {
            if (addNew)
                Quantity++;
            else
                Quantity--;
        }
    }
}
