using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        //public string PasswordConfirmed { get; set; }
        public string Role { get; set;}
        public float Balance { get; set; }
        //public bool IsStudent { get; set; }
        //public bool IsTeacher { get; set; }
        public List<PaymentDTO> ReceivedPayments { get; set; }
        public List<PaymentDTO> PaidPayments { get; set; }
        public List<TopicDTO> Topics { get; set; }
        public DepartmentDTO Department { get; set; }
        public EducationLevelDTO EducationLevel { get; set; }
        public List<ReviewDTO> SubmittedReviews { get; set; }
        public List<ReviewDTO> TeacherReviews { get; set; }

    }
}
