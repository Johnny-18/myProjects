using AutoMapper;
using BLL_.DTO;
using BLL_.Interfaces;
using DAL_.Entyties;
using DAL_.Exceptions;
using DAL_.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL_.Services
{
    public class LikeService : ILikeService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        public LikeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> DeleteLike(int userId, int postId)
        {
            var likes = await unitOfWork.LikeRepository.GetAll();
            var like = likes.Where(s => s.User_Id == userId && s.Post_Id == postId).FirstOrDefault();
            if(like == null)
            {
                throw new LikeException("Like don't exsist.");
            }

            unitOfWork.LikeRepository.Remove(like);

            return await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> SetLike(int userId, int postId)
        {
            var likes = await unitOfWork.LikeRepository.GetAll();
            var like = likes.Where(s => s.User_Id == userId && s.Post_Id == postId).FirstOrDefault();
            if(like != null)
            {
                throw new LikeException("Like already exsist.");
            }

            Like newLike = new Like
            {
                User_Id = userId,
                Post_Id = postId
            };

            unitOfWork.LikeRepository.Add(newLike);
            return await unitOfWork.SaveChangesAsync();
        }
    }
}
