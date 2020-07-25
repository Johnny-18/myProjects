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
    public class CommentService : ICommentService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Create(CommentDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();

            _unitOfWork.CommentRepository.Add(_mapper.Map<Comment>(item));

            if(await _unitOfWork.SaveChangesAsync())
            {
                return true;
            }
            return false;
        }

        //public async Task<CommentDTO> Get(int id)
        //{
        //    if (id <= 0)
        //        throw new InvalidIdException("Id must be more than 0");

        //    var comment = await _unitOfWork.CommentRepository.GetById(id);
        //    return _mapper.Map<CommentDTO>(comment);
        //}

        //public async Task<IEnumerable<CommentDTO>> GetAll()
        //{
        //    var comments = await _unitOfWork.CommentRepository.GetAll();

        //    return _mapper.Map<IEnumerable<CommentDTO>>(comments);
        //}

        public async Task<bool> Remove(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Id must be more than 0");

            _unitOfWork.CommentRepository.Remove(id);
            if (await _unitOfWork.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Remove(CommentDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();

            _unitOfWork.CommentRepository.Remove(_mapper.Map<Comment>(item));
            if(await _unitOfWork.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Update(CommentDTO item)
        {
            if(item == null)
                throw new ArgumentNullException();

            _unitOfWork.CommentRepository.Update(_mapper.Map<Comment>(item));
            if (await _unitOfWork.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }

        public async Task<UserDTO> GetUser(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Id must be more than 0");

            var comment = await _unitOfWork.CommentRepository.GetById(id);
            if (comment == null)
                return null;

            return _mapper.Map<UserDTO>(comment.User);
        }
    }
}
