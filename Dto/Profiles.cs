using AutoMapper;
using HomeBiuld.Model;

namespace HomeBiuld.Dto
{
    public class Profiles:Profile
    {
        public Profiles()
        {
            CreateMap<Tv, TvDto>();
            CreateMap<TvDto, Tv>();

            CreateMap<RoomDto, Room>();
            CreateMap<Room, RoomDto>();
            
            CreateMap<BedDto, Bad>();
            CreateMap<Bad, BedDto>();

        }
    }
}
