using AutoMapper;
using SalaryProposal.Infrastructure.Identity;
using SalaryProposal.Models.Models;

namespace SalaryProposal.Infrastructure.Mapping
{
    /// <summary></summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class DataProfile : Profile
    {
        /// <summary>Initializes a new instance of the <see cref="DataProfile"/> class.</summary>
        public DataProfile()
        {
            CreateMap<Users, AppUser>().ConstructUsing(u => new AppUser { UserName = u.FirstName, Email = u.Email }).ForMember(au => au.Id, opt => opt.Ignore());
            CreateMap<AppUser, Users>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)).
                                       ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash)).
                                       ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
