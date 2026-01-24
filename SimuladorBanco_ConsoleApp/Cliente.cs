using System;
using System.Collections.Generic;
using System.Text;

namespace SimuladorBanco_ConsoleApp
{
    public class Cliente
    {
        public string Nombre { get; private set; }
        public string Documento { get; private set; }

        private List<CuentaBancaria> Cuentas = new List<cuentaBancaria>();
        public IReadOnlyList<CuentaBancaria> Cuentas => _cuentas; //solo lectura desde afuera

        public Cliente(string nombre, string documento)
        {
            Nombre = nombre;
            Documento = documento;
        }

        public void AgregarCuenta(CuentaBancaria cuenta)
        {
            _cuentas.Add(cuenta);
        }

        public override string ToString()
        {
            return $"{Nombre} (Doc: {Documento}) - Cuentas: {_cuentas.Count}";

        }
    }
}
