using Grpc.Core;
using Server;

namespace Server.Services;

public class ShapesService : AreaCalculator.AreaCalculatorBase{
    private readonly ILogger<ShapesService> _logger;
    public ShapesService(ILogger<ShapesService> logger)
    {
        _logger = logger;
    }

    public override Task<AreaResponse> CalculateArea(Shape request, ServerCallContext context)
    {
        float calculatedArea = 0;
        
        if(request.Type == "square"){
            calculatedArea = request.Dimension1 * request.Dimension1;
        } 
        else if(request.Type == "circle"){
            calculatedArea = request.Dimension1 * request.Dimension1 * (float)Math.PI;
        } 
        else if(request.Type == "rectangle") {
            calculatedArea = request.Dimension1 * request.Dimension2;
        }

        _logger.LogDebug("");

        return Task.FromResult(new AreaResponse
        {
            Area = calculatedArea
        });
    }
}