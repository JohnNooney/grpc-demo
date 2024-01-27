using System.Threading.Tasks;
using Grpc.Net.Client;
using Client;
using System.Diagnostics.CodeAnalysis;

class Program{
    static private string grpcAddress = Environment.GetEnvironmentVariable("GRPC_SERVER_ADDRESS") ?? "http://localhost";
    
    static async Task Main(string[] args)
    {
        ShapeBuilder shapeBuilder = new ShapeBuilder();
        Result<Shape, string> result = shapeBuilder.BuildShape();
        
        if (result.IsSuccess)
        {
            GrpcChannelHelper channelHelper = new GrpcChannelHelper();
            
            using var channel = GrpcChannel.ForAddress(grpcAddress, 
            new GrpcChannelOptions { HttpHandler = channelHelper.GetHttpClientHandler() });
            
            ShapeSender shapeSenderClient = new ShapeSender(result.Value, channel);
            await shapeSenderClient.Send();
        } else {
            Console.WriteLine(result.Error);
        }   
    }
}


