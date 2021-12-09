using System;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's Real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        // TODO: fill this class\
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public Complex(double real, double imaginary)
        {
            this.Real = real;
            this.Imaginary = imaginary;
        }

        public double Modulus => Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));

        public double Phase => Math.Atan2(Imaginary, Real);

        public Complex Plus(Complex c) => new Complex(this.Real + c.Real, this.Imaginary + c.Imaginary);

        public Complex Minus(Complex c) => new Complex(this.Real - c.Real, this.Imaginary - c.Imaginary);

        public Complex Complement() => new Complex(this.Real, -this.Imaginary);

        public override string ToString()
        {
            string r = "";
            
            if (Real != 0)
            {
                r += Real.ToString();
            }
            if(Imaginary != 0)
            {
                if(Imaginary > 0)
                {
                    r += (Real != 0 ? "+" : "") + (Math.Abs(Imaginary) != 1 ? Imaginary.ToString() : "") + "i";
                }
                else
                {
                    r += (Math.Abs(Imaginary) != 1 ? Imaginary.ToString() : "") + "i";
                }
            }
            return (r.CompareTo("") == 0 ? r = "0" : r); 
        }

        public bool Equals(Complex c) => this.Real == c.Real && this.Imaginary == c.Imaginary;
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Complex)obj);
        }

        public override int GetHashCode() => HashCode.Combine(Real, Imaginary);
    }
}