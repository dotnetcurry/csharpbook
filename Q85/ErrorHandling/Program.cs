using System;
using System.IO;

namespace ErrorHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // code which can throw exceptions
            }
            catch
            {
                // code executed only if an exception was thrown
            }
            finally
            {
                // code executed whether an exception was thrown or not
            }

            try
            {
                // code which can throw exceptions
            }
            catch (Exception ex)
            {
                // code can access exception details in variable e
            }

            try
            {
                // code which can throw exceptions
            }
            catch (FileNotFoundException ex)
            {
                // code will only handle FileNotFoundException and its descendants
            }
            catch (Exception ex)
            {
                // code will handle all the other exceptions
            }

            try
            {
                // code which can throw exceptions
            }
            catch (ArgumentException ex) when (ex.ParamName == "input")
            {
                // code will only handle ArgumentException for parameter named "input"
            }

            try
            {
                // code which can throw exceptions
            }
            catch (Exception ex)
            { }
        }

        void MyMethod()
        {
            try
            {
                // actual method body
            }
            catch (Exception ex)
            {
                // exception handling code
            }
        }

    }
}
