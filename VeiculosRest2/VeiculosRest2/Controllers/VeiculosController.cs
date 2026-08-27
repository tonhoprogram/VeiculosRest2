using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace VeiculosRest2;

[ApiController]
[Route("[controller]")]

public class VeiculosController : ControllerBase
{
    public static List<Veiculos> VeiculosSalvos = new List<Veiculos>();

    [HttpPost]
    public IActionResult Inserir(InserirVeiculosDTO inserirVeiculosDTO)
    {
        try
        {
            var novoVeiculo = new Veiculos();

            novoVeiculo.AnoModelo = inserirVeiculosDTO.AnoModelo;
            novoVeiculo.Cor = inserirVeiculosDTO.Cor;
            novoVeiculo.Combustivel = inserirVeiculosDTO.Combustivel;
            novoVeiculo.Chassi = inserirVeiculosDTO.Chassi;
            novoVeiculo.Placa = inserirVeiculosDTO.Placa;
            novoVeiculo.Nome = inserirVeiculosDTO.Nome;

            novoVeiculo.DataAquisição = DateTime.Today;
            novoVeiculo.Id = Guid.NewGuid();

            VeiculosSalvos.Add(novoVeiculo);

            return StatusCode(StatusCodes.Status201Created, new { Message = "inserido com sucesso", id = novoVeiculo.Id });
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Erro ao inserir veiculo. Verifique dados"); // <-- Faltava ponto e vírgula
        }
    }
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return StatusCode(200, VeiculosSalvos.ToList());
        }
        catch (Exception ex)
        {
            return StatusCode(400, ex.Message);
        }
    }
    [HttpGet("{id}")]
    public IActionResult ListarPorId(Guid id)
    {
        try
        {

            var veiculo = VeiculosSalvos.FirstOrDefault(p => p.Id == id);

            if (veiculo == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Veículo não encontrado");
            }

            return Ok(veiculo);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Erro ao listar veiculo. Verifique dados");
        }
    }
    [HttpPut("{id}")]
    public IActionResult Editar(Guid id, EditarVeiculosDTO editarVeiculoDTO)
    {
        try
        {
            var veiculo = VeiculosSalvos.Where(p => p.Id == id).FirstOrDefault();

            veiculo.Nome = editarVeiculoDTO.Nome;
            veiculo.Cor = editarVeiculoDTO.Cor;
            veiculo.Combustivel = editarVeiculoDTO.Combustivel;

            return StatusCode(StatusCodes.Status200OK, "Veiculo editado com sucesso");
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Erro ao editar veiculo. Verifique dados");
        }
    }

    [HttpPatch("{id}")]
    public IActionResult InformarQuilometragem(Guid id, InformarQuilometragemDTO informarQuilometragem)
    {
        try
        {
            var veiculo = VeiculosSalvos.FirstOrDefault(p => p.Id == id);

            if (veiculo == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Veículo não encontrado");
            }

            veiculo.Quilometragem = veiculo.Quilometragem + informarQuilometragem.Quilometragem;

            return StatusCode(StatusCodes.Status200OK, "Quilometragem informada com sucesso");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message); 
        }
    }
    [HttpDelete("{id}")]
    
        public IActionResult Excluir(Guid id)
        {
            try
            {
                var veiculo = VeiculosSalvos.FirstOrDefault(p => p.Id == id);

                if (veiculo == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Veículo não encontrado");
                }

                VeiculosSalvos.Remove(veiculo);

                return StatusCode(StatusCodes.Status200OK, "Veículo excluído com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Erro ao excluir veiculo. Verifique dados");
            }
        }

    [HttpHead("{id}")]
    public IActionResult Head(Guid id)
    {
        try
        {
            var veiculo = VeiculosSalvos.FirstOrDefault(p => p.Id == id);
            if (veiculo == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Veículo não encontrado");
            }
            return StatusCode(StatusCodes.Status200OK);

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Erro ao verificar veiculo. Verifique dados");
        }
    }

    [HttpOptions]
    public IActionResult Opções()
    {
        return Ok(new List<string> { "GET", "POST", "PUT", "PATCH", "DELETE", "HEAD", "OPTIONS" });
    }

}