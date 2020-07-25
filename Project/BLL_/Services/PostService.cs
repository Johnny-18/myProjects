using AutoMapper;
using BLL_.DTO;
using BLL_.Interfaces;
using DAL_.Entyties;
using DAL_.Exceptions;
using DAL_.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL_.Services
{
    public class PostService : IPostService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Create(PostDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();

            unitOfWork.PostRepository.Add(mapper.Map<Post>(item));
            if (await unitOfWork.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }

        public async Task<PostDTO> Get(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Id must be more than 0");

            var post = await unitOfWork.PostRepository.GetById(id);
            return mapper.Map<PostDTO>(post);
        }

        public async Task<IEnumerable<PostDTO>> GetAll()
        {
            var posts = await unitOfWork.PostRepository.GetAll();
            return mapper.Map<IEnumerable<PostDTO>>(posts);
        }

        public async Task<BlogDTO> GetBlog(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Id must be more than 0");

            var post = await Get(id);
            return post.Blog;
        }

        public async Task<IEnumerable<CommentDTO>> GetComments(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Id must be more than 0");

            var post = await unitOfWork.PostRepository.GetById(id);
            return mapper.Map<IEnumerable<CommentDTO>>(post.Comments);
        }

        public async Task<IEnumerable<ImageDTO>> GetImages(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Id must be more than 0");

            var post = await Get(id);
            return post.Images;
        }

        public async Task<IEnumerable<LikeDTO>> GetLikes(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Id must be more than 0");

            var post = await Get(id);
            return post.Likes;
        }

        public async Task<TagDTO> GetTag(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Id must be more than 0");

            var post = await Get(id);
            return post.Tag;
        }

        public async Task<bool> Remove(int id)
        {
            if(id <= 0)
                throw new InvalidIdException("Id must be more than 0");

            unitOfWork.PostRepository.Remove(id);
            if(await unitOfWork.SaveChangesAsync())
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Remove(PostDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();

            return await Remove(item.Id);
        }

        public async Task<bool> Update(PostDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();

            unitOfWork.PostRepository.Update(mapper.Map<Post>(item));
            if(await unitOfWork.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<PostDTO>> Search(string searchStr)
        {
            if (searchStr == null || searchStr == String.Empty)
                throw new ArgumentNullException();

            var filtered = new List<PostDTO>();

            var posts = await unitOfWork.PostRepository.GetAll();
            var postDTOs = mapper.Map<IEnumerable<PostDTO>>(posts);

            string searchStrModified = searchStr.ToLower().Replace(" ", "");
            foreach (var postDTO in postDTOs)
            {
                string text = postDTO.Text.ToLower().Replace(" ", "");
                string name = postDTO.Tag.Name.ToLower().Replace(" ", "");

                if (text.IndexOf(searchStrModified) != -1 || name.IndexOf(searchStrModified) != -1)
                {
                    filtered.Add(postDTO);
                }
            }

            return filtered;
        }
    }
}
