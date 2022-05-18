using LibraryReact.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Linq;

namespace LibraryReact.Services
{
    public class IssueBooksServices : IIssueBooksServices
    {
        public static readonly List<IssueBook> issueBooks = new List<IssueBook>()
        {
            new IssueBook {IssueBookId=1,MemberID="M101",MemberFullName="Akash",BookID="B101",BookName="C#",BookIssueDate="10/02/2021",BookDueDate="10/03/2021" },
            new IssueBook {IssueBookId=2,MemberID="M102",MemberFullName="Aayush",BookID="B102",BookName="C++",BookIssueDate="10/03/2021",BookDueDate="10/04/2021" },
        };

        public async Task<IEnumerable<IssueBook>> GetIssueBooks()
        {
            return issueBooks;

        }

        public async Task<IssueBook> GetIssueBookById(int issuebookObj)
        {
            return issueBooks.SingleOrDefault(c => c.IssueBookId == issuebookObj);
        }


        public async Task<IssueBook> CreateIssueBook(IssueBook issuebookObj)
        {
            issueBooks.Add(issuebookObj);
            return issuebookObj;

        }

        public async Task<IssueBook> UpdateIssueBook(IssueBook issuebookObj)
        {
            var result = issueBooks.Find(c => c.IssueBookId == issuebookObj.IssueBookId);

            if (result != null)
            {
                result.MemberID = issuebookObj.MemberID;
                result.MemberFullName = issuebookObj.MemberFullName;
                result.BookID = issuebookObj.BookID;
                result.BookName = issuebookObj.BookName;
                result.BookIssueDate = issuebookObj.BookIssueDate;
                result.BookDueDate = issuebookObj.BookDueDate;

                return result;
            }

            return null;

            

        }

        public async Task<IssueBook> DeleteIssueBook(int issuebookObj)
        {
            var result = issueBooks.Find(c => c.IssueBookId == issuebookObj);
            if (result != null)
            {
                issueBooks.Remove(result);

            }
            return result;
        }
    }
}
