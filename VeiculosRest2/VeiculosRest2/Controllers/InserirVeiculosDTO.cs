using System;

namespace VeiculosRest2;

public class InserirVeiculosDTO
{
    public string Nome { get; set; }

    public string Placa { get; set; }

    public string Chassi { get; set; }

    public int AnoModelo { get; set; }
    
    public string Cor { get; set; }

    public Veiculos.EnumCombustivel Combustivel { get; set; }
}
