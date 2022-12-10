using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal static class PaymentService
    {
        public static List<PaymentDTO> Get()
        {
            var payments = new List<PaymentDTO>();
            var paymentdb = DataAccessFactory.PaymentDataAccess().GetAll();
            foreach (var payment in paymentdb)
            {
                payments.Add(new PaymentDTO()
                {
                    PaymentId = payment.PaymentId,
                    Amount = (double)payment.Amount,
                    PaymentMethod = payment.PaymentMethod,
                    Teacher = UserService.Get((int)payment.TeacherId),
                    Student = UserService.Get((int)payment.StudentId)

                });
            }
            return payments;
        }
        public static PaymentDTO Get(int id)
        {
            var paymentdb = DataAccessFactory.PaymentDataAccess().Get(id);
            var payment = new PaymentDTO()
            {
                PaymentId = paymentdb.PaymentId,
                Amount = (double)paymentdb.Amount,
                PaymentMethod = paymentdb.PaymentMethod,
                Teacher = UserService.Get((int)paymentdb.TeacherId),
                Student = UserService.Get((int)paymentdb.StudentId)
            };
            return payment;
        }
        public static bool Add(PaymentDTO payment)
        {
            var paymentdb = new Payment()
            {
                PaymentId = payment.PaymentId,
                Amount = (double)payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                TeacherId= payment.Teacher.UserId,
                StudentId = payment.Student.UserId,
            };
            return DataAccessFactory.PaymentDataAccess().Add(paymentdb);
        }
        public static bool Update(PaymentDTO payment)
        {
            var paymentdb = DataAccessFactory.PaymentDataAccess().Get(payment.PaymentId);
            paymentdb.Amount = (double)payment.Amount;
            paymentdb.PaymentMethod = payment.PaymentMethod;
            paymentdb.TeacherId = payment.Teacher.UserId;
            paymentdb.StudentId = payment.Student.UserId;
            paymentdb.PaymentMethod = payment.PaymentMethod;
            paymentdb.TeacherId = payment.Teacher.UserId;
            paymentdb.StudentId = payment.Student.UserId;

            return DataAccessFactory.PaymentDataAccess().Add(paymentdb);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.PaymentDataAccess().Remove(id);
        }
    }
}
