namespace Geometry;

public class Vector
{
	public double X;
	public double Y;
	public double GetLength()
    {
        return Geometry.GetLength(this);
    }

    public Vector Add(Vector vector2)
    {
        return Geometry.Add(this, vector2);
    }

    public bool Belongs(Segment segment)
    {
        return Geometry.IsVectorInSegment(this, segment);
    }
}

public class Segment
{
	public Vector Begin;
	public Vector End;
	public double GetLength()
    {
        return Geometry.GetLength(this);
    }

    public bool Contains(Vector point)
    {
        return Geometry.IsVectorInSegment(point, this);
    }
}

public class Geometry
{
	const double Epsilon = 10 * 0.000000001;
	public static double GetLength(Vector vector)
	{
		return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
	}

	public static Vector Add(Vector vector1, Vector vector2)
	{
        return new Vector() { X = vector1.X + vector2.X, Y = vector1.Y + vector2.Y };  
	}

	public static double GetLength(Segment segment)
    {
        var dx = segment.End.X - segment.Begin.X;
        var dy = segment.End.Y - segment.Begin.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
	
	public static bool IsVectorInSegment(Vector point, Segment segment)
	{
		var distanceToBegin = Math.Sqrt(
            Math.Pow(point.X - segment.Begin.X, 2) + Math.Pow(point.Y - segment.Begin.Y, 2));
        var distanceToEnd = Math.Sqrt(
            Math.Pow(point.X - segment.End.X, 2) + Math.Pow(point.Y - segment.End.Y, 2));
		var segmentLength = GetLength(segment);
		return Math.Abs((distanceToBegin + distanceToEnd) - segmentLength) < Epsilon;		
	}
}
