namespace appCore_Ejer01.Models
{
    public class clsNumero
    {
        // Esta clase tiene 2 metodos :
        // EsPrimo, que determina si un numero es primo o no
        // calcularFactorial, que calcula el factorial de un numero

        public double Numero { get; set; }
        public bool EsPrimoResultado { get; set; }
        public double FactorialResultado { get; set; }

        public static bool EsPrimo(double numero)
        {
            for (int i = 2; i <= numero/2; i++)
            {
                if (numero % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static double CalcularFactorial(double numero)
        {
            try
            {
                double factorialResultado = 1;
                for (int i = 1; i <= numero; i++)
                {
                    factorialResultado *= i;
                }
                return factorialResultado;
            }
            catch (Exception ex)
            {
                throw new
                Exception("Valor muy grande " + ex.Message);
            }
        }
    }
}
