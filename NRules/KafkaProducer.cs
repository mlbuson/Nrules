
using Confluent.Kafka;

public class KafkaProducer
{
    public static void EnviarNotificacion(string mensaje)
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

        using (var producer = new ProducerBuilder<Null, string>(config).Build())
        {
            producer.Produce("errores-promocion", new Message<Null, string> { Value = mensaje });
            producer.Flush(TimeSpan.FromSeconds(10));
        }

        Console.WriteLine($"Mensaje enviado a Kafka: {mensaje}");
    }
}
