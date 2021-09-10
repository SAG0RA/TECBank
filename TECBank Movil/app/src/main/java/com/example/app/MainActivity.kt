package com.example.app

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.widget.EditText
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import kotlinx.android.synthetic.main.content_main.*



class MainActivity : AppCompatActivity() {


    override fun onCreate(savedInstanceState: Bundle?) {

        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        //Variables para recibir los datos de entrada de usuario y contraseña
        val usuario_input = findViewById<EditText>(R.id.inputusuario) as EditText
        val contrasena_input = findViewById<EditText>(R.id.inputcontrasena) as EditText

        //Botón de acceso a la ventana de Administrar Carrito
        btnentrar.setOnClickListener {
            var Registro = Registrarse()
            var usuarios_registrados = Registro.getUsuarios()
            var contrasenas_registradas = Registro.getContrasenas()


            val usuario = usuario_input.text.toString()
            val contrasena = contrasena_input.text.toString()
            Log.d("NANIX2","asdsadaf " + usuario)
            for(i in usuarios_registrados.indices){
                Log.d("NANI","onCreate users: " + usuarios_registrados.get(i))

            }
            //////////////////////   VALIDACIONES ///////////////////////////
            if ((usuario_input.text.toString().isNullOrEmpty() || contrasena_input.text.toString().isNullOrEmpty())){
                //Se despliega un mensaje de alerta solicitando datos válidos para el ingreso

                Toast.makeText(this, "Favor ingresar datos válidos", Toast.LENGTH_LONG).show()
            }
            else{
                startActivity(Intent(this, Menu::class.java))
            }
        }

        //Botón de acceso a la ventana de Registro
        btnregistrarse.setOnClickListener {
            startActivity(Intent(this, Registrarse::class.java))
        }

    }
}
