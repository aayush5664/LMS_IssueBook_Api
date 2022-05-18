using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryReact.Models
{
    public class IssueBook
    {
        [Key]
        public int IssueBookId { get; set; }
        public  string MemberID { get; set; }
        public string MemberFullName { get; set; }
        public  string BookID { get; set; }
        public string BookName { get; set; }
        public string BookIssueDate { get; set; }
        public string BookDueDate { get; set; }


    }
}
