using Client;
using Grpc.Net.Client;

public class ShapeSender
{
    private Shape shape;
    private GrpcChannel channel;

    public ShapeSender(Shape shape, GrpcChannel channel)
    {
        this.shape = shape;
        this.channel = channel;
    }

    public async Task Send()
    {
        var client = new AreaCalculator.AreaCalculatorClient(channel);
        var reply = await client.CalculateAreaAsync(shape);

        Console.WriteLine(shape.Type + " has an area of: " + reply.Area);
    }
}