using Grpc.Core;
using Grpc.Net.Client;
using restoGrpc;
using System.Numerics;

namespace test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7104");
            //var greetClient = new Message.MessageClient(channel);

            //unery
            //MessageReply hp = await greetClient.SendMessageAsync(new MessageRequest
            //{
            //    Name = "world",
            //    Message = "naber"
            //});

            //Console.WriteLine(hp.Message);

            //server streaming
            //var response = greetClient.SendMessage(
            //    new MessageRequest
            //    {
            //        Name = "tarıq",
            //        Message = "naber"
            //    });

            //CancellationTokenSource cts = new CancellationTokenSource();
            //while (await response.ResponseStream.MoveNext(cts.Token))
            //{
            //    Console.WriteLine(response.ResponseStream.Current.Message);
            //}

            //client streaming
            //var request = greetClient.SendMessage();

            //for (int i = 0; i < 10; i++)
            //{
            //    await Task.Delay(1000);
            //    await request.RequestStream.WriteAsync(new MessageRequest
            //    {
            //        Name = $"{i}ban",
            //        Message = "salamsa"
            //    });

            //}

            //await request.RequestStream.CompleteAsync();

            //Console.WriteLine((await request.ResponseAsync).Message);

            //bi - directional streaming


            //var request = greetClient.SendMessage();

            //var task1 = Task.Run(async () =>
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        await Task.Delay(1100);
            //        await request.RequestStream.WriteAsync(new MessageRequest
            //        {
            //            Name = "ptts",
            //            Message = $"messagebu {i}"
            //        });

            //    }
            //});

            //CancellationTokenSource cts = new CancellationTokenSource();
            //while (await request.ResponseStream.MoveNext(cts.Token))
            //{
            //    Console.WriteLine(request.ResponseStream.Current.Message);
            //}

            //await task1;

            //await request.RequestStream.CompleteAsync();

            Console.ReadLine();
        }
    }
}