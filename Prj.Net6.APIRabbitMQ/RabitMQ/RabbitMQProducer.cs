using Microsoft.AspNetCore.Connections;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Prj.Net6.APIRabbitMQ.RabitMQ
{
    
    // Enter default user name ‘guest’ and password also ‘guest’ and next you will see the dashboard

    public class RabbitMQProducer : IRabbitMQProducer
    {
        public void SendProductMessage<T>(T message)
        {
            //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
            var factory = new ConnectionFactory
            {
                HostName = "localhost:7103"
            };
            //Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = factory.CreateConnection();
            //Here we create channel with session and model
            using var channel = connection.CreateModel();
            //declare the queue after mentioning name and a few property related to that
            channel.QueueDeclare("product", exclusive: false);
            //Serialize the message
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            //put the data on to the product queue
            channel.BasicPublish(exchange: "", routingKey: "product", body: body);
        }
    }
}


// https://blog.devops.dev/rabbitmq-message-queue-using-net-core-6-web-api-c0fcfa72169c

//Step 8)

//Open the following URL to open the RabbitMQ dashboard on the port we set while running docker

//http://localhost:15672/


//Step 14)

//Install Rabbitmq docker file using the following command(Note - docker desktop is in running mode
//--
//docker pull rabbitmq: 3 - management



//Next, create a container and start using Rabbitmq Dockerfile which we downloaded
//--
//docker run — rm -it -p 15672:15672 - p 5672:5672 rabbitmq: 3 - management


//Step 15)

//Finally, run your application and you will see swagger UI and API endpoints
