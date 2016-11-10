using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Health_Information_System.Models
{

    public enum Gender
    {
        Male,
        Female,
    }

    public enum Title
    {
        Mr,
        Mrs,
        Ms,
        Miss,
        Dr,
        Professor,
        Rev
    }

    public enum MaritaStatus
    {
        Single,
        Engaged,
        Married,
        Divorced,
        CommonLaw,
        Seperated,
        Widowed
    }

    public enum Race
    {
        African,
        Caucasian,
        Asian,
        Indian
    }

    public enum MemberStatus
    {
        Active = 1,
        Suspended = 2,
        Resigned = 3,
        Deleted = 4,
        AwaitingActivation = 5,
        AwaitingApproval = 6 
    }
    public class Members
    {
        [Key]
        public int MemberId { get; set; }
        [ForeignKey("SegregatedFundID")]
        public virtual SegregatedFunds segregatedFunds { get; set; }
        public int SegregatedFundID { get; set; }
        public MemberStatus MemberStatusID { get; set; }
        [Display(Name = "Member #")]
        public string MemberNo { get; set; }
        public int Suffix { get; set; }
        public Title Title { get; set; }
        [Required]
        [Display (Name ="First Name")]
        public string FirstName { get; set; }
        public string Initials { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        public Gender Sex { get; set; }
        [Display(Name = "Marital Status")]
        public MaritaStatus MaritalStatus { get; set; }
        public Race Race { get; set; }
        [Required]
        [Display(Name = "Date Of Joining")]
        public DateTime DateOfJoining { get; set; }
        [Display(Name = "Expiry Date")]
        public DateTime? ExpiryDate { get; set; }
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        public string Occupation { get; set; }
        [Required]
        [Display(Name = "NationalID #")]
        public int NationalIDNo { get; set; }
        [NotMapped]
        public int? Age { get; set; }

        [ForeignKey("BillingGroupID")]
        public virtual BillingGroup billingGroup { get; set; }        
        public int BillingGroupID { get; set; }
        public int CompanyID { get; set; }
        public int ParentID { get; set; }
        public bool IsDependant { get; set; }       
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class SegregatedFunds
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Name { get; set; }
    }

    public class BillingGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal AgeMin { get; set; }
        public decimal AgeMax { get; set; }
    }

    public class Nationalities
    {
        public int NationalityId { set; get; }
        public string Name { get; set; }
    }
}