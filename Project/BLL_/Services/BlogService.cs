using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL_.DTO;
using BLL_.Interfaces;
using DAL_.Entyties;
using DAL_.Exceptions;
using DAL_.Interfaces;

namespace BLL_.Services
{
    public class BlogService : IBlogService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        private IAuthService _authService;

        public BlogService(IUnitOfWork unitOfWork, 
            IMapper mapper,
            IAuthService auth)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            _authService = auth;
        }

        public async Task<bool> Create(BlogDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();

            var blog = mapper.Map<BlogDTO, Blog>(item);

            unitOfWork.BlogRepository.Add(blog);
            if(await _authService.AddRole(blog.User.Email, "Blogger"))
            {
                return true;
            }

            return false;
        }

        public async Task<BlogDTO> Get(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Id must be more than 0");

            var blog = await unitOfWork.BlogRepository.GetById(id);

            return mapper.Map<Blog, BlogDTO>(blog);
        }

        public async Task<IEnumerable<BlogDTO>> GetAll()
        {
            var blogs = await unitOfWork.BlogRepository.GetAll();

            return mapper.Map<IEnumerable<Blog>, IEnumerable<BlogDTO>>(blogs);
        }

        public async Task<IEnumerable<PostDTO>> GetPosts(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Id must be more than 0");

            var posts = await unitOfWork.BlogRepository.GetPosts(id);

            return mapper.Map<IEnumerable<Post>, IEnumerable<PostDTO>>(posts);
        }

        public async Task<bool> Remove(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Id must be more than 0");

            var blog = await unitOfWork.BlogRepository.GetById(id);

            unitOfWork.BlogRepository.Remove(blog);
            if (await unitOfWork.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Remove(BlogDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();

            var blog = mapper.Map<BlogDTO, Blog>(item);

            unitOfWork.BlogRepository.Remove(blog);
            if (await unitOfWork.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Update(BlogDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();

            var blog = mapper.Map<BlogDTO, Blog>(item);

            unitOfWork.BlogRepository.Update(blog);
            if(await unitOfWork.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<BlogDTO>> Search(string searchStr)
        {
            if (searchStr == null)
                throw new ArgumentNullException();

            var filtered = new List<BlogDTO>();

            var blogs = await unitOfWork.BlogRepository.GetAll();
            var blogsDTOs = mapper.Map<IEnumerable<BlogDTO>>(blogs);

            string searchStrModified = searchStr.ToLower().Replace(" ", "");
            foreach (var blogDTO in blogsDTOs)
            {
                string name = blogDTO.BlogName.ToLower().Replace(" ", "");
                if (name.IndexOf(searchStrModified) != -1 )
                {
                    filtered.Add(blogDTO);
                }
            }

            return filtered;
        }
    }
}
