
using NRules.Fluent.Dsl;

public class PromocionRegla : Rule
{
    public override void Define()
    {
        Cliente cliente = null;

        // Regla: Cliente debe ser existente, DNI debe tener longitud de 8 y ser de sexo femenino.
        When()
            .Match<Cliente>(c => c.EsClienteExistente && c.DNI.Length == 8 && c.Sexo == "F");

        // Acción: Marcar como apto para la promoción.
        Then()
            .Do(ctx => cliente.EsAptoPromocion = true)
            .Do(ctx => Console.WriteLine($"El cliente {cliente.DNI} es apto para la promoción."));
    }
}
