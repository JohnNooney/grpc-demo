using System.Threading.Tasks;
using Grpc.Net.Client;
using Client;
using System.Diagnostics.CodeAnalysis;

using var channel = GrpcChannel.ForAddress("https://localhost:7104");

// var client = new Greeter.GreeterClient(channel);
//     var reply = await client.SayHelloAsync(
//                     new HelloRequest { Name = "John" });

//     Console.WriteLine("Greeting: " + reply.Message);
//     //Console.WriteLine("Press any key to exit...");
//     //Console.ReadKey();

Shape square = new Shape { Type = "square", Dimension1 = 2 };
ShapeSender shapeSenderClient = new ShapeSender(square ,channel);
await shapeSenderClient.send();


