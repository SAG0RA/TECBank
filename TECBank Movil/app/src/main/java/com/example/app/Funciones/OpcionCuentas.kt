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
        btncargar.setOnClickListener {
            val API = RestAPIService()
            API.getAccount(detalles)
        }
        btntransferir.setOnClickListener {
            startActivity(
                Intent(this, Tranferencias::class.java)
            )
        }
    }

    fun verCuenta(datos: List<Cuenta>, detalles: TextView) {
        for (c in datos!!) {
            detalles.text = "Numero de cuenta: " + "${c.numero_cuenta}" +
                    "\n Descripcion: ${c.descripcion}" +
                    "\n Moneda: ${c.moneda}" +
                    "\n Tipo de cuenta: ${c.tipo_cuenta} "
        }
    }
}