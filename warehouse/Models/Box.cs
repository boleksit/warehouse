using System.Collections;
using System.Globalization;

namespace warehouse;
//immutable
public sealed class Box :IFormattable, IEquatable<Box>, IEnumerable<double>
{
    public Address ShippingAdress { get; set; }
    public Client Owner { get; set; }
    private readonly double _a;
    private readonly double _b;
    private readonly double _c;
    public double A { get=>Math.Round(_a*ToMeters(),3); init=>_a=value; }
    public double B { get=>Math.Round(_b*ToMeters(),3); init=>_b=value; }
    public double C { get=>Math.Round(_c*ToMeters(),3); init=>_c=value; }
    public UnitOfMeasure Unit { get; init; }

    public double Volume { get=>Math.Round(_a*ToMeters()*_b*ToMeters()*_c*ToMeters(),9); }
    public double Area
    {
        get => Math.Round(2 * (_a*ToMeters() * _b*ToMeters() + _b*ToMeters() * _c*ToMeters() + _a*ToMeters() * _c*ToMeters()), 6);
    }
    public Box(double a=-99, double b=-99, double c=-99, UnitOfMeasure unit = UnitOfMeasure.meter)
    {
        if (a == -99)
        {
            a = unit switch
            {
                UnitOfMeasure.meter => 0.1,
                UnitOfMeasure.milimeter => 100,
                UnitOfMeasure.centimeter => 10,
                _ => a
            };
        }
        if (b == -99)
        {
            b = unit switch
            {
                UnitOfMeasure.meter => 0.1,
                UnitOfMeasure.milimeter => 100,
                UnitOfMeasure.centimeter => 10,
                _ => b
            };
        }
        if (c == -99)
        {
            c = unit switch
            {
                UnitOfMeasure.meter => 0.1,
                UnitOfMeasure.milimeter => 100,
                UnitOfMeasure.centimeter => 10,
                _ => c
            };
        }
        switch (unit)
        {
            case UnitOfMeasure.milimeter:
                a = Math.Round(a, 0);
                b = Math.Round(b, 0);
                c = Math.Round(c, 0);
                break;
            case UnitOfMeasure.centimeter:
                a = Math.Truncate(10 * a) / 10;
                b = Math.Truncate(10 * b) / 10;
                c = Math.Truncate(10 * c) / 10;
                break;
            case UnitOfMeasure.meter:
                a = Math.Truncate(1000 * a) / 1000;
                b = Math.Truncate(1000 * b) / 1000;
                c = Math.Truncate(1000 * c) / 1000;
                break;
        }

        BoxValidation( a, b,  c, unit);
        A = Math.Round(a*ToMilimeters(unit),0);
        B = Math.Round(b*ToMilimeters(unit),0);
        C = Math.Round(c*ToMilimeters(unit),0);
        Unit = UnitOfMeasure.milimeter;
    }
    void BoxValidation( double a,  double b,  double c, UnitOfMeasure unit)
    {
        
        switch (unit)
        {
            case UnitOfMeasure.centimeter:
                a = Math.Truncate(10 * a) / 10;
                b = Math.Truncate(10 * b) / 10;
                c = Math.Truncate(10 * c) / 10;
                if (a > 1000 || b > 1000 || c > 1000) throw new ArgumentOutOfRangeException();
                break;
            case UnitOfMeasure.meter:
                a = Math.Truncate(1000  * a) / 1000;
                b = Math.Truncate(1000  * b) / 1000;
                c = Math.Truncate(1000  * c) / 1000;
                if (a > 10 || b > 10 || c > 10) throw new ArgumentOutOfRangeException();
                break;
            case UnitOfMeasure.milimeter:
                a = Math.Round(a,2) ;
                b = Math.Round(b,2) ;
                c = Math.Round(c,2) ;
                if (a > 10000 || b > 10000 || c > 10000) throw new ArgumentOutOfRangeException();
                break;
        }
        if (a <= 0 || b <= 0 || c <= 0) throw new ArgumentOutOfRangeException();
    }
    double ToMeters()
    {
        return Unit switch
        {
            UnitOfMeasure.meter => 1,
            UnitOfMeasure.centimeter => 0.01,
            _ => 0.001
        };
    }

