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
        request.Type = request.Type.Trim();
        request.Type = request.Type.ToLowerInvariant();
        float calculatedArea = 0;

        try
        {
            if (string.IsNullOrWhiteSpace(request.Type))
            {
                // Handle invalid or missing shape type
                return Task.FromResult(new AreaResponse
                {
                    ErrorMessage = "Invalid or missing shape type."
                });
            }

            if (request.Dimension1 < 0 || (request.Type == "rectangle" && request.Dimension2 < 0))
            {
                // Handle invalid dimensions
                return Task.FromResult(new AreaResponse
                {
                    ErrorMessage = "Invalid dimensions. Dimensions must be non-negative."
                });
            }

            if (request.Type == "square")
            {
                calculatedArea = request.Dimension1 * request.Dimension1;
            }
            else if (request.Type == "circle")
            {
                calculatedArea = request.Dimension1 * request.Dimension1 * (float)Math.PI;
            }
            else if (request.Type == "rectangle")
            {
                calculatedArea = request.Dimension1 * request.Dimension2;
            }

            return Task.FromResult(new AreaResponse
            {
                Area = calculatedArea
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error calculating area. Type: {Type}, Dimension1: {Dimension1}, Dimension2: {Dimension2}",
            request.Type, request.Dimension1, request.Dimension2);

            return Task.FromResult(new AreaResponse
            {
                ErrorMessage = "An error occurred during area calculation."
            });
        }
    }
}