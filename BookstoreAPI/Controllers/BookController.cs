using BookstoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using BookstoreAPI.Repo;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBooksRepo _booksRepo;
        public BookController(IBooksRepo booksRepo)
        {
            this._booksRepo = booksRepo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var books = await _booksRepo.GetAll();
            if (books != null)
            {
                return Ok(books);
            }
            else { return NotFound(); }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _booksRepo.GetById(id);
            if (book != null)
            {
                return Ok(book);
            }
            else { return NotFound(); }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Book book)
        {
            var result = await _booksRepo.Create(book);

            if (result == "pass")
            {
                return Ok("Book created successfully");
            }
            else
            {
                return BadRequest("Failed to create book");
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Book book, int id)
        {
            var result = await _booksRepo.Update(book, id);

            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _booksRepo.Delete(id);

            if (result == "pass")
            {
                return Ok("Book deleted successfully");
            }
            else
            {
                return NotFound("Failed to delete book");
            }
        }
    }
}
