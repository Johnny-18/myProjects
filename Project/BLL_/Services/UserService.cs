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
    public class UserService : IUserService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        public UserService (IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Create(UserDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();

            unitOfWork.UserRepository.Add(mapper.Map<UserDTO, User>(item));
            if(await unitOfWork.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }

        public async Task<UserDTO> Get(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Id must be more than 0");

            var user = await unitOfWork.UserRepository.GetById(id);

            return mapper.Map<User, UserDTO>(user);
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var users = await unitOfWork.UserRepository.GetAll();

            return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
        }

        public async Task<bool> Remove(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Id must be more than 0");

            unitOfWork.UserRepository.Remove(id);
            if(await unitOfWork.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Remove(UserDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();

            unitOfWork.UserRepository.Remove(mapper.Map<UserDTO,User>(item));
            if(await unitOfWork.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Update(UserDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();

            unitOfWork.UserRepository.Update(mapper.Map<UserDTO, User>(item));
            if(await unitOfWork.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }
    }
}
