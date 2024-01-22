using CounThings.Domain.Models;
using CounThings.Infra.Context;
using CounThings.Infra.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounThings.Infra.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ActivityContext _context;

        public PaymentRepository(ActivityContext context)
        {
            _context = context;
        }

        public async Task<Payment> AddPayment(Payment toCreate)
        {
            _context.Payments.Add(toCreate);
            await _context.SaveChangesAsync();
            return toCreate;
        }

        public async Task Delete(int paymentId)
        {

            var payment = await GetPaymentById(paymentId);

            if (payment is null) return;

            _context.Payments.Remove(payment);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Payment>> GetAll()
        {
            return await _context.Payments.AsNoTracking().ToListAsync();
        }

        public async Task<Payment> GetPaymentById(int paymentId)
        {
            return await _context.Payments
                .FirstOrDefaultAsync(p => p.Id == paymentId);
        }

        public async Task<Payment> UpdatePayment(Payment paymentUpdate)
        {
            _context.Update(paymentUpdate);
            await _context.SaveChangesAsync();

            return paymentUpdate;
        }
    }
}
