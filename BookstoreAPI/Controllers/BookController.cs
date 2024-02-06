using BookstoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using BookstoreAPI.Repo;

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
    }
}
