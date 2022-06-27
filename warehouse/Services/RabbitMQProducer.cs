using System.Text;
using System.Threading.Channels;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace warehouse.Services;

public interface IMessageProducer
{
    void SendMessage<T>(T message);
}

public class RabbitMQProducer : IMessageProducer
{
    private IModel? channel;
    public RabbitMQProducer()
    {
        var factory = new ConnectionFactory{HostName = "localhost", Port = 49154, UserName = "guest", Password = "guest"};
        var connection = factory.CreateConnection();
        channel=connection.CreateModel();

        channel.QueueDeclare("test");
    }
    public void SendMessage<T>(T message)
    {
        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(exchange: "", routingKey: "orders", body: body);
    }
}