using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PaymentDTO
    {
        public int PaymentnId { get; set; }
        public UserDTO Teacher { get; set; }
        public UserDTO Student { get; set; }
        public float Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
