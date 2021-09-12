package com.example.app

import RestApiService
import android.os.Bundle
import android.util.Log
import android.widget.*
import androidx.appcompat.app.AppCompatActivity
import com.google.gson.Gson
import com.google.gson.JsonParser
import kotlinx.android.synthetic.main.registrarse.*
import org.json.JSONObject
import timber.log.Timber

class Registrarse: AppCompatActivity() {

    //Se crea el array para almacenar los usuarios creados en la actividad de Registro
    var usuarios_registrados = ArrayList<String>()

    //Se crea el array para almacenar las contraseñas guardadas en la actividad de Registro
    var contrasenas_registradas = ArrayList<String>()

    override fun onCreate(savedInstanceState: Bundle?) {

        super.onCreate(savedInstanceState)
        setContentView(R.layout.registrarse)
        //Se llama la  función de SelecciónFecha
        inputfechac.setOnClickListener{ SelecciondeFecha() }

        //Variables para recibir los datos de entrada de los usuarios
        val usuario_input2 = findViewById<EditText>(R.id.inputcorreor) as EditText
        val contrasena_input2 =  findViewById<EditText>(R.id.inputcontrasenar) as EditText
        val name_input = findViewById<EditText>(R.id.inputnombre) as EditText
        val Fname_input = findViewById<EditText>(R.id.inputpapellido) as EditText
        val Lname_input = findViewById<EditText>(R.id.inputsapellido) as EditText
        val id_input = findViewById<EditText>(R.id.inputcedula) as EditText
        val date_input = findViewById<EditText>(R.id.inputfechac) as EditText
        val phone_input = findViewById<EditText>(R.id.inputtelefono) as EditText

        //Sección de función para el botón de registrar
        btnregistrar.setOnClickListener {

            //Las variables toman los datos de entrada en la ventana de registro
            //Las que se deben almacenar en el array son usario y contraseña
            val usuario = usuario_input2.text.toString()
            val contrasena = contrasena_input2.text.toString()
            val nombre = name_input.text.toString()
            val p_apellido = Fname_input.text.toString()
            val s_apellido = Lname_input.text.toString()
            val cedula = id_input.text.toString()
            val fecha = date_input.text.toString()
            val telefono = phone_input.text.toString()

            //Se almacenan los datos para que estos puedan ser enviados a la actividad principal
            //Se envían a la función de Almacenamiento para que se escriban en la posición siguiente
            //Esto evita que el array solo tenga un elemento guardado
            usuarios_registrados.add(usuario)
            contrasenas_registradas.add(contrasena)

            ////////////// API //////////////////
            val apiService = RestApiService()
            val userInfo = Usuarios(userID = null, userDate = "", userEmail = usuario, userFName = p_apellido,
                userUID = cedula.toInt(),
                userSName = s_apellido,
                userName = nombre,
                userPassword = contrasena,
                userPhone = telefono.toInt()
            )

            apiService.addUser(userInfo)
            this.finish()
        }

    }

    /**
        Este par de funciones son las encargadas de seleccionar  y desplegar visualmente
        las fecha que sea escogida en el usuario en la ventana se usuario
     **/

    private fun SelecciondeFecha(){
        //Se envia a la función de Seleccion, la fecha dividida de la selección
        //Se invoca de igual forma la clase encargada del date picker
       val datePicker = SeleccionFecha {dia, mes, ano -> Seleccion(dia, mes, ano)}
        datePicker.show(supportFragmentManager, "Fecha")
    }

    fun Seleccion(dia:Int, mes:Int, ano:Int){
        //Se despliega en el inputtext de fecha el día, mes y año correspondiente
        inputfechac.setText("$dia-$mes-$ano")
    }

    fun getUsuarios(): ArrayList<String> {
        return usuarios_registrados
    }

    fun getContrasenas(): ArrayList<String> {
        return usuarios_registrados
    }

}