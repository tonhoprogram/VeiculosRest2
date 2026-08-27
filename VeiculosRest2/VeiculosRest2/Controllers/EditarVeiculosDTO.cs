using System;

namespace VeiculosRest2;

public class EditarVeiculosDTO
{
    public string Nome { get; set; }

    public string Cor { get; set; }

    public Veiculos.EnumCombustivel Combustivel { get; set; }
}