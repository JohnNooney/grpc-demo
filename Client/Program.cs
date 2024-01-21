using System.Threading.Tasks;
using Grpc.Net.Client;
using Client;
using System.Diagnostics.CodeAnalysis;

class Program{
    static async Task Main(string[] args)
    {
        string grpcAddress = Environment.GetEnvironmentVariable("GRPC_SERVER_ADDRESS") ?? "https://localhost:5001";
        
        using var channel = GrpcChannel.ForAddress(grpcAddress);

        Shape square = new Shape { Type = "square", Dimension1 = 2 };
        ShapeSender shapeSenderClient = new ShapeSender(square, channel);
        await shapeSenderClient.send();
    }
}


