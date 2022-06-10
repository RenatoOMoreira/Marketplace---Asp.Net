using AutoMapper;
using ExpoCenter.Mvc.Models;
using ExpoCenterDominio.Entidades;

namespace ExpoCenter.Mvc.Mapping
{
    public class ViewModelProfile : Profile

    {
        public ViewModelProfile()
        {
            CreateMap<Participante, ParticipanteViewModel>().ReverseMap();
            CreateMap<Evento, EventoViewModel>().ReverseMap();
        }
    }
}
