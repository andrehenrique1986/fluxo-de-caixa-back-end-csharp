using AutoMapper;
using FluxoCaixa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace FluxoCaixa.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<CreateCategoriaDTO, Categoria>();
            CreateMap<UpdateCategoriaDTO, Categoria>();
            CreateMap<Categoria, UpdateCategoriaDTO>();

            CreateMap<Categoria, ReadCategoriaDTO>().
               ForMember(categoriaDto => categoriaDto.Subcategorias,
                opt => opt.MapFrom(categoria => categoria.Subcategorias));

            CreateMap<Categoria, ReadCategoriaDTO>().
                ForMember(categoriaDto => categoriaDto.Registros,
                opt => opt.MapFrom(categoria => categoria.Registros));


        }
    }
}
