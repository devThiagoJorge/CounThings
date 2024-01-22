using CounThings.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounThings.Infra.Repositories.Abstractions
{
    public interface IPaymentRepository
    {
        Task<ICollection<Payment>> GetAll();

        Task<Payment> GetPaymentById(int paymentId);

        Task<Payment> AddPayment(Payment toCreate);

        Task<Payment> UpdatePayment(Payment paymentUpdate);

        Task Delete(int paymentId);
    }
}
