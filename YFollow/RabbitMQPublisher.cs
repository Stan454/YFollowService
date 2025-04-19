using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using YFollow.Models;

public class RabbitMQPublisher
{
    private readonly string _hostname = "localhost"; 
    private readonly string _queueName = "FollowUpdates"; 
    private readonly IConnection _connection;

    public RabbitMQPublisher()
    {
        var factory = new ConnectionFactory { HostName = _hostname };
        _connection = factory.CreateConnection();
    }

    public void PublishFollowUpdate(FollowDto followDto)
    {
        using var channel = _connection.CreateModel();
        channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

        var message = new { followDto.FollowerId, followDto.UserId, followDto.UserName};
        var messageBody = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

        channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: messageBody);
    }
}
