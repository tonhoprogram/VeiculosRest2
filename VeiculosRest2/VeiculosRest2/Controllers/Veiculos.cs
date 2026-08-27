namespace VeiculosRest2;

public class Veiculos
{
    public Guid Id { get; set; }

    public string Nome { get; set; }

    public string Placa { get; set; }

    public string Chassi { get; set; }

    public int AnoModelo { get; set; }
    public string Cor { get; set; }

    public DateTime DataAquisição { get; set; }

    public EnumCombustivel Combustivel { get; set; }

    public int Quilometragem { get; set; }

    public enum EnumCombustivel
    {
        Gasolina = 1,
        Alcool = 2, 
        Flex = 3,
        Diesel = 4,
        Eletrico = 5,
        Gnv = 6,
        GasDeCozinha = 7

    }

}
