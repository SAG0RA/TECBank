package com.example.app.Funciones

import android.content.Intent
import android.os.Bundle
import android.widget.EditText
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.example.app.R
import kotlinx.android.synthetic.main.content_main.*



class Login : AppCompatActivity() {


    override fun onCreate(savedInstanceState: Bundle?) {

        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        //Variables para recibir los datos de entrada de usuario y contraseña
        val usuario_input = findViewById<EditText>(R.id.inputusuario) as EditText
        val contrasena_input = findViewById<EditText>(R.id.inputcontrasena) as EditText

        val usuario_recibido = intent
        val contrasena_recibida = intent
        var usuario_registrado = usuario_recibido.getStringArrayListExtra("Usuarios")
        var contrasena_registrada = contrasena_recibida.getStringArrayListExtra("Contrasena")

        //Botón de acceso a la ventana de Administrar Carrito
        btnentrar.setOnClickListener {

            val usuario = usuario_input.text.toString()
            val contrasena = contrasena_input.text.toString()
//            Log.d("Usuarios pasados: ",usuario_registrado.toString())

            //////////////////////   VALIDACIONES ///////////////////////////
            // IMPORTANTE, SI EL USUARIO NO SE HA REGISTRADO E INTENTA LOGUEAR, LA APLICACION SE CIERRA AUTOMATICAMENTEA
            // usuario_registrado.contains(usuario) || !contrasena_registrada.contains(contrasena)
            if (false){
                //Se despliega un mensaje de alerta solicitando datos válidos para el ingreso
                Toast.makeText(this, "Favor ingresar datos válidos", Toast.LENGTH_LONG).show()
            }
            else{
                startActivity(Intent(this, OpcionCuentas::class.java))
            }
        }

        //Botón de acceso a la ventana de Registro
        btnregistrarse.setOnClickListener {
            startActivity(Intent(this, Registro::class.java))
        }

    }
}
