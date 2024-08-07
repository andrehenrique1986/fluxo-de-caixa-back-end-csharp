using AutoMapper;
using FluxoCaixa.DTO;
using FluxoCaixa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Profiles
{
    public class CustoProfile : Profile
    {
        public CustoProfile()
        {
            CreateMap<Custo, ReadCustoDTO>();


            CreateMap<Custo, ReadCustoDTO>().
                ForMember(custoDto => custoDto.Registros,
                opt => opt.MapFrom(custo => custo.Registros));
        }
    }
}
