namespace Prj.Net6.APIRabbitMQ.RabitMQ
{
    public interface IRabbitMQProducer
    {
        public void SendProductMessage<T>(T message);
    }
}
