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

            for(i in usuarios_registrados.indices){
                Log.d("NANI","onCreate users: " + usuarios_registrados.get(i))
            }

            ////////////// API //////////////////

            val apiService = RestApiService()
            val userInfo = Usuarios(  userName = nombre,
                userFName = p_apellido,
                userLName = s_apellido,
                userID = cedula,
                userDate = fecha,
                userPhone = telefono,
                userPassword = contrasena,
                userEmail = usuario)

            val JsonUser = Gson().toJson(userInfo)  // json string
            Log.d("JsonUser","onCreateJSONUser " + JsonUser)

            apiService.addUser(userInfo) {
                if (it?.userName != null) {
                    // it = newly added user parsed as response
                    // it?.id = newly added user ID
                } else {
                    Log.d("Error de UsuarioJSON","Error registering new user")
                }
            }

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

























/*

//Se declaran las variables para la sección de los spinner de provincia, canton y  dsitrito
        val provincia = findViewById<Spinner>(R.id.spnprovincia)
        val canton = findViewById<Spinner>(R.id.spncanton)
        val distrito = findViewById<Spinner>(R.id.spndistrito)

        //Se toman las listas de arrays creadas en la sección de values/strings del proyecto para
        //poder trabajar con ellos y mostrar lo que estan almacenan en la interfaz
        val provincias_lista = resources.getStringArray(R.array.provincias)

        val opciones_provincias = ArrayAdapter(this,android.R.layout.simple_spinner_dropdown_item, provincias_lista)
        provincia.adapter = opciones_provincias

        //Se implementa la función propia del spinner para cuando sea seleccionado un elemento del mismo
        provincia.onItemSelectedListener = object: AdapterView.OnItemSelectedListener{
            //Función implementada cuando es seleccionado uno de los elementos del spinner de provincias
            //El elemento importante es el id, ya que este dará la posición en el array de opciones
            override fun onItemSelected(parent: AdapterView<*>?, view: View?, position: Int, id: Long) {

                //Se selecciona la primera letra de la opción de provincia, ya que para esto
                //Se tiene que llamar de inmediato el spinner de los cantones según dicha provincia
                //El array de cantones tiene por nombre Iniicial de Provincia en Mayúscula + cantones
                val seleccion = provincias_lista[position].first().toString() + "cantones"
                Toast.makeText(this@Registrarse, seleccion,Toast.LENGTH_LONG).show()

            }
            override fun onNothingSelected(parent: AdapterView<*>?) {
                TODO("Not yet implemented")
            }
        }
* */