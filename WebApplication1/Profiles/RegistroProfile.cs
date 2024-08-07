using AutoMapper;
using FluxoCaixa.DTO;
using FluxoCaixa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Profiles
{
    public class RegistroProfile: Profile
    {
        public RegistroProfile()
        {
            CreateMap<CreateRegistroDTO, Registro>();
            CreateMap<Registro, ReadRegistroDTO>();
            CreateMap<UpdateRegistroDTO, Registro>();
        }
    }
}
