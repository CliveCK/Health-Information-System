using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Health_Information_System.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public int SegregatedFundID { get; set; }
        public string MemberNo { get; set; }
        public int Suffix { get; set; }
        public string FirstName { get; set; }
        public string Initials { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }

        public DateTime ExpiryDate { get; set; }
        public int MemberStatusID { get; set; }
    }
}