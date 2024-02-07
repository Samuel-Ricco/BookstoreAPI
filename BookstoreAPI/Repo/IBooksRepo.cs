using BookstoreAPI.Models;

namespace BookstoreAPI.Repo
{
    public interface IBooksRepo
    {
        Task<List<Book>> GetAll();
        Task<Book> GetById(int id);
        Task<string> Create(Book book);
        Task<string> Update(Book book, int id);
        Task<string> Delete(int id);

    }
}

