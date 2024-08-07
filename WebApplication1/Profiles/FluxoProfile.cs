using AutoMapper;
using FluxoCaixa.DTO;
using FluxoCaixa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Profiles
{
    public class FluxoProfile : Profile
    {
        public FluxoProfile()
        {
            CreateMap<Fluxo, ReadFluxoDTO>();


            CreateMap<Fluxo, ReadFluxoDTO>().
                ForMember(fluxoDto => fluxoDto.Registros,
                opt => opt.MapFrom(fluxo => fluxo.Registros));
        }
    }
}
