using System;
using System.Linq;
using System.Collections.Generic;
using Catalog.Entities;

namespace Catalog.Repositorios
{
    public class InMemCuentasRepository : ICuentasRepository //En esta clase se detallan los metodos de comunicacion y se precarga el repositorio de cuentas 
    {
        private readonly List<Cuenta> lista_cuentas = new()
        {
            new Cuenta {numero_cuenta = Guid.NewGuid(), descripcion= "Cuenta de ahorros de la beca", moneda = "colones", tipo_cuenta = "ahorro", Acliente= "Steven"}

        };
        
        public IEnumerable<Cuenta> GetCuentas() //Obtiene objetos del repositorio
        {
            return lista_cuentas;
        }
        public Cuenta GetCuenta(Guid numero) //Obtiene objetos del repositorio por numero 
        {
            return lista_cuentas.Where(cuenta => cuenta.numero_cuenta == numero).SingleOrDefault();
        }

        public void CreateCuenta(Cuenta cuenta)  //Anade objetos al repositorio
        {
            lista_cuentas.Add(cuenta);
        }

        public void UpdateCuenta(Cuenta cuenta) //Actualiza objetos al repositorio
        {
            var index = lista_cuentas.FindIndex(existingItem => existingItem.numero_cuenta == cuenta.numero_cuenta); 
            lista_cuentas[index] = cuenta;
        }

        public void DeleteCuenta(Guid numero) //Borrar objetos del repositorio
        {
            var index = lista_cuentas.FindIndex(existingItem => existingItem.numero_cuenta == numero);
            lista_cuentas.RemoveAt(index);
            
        }
    }


}