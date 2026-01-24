using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SimuladorBanco_ConsoleApp
{
    public class Banco
    {
        public string Nombre { get; private set; }

        private List<Cliente> _clientes = new List<Cliente>();
        private List<CuentaBancaria> _cuentas = new List<CuentaBancaria>();

        public IReadOnlyList<Cliente> Clientes => _clientes;
        public IReadOnlyList<CuentaBancaria> Cuentas => _cuentas;

        public Banco(string nombre)
        {
            Nombre = nombre;
        }

        public Cliente? BuscarClientePorDocumento(string documento)
        {
            return _clientes.FirstOrDefault(c => c.Documento == documento);
        }

        public CuentaBancaria? BuscarCuentaPorNumero(string numeroCuenta)
        {
            return _cuentas.FirstOrDefault(c => c.NumeroCuenta == numeroCuenta);
        }

        public bool CrearCuenta(string nombreCliente, string documento, string numeroCuenta, decimal saldoInicial)
        {
            if (BuscarCuentaPorNumero(numeroCuenta) != null) return false;

            var cliente = BuscarClientePorDocumento(documento);
            if (cliente == null)
            {
                cliente = new Cliente(nombreCliente, documento);
                _clientes.Add(cliente);
            }

            var cuenta = new CuentaBancaria(cliente.Nombre, numeroCuenta, saldoInicial);
            _cuentas.Add(cuenta);
            cliente.AgregarCuenta(cuenta);

            return true;
        }
    }
}
