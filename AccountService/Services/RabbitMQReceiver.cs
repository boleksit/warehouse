using System.Text;
using AccountService.Models.Create;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AccountService.Services;

public interface IRabbitMQReceiver
{
}

public class RabbitMQReceiver : BackgroundService
{
    private IServiceProvider _sp;
    private ConnectionFactory _factory;
    private IConnection _connection;
    private IModel _channel;

    // initialize the connection, channel and queue 
    // inside the constructor to persist them 
    // for until the service (or the application) runs
    public RabbitMQReceiver(IServiceProvider sp)
    {
        _sp = sp;
            
        _factory = new ConnectionFactory() { HostName = "localhost", Port = 49154, UserName = "test", Password = "test" };
            
        _connection = _factory.CreateConnection();
            
        _channel = _connection.CreateModel();
            
        _channel.QueueDeclare(
            queue: "test", 
            durable: false, 
            exclusive: false, 
            autoDelete: false, 
            arguments: null);
        Console.WriteLine("RabbitMQReceiver created.");
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (stoppingToken.IsCancellationRequested)
        {
            _channel.Dispose();
            _connection.Dispose();
            return Task.CompletedTask;
        }
        
        var consumer = new EventingBasicConsumer(_channel);
        
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(" [x] Received {0}", message);

            Task.Run(() =>
            {
                var user = JsonConvert.DeserializeObject<CreateUser>(message);
                using (var scope = _sp.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<IAccountService>();
                    db.RegisterUser(user);
                }
            });
        };

        _channel.BasicConsume(queue: "test", autoAck: true, consumer: consumer);

        return Task.CompletedTask;
    }

   
    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}