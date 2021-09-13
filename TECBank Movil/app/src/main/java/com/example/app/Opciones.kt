package com.example.app

import android.content.Intent
import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import kotlinx.android.synthetic.main.opciones.*


class Opciones: AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.opciones)

        btncuentas.setOnClickListener {
            startActivity(Intent(this, Registro::class.java))
        }

        btntarjetas.setOnClickListener {

        }

        btnprestamos.setOnClickListener {

        }

    }
}