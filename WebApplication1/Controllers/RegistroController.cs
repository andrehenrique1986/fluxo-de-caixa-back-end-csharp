using AutoMapper;
using FluxoCaixa.Context;
using FluxoCaixa.DTO;
using FluxoCaixa.Interfaces;
using FluxoCaixa.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FluxoCaixa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        [HttpPost("adicionarRegistro")]
        public IActionResult AdicionarRegistro([FromBody] CreateRegistroDTO registroDTO)
        {
            if (registroDTO == null) return BadRequest("Dados do registro não fornecidos.");

            var registro = _mapper.Map<Registro>(registroDTO);
            _context.Registros.Add(registro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarRegistrosPorId),
                new { id = registro.IdRegistro },
                registro);
        }

        // Recupera todos os Registros
        [HttpGet("recuperarRegistro")]
        public IActionResult RecuperarRegistros()
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
                    FormaDePagamentoId = r.IdFormaDePagamento,
                    Valor = r.ValorRegistro
                }).ToList();
            if (!registros.Any()) return NotFound("Nenhum registro encontrado.");
            return Ok(registros);
        }

        // Recupera registros pelo Id
        [HttpGet("recuperarRegistroPorId/{id}")]
        public IActionResult RecuperarRegistrosPorId(int id)
        {
            var registro = _context.Registros
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
                }).FirstOrDefault();
            if (registro == null) return NotFound($"Registro com ID {id} não encontrado.");
            return Ok(registro);
        }

        // Realiza a Alteração dos Registros
        [HttpPut("atualizarRegistro/{id}")]
        public IActionResult AtualizarRegistro(int id, [FromBody] UpdateRegistroDTO registroDto)
        {
            if (registroDto == null) return BadRequest("Dados do registro não fornecidos.");

            var registro = _context.Registros.FirstOrDefault(r => r.IdRegistro == id);
            if (registro == null) return NotFound($"Registro com ID {id} não encontrado.");

            _mapper.Map(registroDto, registro);
            _context.Entry(registro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // Exclui os Registros
        [HttpDelete("excluirRegistro/{id}")]
        public IActionResult ExcluirRegistro(int id)
        {
            var registro = _context.Registros.FirstOrDefault(r => r.IdRegistro == id);
            if (registro == null) return NotFound($"Registro com ID {id} não encontrado.");

            _context.Registros.Remove(registro);
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

                if (valorCategoria == 0) return NotFound("Nenhum registro encontrado para a categoria especificada.");

                var formatInfo = new NumberFormatInfo
                {
                    NumberDecimalSeparator = ",",
                    NumberGroupSeparator = ".",
                    NumberDecimalDigits = 2
                };

                var valorGastosCategoria = $"{valorCategoria.ToString("N", formatInfo)}";

                return Ok(new
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
        [HttpGet("calcularRegistroPorFormasDePagamento/{idFormaDePagamento}")]
        public async Task<IActionResult> CalcularRegistroPorFormasDePagamento(int idFormaDePagamento)
        {
            try
            {
                var valorFormaDePagamento = await _registroService.CalcularRegistroPorFormaDePagamento(idFormaDePagamento);

                if (valorFormaDePagamento == 0) return NotFound("Nenhum registro encontrado para a forma de pagamento especificada.");

                var formatInfo = new NumberFormatInfo
                {
                    NumberDecimalSeparator = ",",
                    NumberGroupSeparator = ".",
                    NumberDecimalDigits = 2
                };

                var valorFormaPagamento = $"{valorFormaDePagamento.ToString("N", formatInfo)}";

                return Ok(new
                {
                    FormaDePagamentoId = idFormaDePagamento,
                    ValorTotalFormaDePagamento = $"R${valorFormaPagamento}"
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

                if (valorRegistroPorCusto == 0) return NotFound("Nenhum registro encontrado para o tipo de custo especificado.");

                var formatInfo = new NumberFormatInfo
                {
                    NumberDecimalSeparator = ",",
                    NumberGroupSeparator = ".",
                    NumberDecimalDigits = 2
                };

                var valorPorCusto = $"{valorRegistroPorCusto.ToString("N", formatInfo)}";

                return Ok(new
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
        [HttpGet("calcularPorcentagemPorCusto/{idCusto}")]
        public async Task<IActionResult> CalcularPorcentagemPorCusto(int idCusto)
        {
            try
            {
                var percentualPorCusto = await _registroService.CalcularPorcentagemPorCusto(idCusto);

                if (percentualPorCusto == null) return NotFound("Nenhuma porcentagem encontrada para o tipo de custo especificado.");

                return Ok(new
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

        // Calcula Registros por Fluxo
        [HttpGet("calcularRegistroPorFluxo/{idFluxo}")]
        public async Task<IActionResult> CalcularRegistroPorFluxo(int idFluxo)
        {
            try
            {
                var response = await _registroService.CalcularRegistroPorFluxo(idFluxo);

                var formatInfo = new NumberFormatInfo
                {
                    NumberDecimalSeparator = ",",
                    NumberGroupSeparator = ".",
                    NumberDecimalDigits = 2
                };

                return Ok(new
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
