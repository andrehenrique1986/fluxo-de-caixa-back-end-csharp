using AutoMapper;
using FluxoCaixa.Context;
using FluxoCaixa.DTO;
using FluxoCaixa.Interfaces;
using FluxoCaixa.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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

        // Adiciona um novo Registro
        [HttpPost]
        public IActionResult AdicionarRegistro([FromBody] CreateRegistroDTO registroDTO)
        {
            Registro registro = _mapper.Map<Registro>(registroDTO);
            _context.Registros.Add(registro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarRegistrosPorId),
                new { id = registro.IdRegistro },
                registro);
        }

        // Recupera todos os Registros
        [HttpGet]
        public IActionResult RecuperaRegistro()
        {
            var registros = _context.Registros
                .Select(r =>
                new
                {
                    Id = r.IdRegistro,
                    DataRegistro = r.DtRegistro,
                    CategoriaId = r.IdCategoria,
                    SubcategoriaId = r.IdSubcategoria,
                    CustoId = r.IdCusto,
                    FluxoId = r.IdFluxo,
                    FormaDePagamento = r.IdFormaDePagamento,
                    Valor = r.ValorRegistro
                }).ToList();
            if (registros == null || !registros.Any()) return NotFound();
            return Ok(registros);
        }

        // Recupera registros pelo Id
        [HttpGet("{id}")]
        public IActionResult RecuperarRegistrosPorId(int id)
        {
            var registros = _context.Registros
                .Where(r => r.IdRegistro == id)
                .Select(r =>
                new
                {
                    Id = r.IdRegistro,
                    DataRegistro = r.DtRegistro,
                    CategoriaId = r.IdCategoria,
                    SubcategoriaId = r.IdSubcategoria,
                    CustoId = r.IdCusto,
                    FluxoId = r.IdFluxo,
                    FormaDePagamentoId = r.IdFormaDePagamento,
                    Valor = r.ValorRegistro
                }).ToList();
            if (registros == null || !registros.Any()) return NotFound();
            return Ok(registros);
        }

        // Realiza a Alteração dos Registros
        [HttpPut("{id}")]
        public IActionResult AtualizarRegistro(int id, [FromBody] UpdateRegistroDTO registroDto)
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

        // Exclui os Registros
        [HttpDelete("{id}")]
        public IActionResult ExcluirRegistro(int id)
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

        // Calcula os Gastos por Categoria
        [HttpGet("calcularGastosPorCategoria/{idCategoria}")]
        public async Task<IActionResult> CalcularGastosPorCategoria(int idCategoria)
        {
            try
            {
                var valorCategoria = await _registroService.CalcularRegistroPorCategoria(idCategoria);

                if (valorCategoria == 0)
                {
                    return NotFound("Nenhum registro encontrado para a categoria especificada.");
                }

                return Ok(
                    new
                    {
                        CategoriaId = idCategoria,
                        ValorTotalCategoria = $"R${valorCategoria:F2}"
                    });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }

        // Calcula os Gastos por Forma de Pagamento
        [HttpGet("calcularRegistroPorFormasDePagamento/{idFormaDePagamento}")]
        public async Task<IActionResult> CalcularRegistroPorFormasDePagamento(int idFormaDePagamento)
        {
            try
            {
                var valorFormaDePagamento = await _registroService.CalcularRegistroPorFormaDePagamento(idFormaDePagamento);

                if (valorFormaDePagamento == 0)
                {
                    return NotFound("Nenhum registro encontrado para a forma de pagamento especificada.");
                }

                return Ok(
                   new
                   {
                       FormaDePagamentoId = idFormaDePagamento,
                       ValorTotalFormaDePagamento = $"R${valorFormaDePagamento:F2}"
                   });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }

        // Calcula os Gastos por Custo
        [HttpGet("calcularRegistroPorCusto/{idCusto}")]
        public async Task<IActionResult> CalcularRegistroPorCusto(int idCusto)
        {
            try
            {
                var valorRegistroPorCusto = await _registroService.CalcularRegistroPorCusto(idCusto);

                if (valorRegistroPorCusto == 0)
                {
                    return NotFound("Nenhum registro encontrado para o tipo de custo especificado.");
                }

                return Ok(
                    new
                    {
                        CustoId = idCusto,
                        ValorTotalRegistro = $"R${valorRegistroPorCusto:F2}"
                    });
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }

        // Calcula as Porcentagens por Custo
        [HttpGet("calcularPorcentagemPorCusto/{idCusto}")]
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

        
        [HttpGet("calcularRegistroPorFluxo/{idFluxo}")]
        public async Task<IActionResult> CalcularRegistroPorFluxo(int idFluxo)
        {
            try
            {
                var (entrada, saida, saldo) = await _registroService.CalcularRegistroPorFluxo(idFluxo);

                return Ok(
                    new
                    {
                        FluxoId = idFluxo,
                        Entrada = $"R${entrada:F2}",
                        Saida = $"R${saida:F2}",
                        Saldo = $"R${saldo:F2}"
                    });
            }catch (Exception e)
            {
                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }
    }
}
