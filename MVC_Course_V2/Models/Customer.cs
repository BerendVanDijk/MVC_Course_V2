using MVC_Course_V2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace MVC_Course_V2.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name ="Subscribed to Newsletter ?")]
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType Membershiptype { get; set; }
        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }
        [Display(Name="Date of Birth")]
        public DateTime? Birthdate { get; set; }

    }
    //[System.AttributeUsage(System.AttributeTargets.Class |System.AttributeTargets.Struct)]
    //public class DateTimeAttribute : System.Attribute
    //{

    //    DateTime BirthDate;
    //    public DateTimeAttribute(DateTime birthdate)
    //    {
    //        this.BirthDate = birthdate.ToString("dd/mm/yyyy");
    //    }
    //}custom attribute
}