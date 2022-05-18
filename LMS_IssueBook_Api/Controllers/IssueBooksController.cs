using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryReact.Services;
using LibraryReact.Models;
using System;
using Microsoft.AspNetCore.Http;

namespace LibraryReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueBooksController : ControllerBase
    {
        private readonly IIssueBooksServices _ibookServices;

        public IssueBooksController(IIssueBooksServices ibookServices)
        {
            _ibookServices = ibookServices;
        }

        [HttpGet("GetIssueBooks/")]
        public async Task<ActionResult<IEnumerable<IssueBook>>> GetIssueBooks()
        {
            try
            {
                return (await _ibookServices.GetIssueBooks()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetIssueBookById/{id}")]
        public async Task<ActionResult<IssueBook>> GetIssueBookById(int id)
        {

            try
            {
                var result = await _ibookServices.GetIssueBookById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("CreateIssueBook/")]
        public async Task<ActionResult<IssueBook>> CreateIssueBook(IssueBook issuebookObj)
        {
            string message = "faild";
            try
            {
                if (issuebookObj == null)
                    return BadRequest();

                var createibook = await _ibookServices.CreateIssueBook(issuebookObj);
                if (createibook != null)
                {
                    message = "success";
                }
                else
                {
                    message = "faild";
                }
            }
            catch (Exception)
            {
                return Ok(message);
            }
            return Ok(message);
        }

        [HttpPut("UpdateIssueBook/")]
        public async Task<ActionResult<IssueBook>> UpdateIssueBook(IssueBook issuebookObj)
        {
            string message = "";
            try
            {
                if (issuebookObj.IssueBookId != issuebookObj.IssueBookId)
                {
                    return BadRequest();
                }
                var employeeToUpdate = await _ibookServices.UpdateIssueBook(issuebookObj);

                if (employeeToUpdate == null)
                {
                    message = "faild";
                }
                else
                {
                    await _ibookServices.UpdateIssueBook(issuebookObj);
                    message = "success";
                }



            }
            catch (Exception)
            {
                return Ok(message);
            }
            return Ok(message);
        }

        [HttpDelete("DeleteIssueBook/{id}")]
        public async Task<ActionResult<IssueBook>> DeleteIssueBook(int id)
        {
            string message = "";
            try
            {
                var ibookdelete = await _ibookServices.GetIssueBookById(id);

                if (ibookdelete == null)
                {
                    message = "faild";
                }
                else
                {
                    await _ibookServices.DeleteIssueBook(id);
                    message = "success";
                }

            }
            catch (Exception)
            {
                return Ok(message);
            }
            return Ok(message);
        }

    }
}
