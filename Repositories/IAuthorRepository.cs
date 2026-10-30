using _02.Models;

namespace _02.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task<Author?> GetByFullNameAsync(string firstName, string lastName);
        Task AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task DeleteAsync(int id);

        Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId);
    }
}