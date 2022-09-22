using Grpc.Net.Client;
using resto_grpc;

namespace test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7104");
            var greetClient = new Message.MessageClient(channel);

            MessageReply hp = await greetClient.SendMessageAsync(new MessageRequest
            {
                Name = "world"
            });

            Console.WriteLine(hp.Message);
            Console.ReadLine();
        }
    }
}