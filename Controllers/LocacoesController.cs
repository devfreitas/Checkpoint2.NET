using Microsoft.AspNetCore.Mvc;
using CP2.Data;
using CP2.DTOs;

namespace CP2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocacoesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("calcular")]
        public async Task<IActionResult> Calcular(LocacaoRequestDTO request)
        {
            var carro = await _context.Carros.FindAsync(request.CarroId);
            if (carro == null) return NotFound("Carro não encontrado");

            int dias = (request.DataFim - request.DataInicio).Days;

            if (dias <= 0)
                return BadRequest("Período inválido");

            decimal subtotal = dias * carro.ValorDiaria;

            decimal descontoPercentual = 0;

            if (dias >= 7)
                descontoPercentual = 0.10m;
            else if (dias >= 3)
                descontoPercentual = 0.05m;

            decimal valorFinal = subtotal - (subtotal * descontoPercentual);

            var response = new LocacaoResponseDTO
            {
                Carro = carro.Modelo,
                Marca = carro.Marca,
                DataInicio = request.DataInicio,
                DataFim = request.DataFim,
                ValorDiaria = carro.ValorDiaria,
                Subtotal = subtotal,
                Desconto = $"{descontoPercentual * 100}%",
                ValorFinal = valorFinal
            };

            return Ok(response);
        }
    }
}