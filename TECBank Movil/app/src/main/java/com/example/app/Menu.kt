package com.example.app

import android.content.Intent
import android.os.Bundle
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import kotlinx.android.synthetic.main.opciones_cuenta.*


class Menu: AppCompatActivity() {

    //private lateinit var binding: ActivityMainBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.opciones_cuenta)

        //Botón para avanzar a lo largo de los menus disponibles
        btncuentas.setOnClickListener {
            startActivity(Intent(this, Registrarse::class.java))
        }

        //Botón para retroceder a lo largo de los menus disponibles
        btntarjetas.setOnClickListener {

        }

        //Boton para agregar al carrito
        btnprestamos.setOnClickListener {

        }

    }
}