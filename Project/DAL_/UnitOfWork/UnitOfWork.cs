using System;
using System.Threading.Tasks;
using DAL_.Context;
using DAL_.Interfaces;
using DAL_.Reposytories;

namespace DAL_.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext context;
        private IBlogRepository blogRepository;
        private ICommentRepository commentRepository;
        private IImageRepository imageRepository;
        private ILikeRepository likeRepository;
        private IPostRepository postRepository;
        private IRoleRepository roleRepository;
        private ITagRepository tagRepository;
        private IUserRepository userRepository;

        private bool dispose = false;

        public UnitOfWork(BlogContext context)
        {
            this.context = context;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public IBlogRepository BlogRepository
        {
            get
            {
                return blogRepository = blogRepository ?? new BlogRepository(context);
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                return commentRepository = commentRepository ?? new CommentRepository(context);
            }
        }

        public IImageRepository ImageRepository
        {
            get
            {
                return imageRepository = imageRepository ?? new ImageRepository(context);
            }
        }

        public ILikeRepository LikeRepository
        {
            get
            {
                return likeRepository = likeRepository ?? new LikeRepository(context);
            }
        }

        public IPostRepository PostRepository
        {
            get
            {
                return postRepository = postRepository ?? new PostRepository(context);
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                return roleRepository = roleRepository ?? new RoleRepository(context);
            }
        }

        public ITagRepository TagRepository
        {
            get
            {
                return tagRepository = tagRepository ?? new TagRepository(context);
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return userRepository = userRepository ?? new UserRepository(context);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispose)
        {
            if (!this.dispose)
            {
                if (dispose)
                {
                    context.Dispose();
                }
            }

            dispose = true;
        }
    }
}
