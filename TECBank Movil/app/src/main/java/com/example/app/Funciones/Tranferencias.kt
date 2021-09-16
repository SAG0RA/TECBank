package com.example.app.Funciones

import android.content.Intent
import android.os.Bundle
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.example.app.R
import kotlinx.android.synthetic.main.transferencias.*

class Tranferencias : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.transferencias)
        var saldo_str = "6900000"
        val cuenta_deposito = findViewById<EditText>(R.id.cuenta_dep) as EditText
        val monto_deposito = findViewById<EditText>(R.id.montodep) as EditText
        val saldo: TextView = findViewById(R.id.saldo) as TextView
        saldo.text = saldo_str

        btndepositar.setOnClickListener(){
            var saldo_int = saldo_str.toInt()
            val monto_str = monto_deposito.text.toString()
            val monto = monto_deposito.text.toString().toInt()
            val cuenta = cuenta_deposito.text.toString()
            if((saldo_int - monto < 0) || saldo_int < 0 || monto > saldo_int || cuenta.isNullOrEmpty() || monto_str.isNullOrEmpty()){
                Toast.makeText(this, "No se puede realizar el movimiento", Toast.LENGTH_LONG).show()
            }else{
                val nuevo_saldo = saldo_int - monto
                saldo.text = nuevo_saldo.toString()
            }
        }

    }

}