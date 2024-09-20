using AutoMapper;
using FluxoCaixa.Context;
using FluxoCaixa.DTO;
using FluxoCaixa.Interfaces;
using FluxoCaixa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistroController : ControllerBase
    {
        private readonly FluxoContext _context;
        private readonly IMapper _mapper;
        private readonly IRegistroService _registroService;


        public RegistroController(FluxoContext context, IMapper mapper, IRegistroService registroService)
        {
            _context = context;
            _mapper = mapper;
            _registroService = registroService;
        }

        [HttpPost("api/adicionarRegistro")]
        public IActionResult AdicionarRegistro([FromBody] CreateRegistroDTO registroDTO)
        {

            try
            {
                Registro registro = _mapper.Map<Registro>(registroDTO);
                _context.Registros.Add(registro);
                _context.SaveChanges();
                return CreatedAtAction(nameof(RecuperarRegistrosPorId),
                    new { id = registro.IdRegistro },
                    registroDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }

        // Recupera todos os Registros
        [HttpGet("api/recuperarRegistro")]
        public IActionResult RecuperarRegistro()
        {
            try
            {

                var registros = _context.Registros
                    .Include(cat => cat.Categoria)
                    .Include(subCat => subCat.Subcategoria)
                    .Include(cst => cst.Custo)
                    .Include(fl => fl.Fluxo)
                    .Include(foPag => foPag.FormaDePagamento)
                    .Select(r =>
                    new
                    {
                        Id = r.IdRegistro,
                        DataRegistro = r.DtRegistro,
                        IdCategoria = r.IdCategoria,
                        CategoriaNome = r.Categoria.DscTipoCategoria,
                        IdSubcategoria = r.IdSubcategoria,
                        SubcategoriaNome = r.Subcategoria.DscTipoSubcategoria,
                        TipoDeCusto = r.Custo.DscTipoCusto,
                        TipoDeFluxo = r.Fluxo.DscTipoFluxo,
                        FormaDePagamento = r.FormaDePagamento.TipoFormaDePagamento,
                        Valor = r.ValorRegistro,
                        IdFluxo = r.IdFluxo,
                        IdCusto = r.IdCusto,
                        IdFormaDePagamento = r.IdFormaDePagamento

                    }).ToList();
                if (registros == null || !registros.Any()) return NotFound();
                return Ok(registros);
            }

            catch (Exception e)
            {
                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }


        // Recupera registros pelo Id
        [HttpGet("api/recuperarRegistroPorId/{id}")]
        public IActionResult RecuperarRegistrosPorId(int id)
        {

            try
            {

                var registros = _context.Registros
                .Include(cat => cat.Categoria)
                .Include(subCat => subCat.Subcategoria)
                .Include(cst => cst.Custo)
                .Include(fl => fl.Fluxo)
                .Include(foPag => foPag.FormaDePagamento)
                .Where(r => r.IdRegistro == id)
                .Select(r =>
                new
                {
                    Id = r.IdRegistro,
                    DataRegistro = r.DtRegistro,
                    CategoriaNome = r.Categoria.DscTipoCategoria,
                    SubcategoriaNome = r.Subcategoria.DscTipoSubcategoria,
                    TipoDeCusto = r.Custo.DscTipoCusto,
                    TipoDeFluxo = r.Fluxo.DscTipoFluxo,
                    FormaDePagamento = r.FormaDePagamento.TipoFormaDePagamento,
                    Valor = r.ValorRegistro
                }).ToList();
                if (registros == null || !registros.Any()) return NotFound();
                return Ok(registros);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }



        // Realiza a Alteração dos Registros
        [HttpPut("api/atualizarRegistro/{id}")]
        public IActionResult AtualizarRegistro(int id, [FromBody] UpdateRegistroDTO registroDto)
        {
            try
            {
                Registro registro = _context.Registros.FirstOrDefault(registro => registro.IdRegistro == id);
                if (registro == null)
                {
                    return NotFound();
                }

                _context.Entry<Registro>(registro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _mapper.Map(registroDto, registro);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }

        }

        // Exclui os Registros
        [HttpDelete("api/excluirRegistro/{id}")]
        public IActionResult ExcluirRegistro(int id)
        {
            try
            {
                Registro registro = _context.Registros.FirstOrDefault(r => r.IdRegistro == id);
                if (registro == null)
                {
                    return NotFound();
                }
                _context.Remove(registro);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }


        // Calcula os Gastos por Categoria
        [HttpGet("api/calcularGastosPorCategoria/{idCategoria}")]
        public async Task<IActionResult> CalcularGastosPorCategoria(int idCategoria)
        {
            try
            {
                var valorCategoria = await _registroService.CalcularRegistroPorCategoria(idCategoria);

                if (valorCategoria == 0)
                {
                    return NotFound("Nenhum registro encontrado para a categoria especificada.");
                }

                var formatInfo = new NumberFormatInfo
                {
                    NumberDecimalSeparator = ",",
                    NumberGroupSeparator = ".",
                    NumberDecimalDigits = 2
                };

                var valorGastosCategoria = $"{valorCategoria.ToString("N", formatInfo)}";

                return Ok(
                    new
                    {
                        CategoriaId = idCategoria,
                        ValorTotalCategoria = $"R${valorGastosCategoria}"
                    });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }

        // Calcula os Gastos por Forma de Pagamento
        [HttpGet("api/calcularRegistroPorFormasDePagamento/{idFormaDePagamento}")]
        public async Task<IActionResult> CalcularRegistroPorFormasDePagamento(int idFormaDePagamento)
        {
            try
            {
                var valorFormaDePagamento = await _registroService.CalcularRegistroPorFormaDePagamento(idFormaDePagamento);

                if (valorFormaDePagamento == 0)
                {
                    return NotFound("Nenhum registro encontrado para a forma de pagamento especificada.");
                }

                var formatInfo = new NumberFormatInfo
                {
                    NumberDecimalSeparator = ",",
                    NumberGroupSeparator = ".",
                    NumberDecimalDigits = 2
                };

                var valorFormaPagemanto = $"{valorFormaDePagamento.ToString("N", formatInfo)}";

                return Ok(
                   new
                   {
                       FormaDePagamentoId = idFormaDePagamento,
                       ValorTotalFormaDePagamento = $"R${valorFormaPagemanto}"
                   });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }

        // Calcula os Gastos por Custo
        [HttpGet("api/calcularRegistroPorCusto/{idCusto}")]
        public async Task<IActionResult> CalcularRegistroPorCusto(int idCusto)
        {
            try
            {
                var valorRegistroPorCusto = await _registroService.CalcularRegistroPorCusto(idCusto);


                if (valorRegistroPorCusto == 0)
                {
                    return NotFound("Nenhum registro encontrado para o tipo de custo especificado.");
                }

                var formatInfo = new NumberFormatInfo
                {
                    NumberDecimalSeparator = ",",
                    NumberGroupSeparator = ".",
                    NumberDecimalDigits = 2
                };

                var valorPorCusto = $"{valorRegistroPorCusto.ToString("N", formatInfo)}";

                return Ok(
                    new
                    {
                        CustoId = idCusto,
                        ValorTotalRegistro = $"R${valorPorCusto}"
                    });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }

        // Calcula as Porcentagens por Custo
        [HttpGet("api/calcularPorcentagemPorCusto/{idCusto}")]
        public async Task<IActionResult> CalcularPorcentagemPorCusto(int idCusto)
        {
            try
            {
                var percentualPorCusto = await _registroService.CalcularPorcentagemPorCusto(idCusto);

                if (percentualPorCusto == null)
                {
                    return NotFound("Nenhuma porcentagem encontrada para o tipo de custo especificado.");
                }

                return Ok(
                    new
                    {
                        CustoId = idCusto,
                        ValorTotalRegistro = $"{percentualPorCusto:F0}%"
                    });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }


        [HttpGet("api/calcularRegistroPorFluxo/{idFluxo}")]
        public async Task<IActionResult> CalcularRegistroPorFluxo(int idFluxo)
        {
            try
            {
                RegistroPorFluxoDTO response = await _registroService.CalcularRegistroPorFluxo(idFluxo);

                var formatInfo = new NumberFormatInfo
                {
                    NumberDecimalSeparator = ",",
                    NumberGroupSeparator = ".",
                    NumberDecimalDigits = 2
                };



                return Ok(
                    new
                    {
                        FluxoId = idFluxo,
                        Entrada = $"R${response.entrada.ToString("N", formatInfo)}",
                        Saida = $"R${response.saida.ToString("N", formatInfo)}",
                        Saldo = $"R${response.saldo.ToString("N", formatInfo)}"
                    });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }
    }
}
