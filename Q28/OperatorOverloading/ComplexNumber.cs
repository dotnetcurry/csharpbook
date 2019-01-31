using System;
using System.Collections.Generic;
using System.Text;

namespace OperatorOverloading
{
    public struct ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public static ComplexNumber Add(ComplexNumber complex1, ComplexNumber complex2)
        {
            var real = complex1.Real + complex2.Real;
            var imaginary = complex1.Imaginary + complex2.Imaginary;
            return new ComplexNumber(real, imaginary);
        }

        public static ComplexNumber operator +(ComplexNumber complex1, ComplexNumber complex2)
        {
            var real = complex1.Real + complex2.Real;
            var imaginary = complex1.Imaginary + complex2.Imaginary;
            return new ComplexNumber(real, imaginary);
        }

        public static ComplexNumber operator +(ComplexNumber complex, double real)
        {
            return new ComplexNumber(complex.Real + real, complex.Imaginary);
        }

        public static ComplexNumber operator -(ComplexNumber complex)
        {
            return new ComplexNumber(-complex.Real, -complex.Imaginary);
        }

        public static bool operator ==(ComplexNumber complex1, ComplexNumber complex2)
        {
            return complex1.Real == complex2.Real && complex1.Imaginary == complex2.Imaginary;
        }

        public static bool operator !=(ComplexNumber complex1, ComplexNumber complex2)
        {
            return !(complex1 == complex2);
        }

        public static explicit operator double(ComplexNumber complex)
        {
            return complex.Real;
        }

        //public static implicit operator double(ComplexNumber complex)
        //{
        //    return complex.Real;
        //}
    }

}
