using Client;

public class ShapeBuilder
{
    public Result<Shape, string> BuildShape()
    {
        Console.Write("Enter the shape type: ");
        string shapeType = Console.ReadLine()?.ToLower() ?? string.Empty;
        
        if (!IsValidShapeType(shapeType))
        {
            return Result<Shape, string>.Failure("Invalid shape type. Exiting.");
        }

        Console.Write("Enter the primary dimension: ");
        if (!float.TryParse(Console.ReadLine(), out float dimension1))
        {
            return Result<Shape, string>.Failure("Invalid input for the primary dimension. Exiting.");
        }

        Shape shape = new Shape { Type = shapeType, Dimension1 = dimension1 };

        if (shapeType == "rectangle")
        {
            float dimension2 = GetSecondDimension();
            if (dimension2 == float.MinValue)
            {
                return Result<Shape, string>.Failure("Invalid input for the second dimension. Exiting.");
            }

            shape.Dimension2 = dimension2;
        }

        return Result<Shape, string>.Success(shape);
    }

    private bool IsValidShapeType(string type)
    {
        return type == "square" || type == "circle" || type == "rectangle";
    }

    private float GetSecondDimension()
    {
        Console.Write("Enter the second dimension: ");
        return float.TryParse(Console.ReadLine(), out float dimension2) ? dimension2 : float.MinValue;
    }
}