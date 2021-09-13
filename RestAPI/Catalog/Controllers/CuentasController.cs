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
    [Route("cuentas")]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentasRepository repository;

        public CuentasController(ICuentasRepository repository)
        {
            this.repository = repository;

        }

        //GET /items 
        [HttpGet]
        public IEnumerable<CuentaDto> GetCuenta()
        {
            var cuentas = repository.GetCuentas().Select( cuenta => cuenta.c_AsDto());
            
            return cuentas;
        }

        //GET /items/{numero}
        [HttpGet("{numero}")]
        public ActionResult<CuentaDto> GetCuenta(Guid numero)
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
        public ActionResult UpdateCuentaDto(Guid numero, UpdateCuentaDto cuentaDto)
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
        public ActionResult DeleteCuenta(Guid numero)
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