using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace AccountService.Services;

public interface IMessageProducer
{
    void SendMessage<T>(T message);
}

public class RabbitMQProducer : IMessageProducer
{
    private IModel? channel;
    public RabbitMQProducer()
    {
        var factory = new ConnectionFactory{Uri = new Uri("amqp://guest:guest@host.docker.internal:5672/") };
        var connection = factory.CreateConnection();
        channel=connection.CreateModel();

        channel.QueueDeclare(
            queue: "test", 
            durable: false, 
            exclusive: false, 
            autoDelete: false, 
            arguments: null);
    }
    public void SendMessage<T>(T message)
    {
        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(exchange: "", routingKey: "orders", body: body);
    }
}