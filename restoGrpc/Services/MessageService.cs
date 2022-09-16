using Grpc.Core;

namespace restoGrpc.Services
{
    public class MessageService /*: Message.MessageBase*/
    {

        //public override async Task SendMessage(IAsyncStreamReader<MessageRequest> requestStream, IServerStreamWriter<MessageReply> responseStream, ServerCallContext context)
        //{
        //    var task1 = Task.Run(async () =>
        //    {
        //        while (await requestStream.MoveNext(context.CancellationToken))
        //        {
        //            Console.WriteLine($"{requestStream.Current.Name} bana {requestStream.Current.Message} dedi.");
        //        }
        //    }); 

        //    for (int i = 0; i < 10; i++)
        //    {
        //        await Task.Delay(1000);
        //        await responseStream.WriteAsync(new MessageReply
        //        {
        //            Message=$"bu {i}. yanışım."
        //        });
        //    }

        //    await task1;
        //}




        //public override async Task<MessageReply> SendMessage(IAsyncStreamReader<MessageRequest> requestStream, ServerCallContext context)
        //{
        //    while (await requestStream.MoveNext(context.CancellationToken))
        //    {
        //        Console.WriteLine($"{requestStream.Current.Name} bana {requestStream.Current.Message} dedi.");
        //    }

        //    return new MessageReply
        //    {
        //        Message = "mesaj alındı",
        //    };
        //}


        //public override async Task SendMessage(MessageRequest request, IServerStreamWriter<MessageReply> responseStream, ServerCallContext context)
        //{
        //    Console.WriteLine($"{request.Name} bana {request.Message} dedi.");
        //    for (int i = 0; i < 10; i++)
        //    {
        //        await Task.Delay(200);
        //        await responseStream.WriteAsync(new MessageReply
        //        {
        //            Message=$"{request.Name} bana {i}. kez {request.Message} dedi."
        //        });
        //    }
        //}
    }
}
