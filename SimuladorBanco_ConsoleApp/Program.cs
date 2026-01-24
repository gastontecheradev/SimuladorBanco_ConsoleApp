using System;

namespace SimuladorBanco_ConsoleApp
{ 
    internal class SimuladorBanco_ConsoleApp
    {
        static void Main(string[] args)
        {
            var cuenta = new CuentaBancaria(titular: "Juan", numeroCuenta: "001-123", saldoInicial: 0m);

            int opcion;

            // Menu de opciones
            do
            {
                Console.Clear();
                Console.WriteLine("=== SIMULADOR DE BANCO (Paso 1) ===");
                Console.WriteLine(cuenta.ObtenerResumen());
                Console.WriteLine();
                Console.WriteLine("1) Depositar");
                Console.WriteLine("2) Extraer");
                Console.WriteLine("3) Ver saldo");
                Console.WriteLine("0) Salir");
                Console.Write("Opción: ");

                opcion = LeerEntero();

                Console.WriteLine();

                switch(opcion)
                {
                    case 1:
                        Console.Write("Monto a depositar: ");
                        decimal montoDep = LeerDecimal();
                        if (cuenta.Depositar(montoDep))
                            Console.WriteLine("Depósito OK.");
                        else
                            Console.WriteLine("Monto incorrecto.");
                        Pausa();
                            break;

                    case 2:
                        Console.Write("Monto a extraer: ");
                        decimal montoExt = LeerDecimal();
                        if (cuenta.Extraer(montoExt))
                            Console.WriteLine("Extracción OK.");
                        else
                            Console.WriteLine("Monto incorrecto o saldo insuficiente.");
                        Pausa();
                        break;

                    case 3:
                        Console.WriteLine($"Saldo actual: {cuenta.Saldo:C}");
                        Pausa();
                        break;

                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;
                        
                    default:
                        Console.WriteLine("opción incorrecta.");
                        Pausa();
                        break;
                }
            } while (opcion != 0);
        }

        // Método para leer el número
        static int LeerEntero()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out int valor))
                    return valor;

                Console.WriteLine("Ingrese un número correcto: ");
            }
        }

        // Método para leer el monto
        static decimal LeerDecimal()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal valor))
                    return valor;

                Console.WriteLine("Ingrese un monto correcto");
            }
        }

        // Pausa
        static void Pausa()
        {
            Console.WriteLine();
            Console.Write("Presione Enter para continuar...");
            Console.ReadLine();
        }

    }

    // Clase Cuenta Bancaria
    public class CuentaBancaria
    {
        // Propiedades (datos de la cuenta)
        public string Titular { get; private set; }
        public string NumeroCuenta { get; private set; }
        public decimal Saldo { get; private set; }

        // Constructor de cuenta bancaria
        public CuentaBancaria(string titular, string numeroCuenta, decimal saldoInicial)
        {
            Titular = titular;
            NumeroCuenta = numeroCuenta;
            Saldo = saldoInicial;
        }

        // Método para Depositar
        public bool Depositar(decimal monto)
        {
            if (monto <= 0) return false;

            Saldo += monto;
            return true;
        }

        // Método para Extraer
        public bool Extraer(decimal monto)
        {
            if (monto <= 0) return false;
            if (monto > Saldo) return false;

            Saldo -= monto;
            return true;
        }

        // Método para obtener resumen
        public string ObtenerResumen()
        {
            return $"Titular: {Titular} | Cuenta: {NumeroCuenta} | Saldo: {Saldo:C}";
        }
    }
}