using System;
using Microsoft.AspNetCore.Mvc;
using Catalog.Repositorios;
using Catalog.Entities;
using System.Collections.Generic;
using System.Linq;
using Catalog.Dtos;
namespace Catalog.Controllers
{

    //Get /items
    [ApiController]
    [Route("cuentas")] //Ruta en donde se encontrara el JSON de las cuentas
    public class CuentasController : ControllerBase
    {
        private readonly ICuentasRepository repository;

        public CuentasController(ICuentasRepository repository)
        {
            this.repository = repository; //Le pasamos el json precargado a la aplicación 

        }

        //GET /items 
        [HttpGet]
        public IEnumerable<CuentaDto> GetCuenta()
        {
            var cuentas = repository.GetCuentas().Select( cuenta => cuenta.c_AsDto()); //Convierte las cuentas del repositorio en DTOs
            
            return cuentas;
        }

        //GET /items/{numero}
        [HttpGet("{numero}")]
        public ActionResult<CuentaDto> GetCuenta(Guid numero) //Busca una cuenta por numero
        {
            var cuenta = repository.GetCuenta(numero);

            if (cuenta is null)
            {
                return NotFound();
            }

            return cuenta.c_AsDto();
        }

        //POST /items
        [HttpPost]
        public ActionResult<CuentaDto> CreateItem(CreateCuentaDto cuentaDto)
        {
            Cuenta cuenta = new()
            {
                //Anade una nueva cuenta al repositorio
                numero_cuenta = Guid.NewGuid(),
                descripcion = cuentaDto.descripcion,
                moneda = cuentaDto.moneda, 
                tipo_cuenta = cuentaDto.tipo_cuenta,
                Acliente = cuentaDto.Acliente,
            };

            repository.CreateCuenta(cuenta); //Anadimos el objeto al repositorio

            return CreatedAtAction(nameof(GetCuenta), new {numero = cuenta.numero_cuenta}, cuenta.c_AsDto()); //Creamos un header que especifica donde encontrar info acerca del objeto creado

        }

        //PUT /items
        [HttpPut("{numero}")]
        public ActionResult UpdateCuentaDto(Guid numero, UpdateCuentaDto cuentaDto) //Actualiza la info de una cuenta
        {
            var existingCuenta = repository.GetCuenta(numero);

            if (existingCuenta is null)
            {
                return NotFound();
            }

            Cuenta updatedCuenta = existingCuenta with {
                descripcion = cuentaDto.descripcion,
                tipo_cuenta = cuentaDto.tipo_cuenta
            };

            repository.UpdateCuenta(updatedCuenta);

            return NoContent();
        }

        //Delete /items/{numero}
        [HttpDelete("{numero}")]
        public ActionResult DeleteCuenta(Guid numero) //Borra una cuenta segun su ID
        {
            var existingCuenta = repository.GetCuenta(numero);

            if (existingCuenta is null)
            {
                return NotFound();
            }

            repository.DeleteCuenta(numero);

            return NoContent();
        }
    }
}