package com.example.app.Funciones

import RestAPIService
import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import com.example.app.API.Cuenta
import com.example.app.R
import kotlinx.android.synthetic.main.cuentas.*

class OpcionCuentas : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.cuentas)
        val detalles: TextView = findViewById(R.id.numero_cuenta) as TextView

        ///////////////API////////////////
        //Funcion encargada de solicitar GET del API mediante un boton en la pantalla
        btncargar.setOnClickListener {
            val API = RestAPIService()
            API.getAccount(detalles)
        }
        //Pantalla transferencia
        btntransferir.setOnClickListener {
            startActivity(
                Intent(this, Tranferencias::class.java)
            )
        }
        //Pantalla tarjetas
        btntarjetas1.setOnClickListener {
            startActivity(
                Intent(this, Tarjetas::class.java)
            )
        }
    }

    /** Funcion encarcada de mostrar detalles de la cuenta del GET en pantalla
     *@param datos informacion del API
     * @param detalles pantalla para ver los detalles
     */
    fun verCuenta(datos: List<Cuenta>, detalles: TextView) {
        for (c in datos!!) {
            detalles.text = "Numero de cuenta: " + "${c.numero_cuenta}" +
                    "\n Descripcion: ${c.descripcion}" +
                    "\n Moneda: ${c.moneda}" +
                    "\n Tipo de cuenta: ${c.tipo_cuenta} "
        }
    }
}