namespace LearnTaskCore.Features.Home
{
    using AutoMapper;
    using Domain;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, Index.Model>();
            CreateMap<ItemDocument, Download.Model.ItemDocument>();
        }
    }
}