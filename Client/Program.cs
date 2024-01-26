using System.Threading.Tasks;
using Grpc.Net.Client;
using Client;
using System.Diagnostics.CodeAnalysis;

class Program{

    static async Task Main(string[] args)
    {
        string grpcAddress = Environment.GetEnvironmentVariable("GRPC_SERVER_ADDRESS") ?? "https://localhost";
        
        GrpcChannelHelper channelHelper = new GrpcChannelHelper();

        using var channel = GrpcChannel.ForAddress(grpcAddress, 
            new GrpcChannelOptions { HttpHandler = channelHelper.GetHttpClientHandler()});

        Shape square = new Shape { Type = "square", Dimension1 = 2 };

        ShapeSender shapeSenderClient = new ShapeSender(square, channel);
        await shapeSenderClient.send();
    }
}


