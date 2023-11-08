namespace Goods.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GoodsAddDto, Goods>()
                .ForMember(dest => dest.CreatedAt,
                    opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Goods, GoodsGetDto>();

            CreateMap<Group, GroupDto>();

            CreateMap<GoodsEditDto, Student>()
                .ForMember(dest => dest.UpdatedAt,
                    opt => opt.MapFrom(src => DateTime.Now));

            //CreateMap<FingerprintBase, FingerprintDto>()
            //    .ForMember(dest => dest.FingerprintId,
            //        opt => opt.MapFrom(src => src.FprtId));
        }
    }
}