    double ToCentimeters()
    {
        return Unit switch
        {
            UnitOfMeasure.centimeter => 1,
            UnitOfMeasure.meter => 100 ,
            _ => 0.1
        };
    }
    double ToMilimeters()
    {
        return Unit switch
        {
            UnitOfMeasure.milimeter => 1,
            UnitOfMeasure.centimeter => 10,
            _ => 1000
        };
    }
    private double ToMilimeters(UnitOfMeasure unit)
    {
        return unit switch
        {
            UnitOfMeasure.milimeter => 1,
            UnitOfMeasure.centimeter => 10,
            _ => 1000
        };
    }
    public override string ToString()
    {
        return this.ToString("m", CultureInfo.CurrentCulture);
    }
    public string ToString(string format)
    {
        return this.ToString(format, CultureInfo.CurrentCulture);
    }
    public string ToString(string? format, IFormatProvider? provider)
    {
        if (String.IsNullOrEmpty(format)) format = "m";
        if (provider == null) provider = CultureInfo.CurrentCulture;
        char x = '\u00D7';
        switch (format.ToLowerInvariant())
        {
            case "m":
                return string.Format("{0:0.000} m {3} {1:0.000} m {3} {2:0.000} m", _a * ToMeters() , _b * ToMeters() ,
                    _c * ToMeters(), x);
            case "cm":
                return string.Format("{0:0.0} cm {3} {1:0.0} cm {3} {2:0.0} cm", _a * ToCentimeters(), _b * ToCentimeters(),
                    _c * ToCentimeters(), x);
            case "mm":
                return string.Format("{0:0} mm {3} {1:0} mm {3} {2:0} mm", _a * ToMilimeters(), _b * ToMilimeters(),
                    _c * ToMilimeters(), x);
            default: throw new FormatException(String.Format("The {0} format string is not supported.", format));
        }
    }
    public bool Equals(Box? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        if (_a == other._a && _b == other._b && _c == other._c)
            return true;
        else if (_a == other._a && _b == other._c && _c == other._b)
            return true;
        else if (_a == other._b && _b == other._c && _c == other._a)
            return true;
        else if (_a == other._c && _b == other._b && _c == other._a)
            return true;
        else if (_a == other._b && _b == other._a && _c == other._c)
            return true;
        else if (_a == other._c && _b == other._a && _c == other._b)
            return true;
        else
            return false;
    }
    public static Box operator +(Box p1, Box p2)
    {
        List<Box> pudelka = new List<Box>();
        pudelka.Add(new Box(p1._a+p2._a,p1._b+p2._b,p1._c+p2._c,UnitOfMeasure.milimeter));
        pudelka.Add(new Box(p1._a+p2._a,p1._b+p2._c,p1._c+p2._b,UnitOfMeasure.milimeter));
        pudelka.Add(new Box(p1._a+p2._b,p1._b+p2._c,p1._c+p2._a,UnitOfMeasure.milimeter));
        pudelka.Add(new Box(p1._a+p2._c,p1._b+p2._b,p1._c+p2._a,UnitOfMeasure.milimeter));
        pudelka.Add(new Box(p1._a+p2._b,p1._b+p2._a,p1._c+p2._c,UnitOfMeasure.milimeter));
        pudelka.Add(new Box(p1._a+p2._c,p1._b+p2._a,p1._c+p2._b,UnitOfMeasure.milimeter));

        Box? min=null;
        
        foreach (Box pud in pudelka)
        {
            if (min != null && pud.Volume > min.Volume) continue;
            min = pud;
        }

        return min;
    }

    public IEnumerator<double> GetEnumerator()
    {
        double[] arr = (double[]) this;
        foreach (var i in arr)
        {
            yield return i;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public override bool Equals(object? obj)
    {
        return obj is Box && Equals((Box)obj);
    }
    public override int GetHashCode() => (_a,_b,_c).GetHashCode();
    public static bool operator ==(Box p1, Box p2) => Equals(p1, p2);
    public static bool operator !=(Box p1, Box p2) => !(p1 == p2);

    public static explicit operator double[](Box p1) => new double[] {p1.A, p1.B, p1.C};
    
    public static implicit operator Box(ValueTuple<int, int, int> tuple)=>
         new Box(tuple.Item1,tuple.Item2,tuple.Item3, UnitOfMeasure.milimeter);

    public double this[int index]
    {
        get
        {
            return index switch
            {
                0 => A,
                1 => B,
                2 => C,
                _ => throw new IndexOutOfRangeException()
            };
        }
    }

    public static Box Parse(string val)
    {
        List<double> dim = new List<double>();
        string[] input = val.Split(' ');
        foreach (var i in input)
        {
            if (double.TryParse(i.Replace(".",","), out double temp))
                dim.Add(temp);
        }

        UnitOfMeasure unit;

        if (input[1] == input[4] && input[4] == input[7])
            unit = input[7].ToLower() switch
            {
                "m" => UnitOfMeasure.meter,
                "cm" => UnitOfMeasure.centimeter,
                "mm" => UnitOfMeasure.milimeter,
                _ => throw new FormatException("Incorrect unit")
            };
        else throw new FormatException("Incorrect unit");
        
        return dim.Count == 3
            ? new Box(dim[0], dim[1], dim[2], unit)
            : throw new FormatException("Incorrect input!");
    }
    public static int Comparison(Box p1, Box p2)
    {
        var p1Sum = p1.A + p1.B + p1.C;
        var p2Sum = p2.A + p2.B + p2.C;
        if (p1.Volume < p2.Volume) return -1;
        if (p1.Volume > p2.Volume) return 1;
        if (p1.Area < p2.Area) return -1;
        if (p1.Area > p2.Area) return 1;
        if (p1Sum < p2Sum) return -1;
        if (p1Sum > p2Sum) return 1;
        return 0;
    }
}