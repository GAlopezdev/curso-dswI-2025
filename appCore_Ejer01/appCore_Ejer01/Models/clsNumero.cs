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
    }
}
