using AutoMapper;
using BLL_.DTO;
using BLL_.Interfaces;
using DAL_.Entyties;
using DAL_.Exceptions;
using DAL_.Interfaces;
using DAL_.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL_.Services
{
    public class ImageService : IImageService
    {
        private IMapper _mapper;
        private IUnitOfWork _unit;

        public ImageService(IMapper mapper, UnitOfWork unit)
        {
            _mapper = mapper;
            _unit = unit;
        }

        public async Task<bool> Create(ImageDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();

            var image = _mapper.Map<ImageDTO, Image>(item);

            _unit.ImageRepository.Add(image);
            if (await _unit.SaveChangesAsync())
            {
                return true;
            }

            return false;

        }

        public async Task<ImageDTO> Get(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Id must be more than 0");

            var image = await _unit.ImageRepository.GetById(id);

            return _mapper.Map<Image, ImageDTO>(image);
        }

        public async Task<IEnumerable<ImageDTO>> GetAll()
        {
            var images = await _unit.ImageRepository.GetAll();

            return _mapper.Map<IEnumerable<Image>, IEnumerable<ImageDTO>>(images);
        }

        public async Task<UserDTO> GetUser(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Id must be more than 0");

            var image = await _unit.ImageRepository.GetById(id);

            return _mapper.Map<User, UserDTO>(image.User);
        }

        public async Task<bool> Remove(int id)
        {
            if (id <= 0)
                throw new InvalidIdException("Id must be more than 0");

            var image = await _unit.ImageRepository.GetById(id);

            _unit.ImageRepository.Remove(image);
            if (await _unit.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Remove(ImageDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();

            var image = _mapper.Map<ImageDTO, Image>(item);

            _unit.ImageRepository.Remove(image);
            if (await _unit.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Update(ImageDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();

            var image = _mapper.Map<ImageDTO, Image>(item);

            _unit.ImageRepository.Update(image);
            if (await _unit.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }
    }
}
