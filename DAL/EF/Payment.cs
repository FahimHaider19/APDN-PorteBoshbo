//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public Nullable<int> TeacherId { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<double> Amount { get; set; }
        public string PaymentMethod { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
