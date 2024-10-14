
using NRules.Fluent.Dsl;

public class ManejoErroresRegla : Rule
{
    public override void Define()
    {
        Cliente cliente = null;

        // Regla: Si el DNI es inválido o no es cliente.
        When()
            .Match<Cliente>(c => c.DNI.Length != 8 || !c.EsClienteExistente);

        // Acción: Registrar error.
        Then()
            .Do(ctx => Console.WriteLine($"Error: El cliente {cliente.DNI} tiene un DNI inválido o no es un cliente existente."))
            .Do(ctx => EnviarErrorKafka(cliente));
    }

    private void EnviarErrorKafka(Cliente cliente)
    {
        string mensajeError = $"Error con cliente DNI: {cliente.DNI}.";
        KafkaProducer.EnviarNotificacion(mensajeError);
    }
}
