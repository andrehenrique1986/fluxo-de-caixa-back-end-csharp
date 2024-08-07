using AutoMapper;
using FluxoCaixa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace FluxoCaixa.Profiles
{
    public class SubcategoriaProfile: Profile
    {
        public SubcategoriaProfile()
        {
            CreateMap<CreateSubcategoriaDTO, Subcategoria>();
            CreateMap<UpdateSubcategoriaDTO, Subcategoria>();
            CreateMap<Subcategoria, UpdateSubcategoriaDTO>();

            CreateMap<Subcategoria, ReadSubcategoriaDTO>().
                ForMember(subcategoriaDto => subcategoriaDto.Registros,
                opt => opt.MapFrom(subcategoria => subcategoria.Registros));
        }
    }
}
