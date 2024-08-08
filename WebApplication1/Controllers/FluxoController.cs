﻿using Enums;
using FluxoCaixa.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FluxoController: ControllerBase
    {



        // Recupera os Tipos de Fluxo
        [HttpGet]
        public IActionResult RecuperaFluxo()
        {
            try
            {
                var fluxo = Enum.GetValues(typeof(EnTipoFluxo))
               .Cast<EnTipoFluxo>()
               .Select(f => new { Id = (int)f, Nome = f.GetDisplayName() })
               .ToList();
                return Ok(fluxo);
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
           
        }

        // Recupera os Fluxos pelo id
        [HttpGet("{id}")]
        public IActionResult RecuperarFluxosPorId(int id)
        {
            try
            {
                var fluxo = Enum.GetValues(typeof(EnTipoFluxo))
                .Cast<EnTipoFluxo>()
                .Select(f => new { Id = (int)f, Nome = f.GetDisplayName() })
                .Where(c => c.Id == id)
                .ToList();

                if (fluxo == null || fluxo.Count == 0)
                {
                    return NotFound("Nenhum custo encontrado para o tipo especificado.");
                }
                return Ok(fluxo);
            }
            catch (Exception e)
            {

                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
            
        }
    }
}
