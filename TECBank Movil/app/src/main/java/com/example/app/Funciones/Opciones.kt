package com.example.app.Funciones

import RestAPIService
import android.content.Intent
import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.example.app.R
import kotlinx.android.synthetic.main.opciones.*


class Opciones: AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.opciones)

        btncuentas.setOnClickListener {
            val API = RestAPIService()
            API.getAccount()
//            startActivity(Intent(this, Registro::class.java))
        }

        btntarjetas.setOnClickListener {

        }

        btnprestamos.setOnClickListener {

        }

    }
}