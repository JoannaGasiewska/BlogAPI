using BlogAPI.BusinessLogic.Posts.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlogAPI.BusinessLogic.Posts.Repositories
{
    public class AuthorRepository: IAuthorRepository
    {
        private readonly BlogDataContext _unitOfWork;

        public AuthorRepository(BlogDataContext dataContext)
        {
            _unitOfWork = dataContext;
        }

        public async Task<Author> GetAuthorAsync(int id)
        {
            return await _unitOfWork.Author.FindAsync(id);
        }
    }
}
