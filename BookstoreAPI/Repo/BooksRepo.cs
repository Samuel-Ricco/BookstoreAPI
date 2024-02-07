using BookstoreAPI.Data;
using BookstoreAPI.Models;
using Dapper;
using System.Data;

namespace BookstoreAPI.Repo
{
    public class BooksRepo : IBooksRepo
    {
        private readonly DapperDbContext ctx;
        public BooksRepo(DapperDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<string> Create(Book book)
        {
            string response = string.Empty;
            string query = "INSERT INTO books(title, description, author, releaseYear, isAvailable)" +
                                "values (@title, @description, @author, @releaseYear, @isAvailable) ";
            var parameters = new DynamicParameters();
            parameters.Add("title", book.Title, DbType.String);
            parameters.Add("description", book.Description, DbType.String);
            parameters.Add("author", book.Author, DbType.String);
            parameters.Add("releaseYear", book.ReleaseYear, DbType.Int16);
            parameters.Add("isAvailable", book.IsAvailabe, DbType.Boolean);
            using (var connection = this.ctx.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }

        public async Task<string> Delete(int id)
        {
            string response = string.Empty;
            string query = "DELETE FROM books WHERE id = @id";
            using (var connection = this.ctx.CreateConnection())
            {
                var book = await connection.ExecuteAsync(query, new { id });
                response = "pass";
            }
            return response;
        }

        public async Task<List<Book>> GetAll()
        {
            string query = "SELECT * FROM books";
            using (var connection = this.ctx.CreateConnection())
            {
                var booksList = await connection.QueryAsync<Book>(query);
                return booksList.ToList();
            }
        }

        public async Task<Book> GetById(int id)
        {
            string query = "SELECT * FROM books WHERE id = @id";
            using (var connection = this.ctx.CreateConnection())
            {
                var book = await connection.QueryFirstOrDefaultAsync<Book>(query, new { id });
                return book;
            }
        }

        public async Task<string> Update(Book book, int id)
        {
            string response = string.Empty;
            string query = "UPDATE TABLA books SET title= @title, description=@description, author=@author, releaseYear=@releaseYear, isAvailable=@isAvailable";
            var parameters = new DynamicParameters();

            parameters.Add("id", id, DbType.Int16);
            parameters.Add("title", book.Title, DbType.String);
            parameters.Add("description", book.Description, DbType.String);
            parameters.Add("author", book.Author, DbType.String);
            parameters.Add("releaseYear", book.ReleaseYear, DbType.Int16);
            parameters.Add("isAvailable", book.IsAvailabe, DbType.Boolean);
            using (var connection = this.ctx.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }
    }
}
