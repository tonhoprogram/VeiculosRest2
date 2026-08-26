using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace VeiculosRest2;

[ApiController]
[Route("[controller]")]

public class VeiculosController : ControllerBase
{
    public static List<Veiculos> Veiculos = new List<Veiculos>();

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

            Veiculos.Add(novoVeiculo);

            return StatusCode(StatusCodes.Status201Created, "Inserido com sucesso");
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
             return StatusCode(200, Veiculos.ToList());
         }
         catch (Exception ex)
         {
                return StatusCode(400, ex.Message);
            }
        }
    }

