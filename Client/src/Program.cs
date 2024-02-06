using System.Threading.Tasks;
using Grpc.Net.Client;
using Client;
using System.Diagnostics.CodeAnalysis;

class Program{
    static private string grpcAddress = Environment.GetEnvironmentVariable("GRPC_SERVER_ADDRESS") ?? "http://localhost:5001";
    
    static async Task Main(string[] args)
    {
        GrpcChannelHelper channelHelper = new GrpcChannelHelper();
                
        using var channel = GrpcChannel.ForAddress(grpcAddress, 
        new GrpcChannelOptions { HttpHandler = channelHelper.GetHttpClientHandler() });

        while(true){
            ShapeBuilder shapeBuilder = new ShapeBuilder();
            Result<Shape, string> result = shapeBuilder.BuildShapeFromInput();
            
            if (result.IsSuccess)
            {
                ShapeSender shapeSenderClient = new ShapeSender(result.Value, channel);

                Console.WriteLine("Sending shape to server to calculate area... \n");

                await shapeSenderClient.Send();
            } else {
                Console.WriteLine(result.Error);
            }   
        }
    }
}


