using AutoMapper;
using BLL_.DTO;
using DAL_.Entyties;

namespace BLL_.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<BlogDTO, Blog>().ReverseMap();
            CreateMap<CommentDTO, Comment>().ReverseMap();
            CreateMap<ImageDTO, Image>().ReverseMap();
            CreateMap<LikeDTO, Like>().ReverseMap();
            CreateMap<PostDTO, Post>().ReverseMap();
            CreateMap<RoleDTO, Role>().ReverseMap();
            CreateMap<TagDTO, Tag>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}
