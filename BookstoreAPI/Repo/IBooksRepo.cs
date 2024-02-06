using BookstoreAPI.Models;

namespace BookstoreAPI.Repo
{
    public interface IBooksRepo
    {
        Task<List<Book>> GetAll();
    }
}

