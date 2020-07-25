using System;
using System.Threading.Tasks;

namespace DAL_.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogRepository BlogRepository { get; }

        ICommentRepository CommentRepository { get; }

        IImageRepository ImageRepository { get; }

        ILikeRepository LikeRepository { get; }

        IPostRepository PostRepository { get; }

        IRoleRepository RoleRepository { get; }
        ITagRepository TagRepository { get; }

        IUserRepository UserRepository { get; }
        Task<bool> SaveChangesAsync();
    }
}
