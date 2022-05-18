using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LibraryReact.Models;

namespace LibraryReact.Services
{
    public interface IIssueBooksServices
    {
        Task<IEnumerable<IssueBook>> GetIssueBooks();
        Task<IssueBook> GetIssueBookById(int issuebookObj);
        Task<IssueBook> UpdateIssueBook(IssueBook issuebookObj);
        Task<IssueBook> CreateIssueBook(IssueBook issuebookObj);
        Task<IssueBook> DeleteIssueBook(int issuebookObj);

    }
}