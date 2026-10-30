using _02.DTOs;
using _02.Models;
using _02.Repositories;

namespace _02.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AuthorService(IAuthorRepository authorRepository, IWebHostEnvironment webHostEnvironment)
        {
            _authorRepository = authorRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            return authors.Select(a => new AuthorDto
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Nationality = a.Nationality,
                ImagePath = a.ImagePath
            });
        }

        public async Task<AuthorDto?> GetByIdAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null) return null;

            return new AuthorDto
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Nationality = author.Nationality,
                ImagePath = author.ImagePath
            };
        }

        public async Task<AuthorDto> CreateAsync(CreateAuthorWithFileDto dto)
        {
            var author = new Author
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Biography = dto.Biography,
                DateOfBirth = dto.DateOfBirth,
                Nationality = dto.Nationality
            };

            if (dto.ImageFile != null)
            {
                author.ImagePath = await SaveImage(dto.ImageFile);
            }

            await _authorRepository.AddAsync(author);

            return new AuthorDto
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Nationality = author.Nationality,
                ImagePath = author.ImagePath
            };
        }

        public async Task<bool> UpdateAsync(int id, CreateAuthorWithFileDto dto)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null) return false;

            author.FirstName = dto.FirstName;
            author.LastName = dto.LastName;
            author.Biography = dto.Biography;
            author.DateOfBirth = dto.DateOfBirth;
            author.Nationality = dto.Nationality;

            if (dto.ImageFile != null)
            {
                if (!string.IsNullOrEmpty(author.ImagePath))
                {
                    DeleteImage(author.ImagePath);
                }
                author.ImagePath = await SaveImage(dto.ImageFile);
            }

            await _authorRepository.UpdateAsync(author);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null) return false;

            if (!string.IsNullOrEmpty(author.ImagePath))
            {
                DeleteImage(author.ImagePath);
            }

            await _authorRepository.DeleteAsync(id);
            return true;
        }


        private async Task<string> SaveImage(IFormFile imageFile)
        {
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;

            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "authors");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return "/images/authors/" + uniqueFileName;
        }

        private void DeleteImage(string imagePath)
        {
            string fullPath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath.TrimStart('/'));
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }
    }
}