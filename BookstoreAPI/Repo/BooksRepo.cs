using BookstoreAPI.Data;
using BookstoreAPI.Models;
using Dapper;

namespace BookstoreAPI.Repo
{
    public class BooksRepo : IBooksRepo
    {
        private readonly DapperDbContext ctx;
        public BooksRepo(DapperDbContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<List<Book>> GetAll()
        {
            string query = "SELECT * FROM books";
            using(var connection = this.ctx.CreateConnection())
            {
                var booksList = await connection.QueryAsync<Book>(query);
                return booksList.ToList();
            }
        }
    }
}
