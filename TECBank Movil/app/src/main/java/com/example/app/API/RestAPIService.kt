import android.util.Log
import android.widget.TextView
import com.example.app.API.Cuenta
import com.example.app.API.Usuarios
import com.example.app.Funciones.OpcionCuentas
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class RestAPIService {
    fun addUser(userData: Usuarios) {
        val retrofit = ServiceBuilder.buildService(RestAPI::class.java)
        retrofit.addUser(userData).enqueue(
            object : Callback<Usuarios> {
                override fun onFailure(call: Call<Usuarios>, t: Throwable) {
                    Log.d("Error", t.message)
                }

                override fun onResponse(call: Call<Usuarios>, response: Response<Usuarios>) {
                    Log.d("Exito", "JSON enviado")
                }
            }
        )
    }

    fun getAccount(detalles: TextView) {
        val retrofit = ServiceBuilder.buildService(RestAPI::class.java)
        retrofit.getAccount().enqueue(object : Callback<List<Cuenta>> {
            override fun onResponse(call: Call<List<Cuenta>>, response: Response<List<Cuenta>>) {
                val datos = response.body()

                if (datos != null) {
                    OpcionCuentas().verCuenta(datos,detalles)
                }

                for (c in datos!!)
                    Log.d(
                        "CUENTA: ",
                        "Numero de cuenta: ${c.numero_cuenta} " +
                                "\n Descripcion: ${c.descripcion} " +
                                "\n Moneda: ${c.moneda} " +
                                "\n Tipo de cuenta: ${c.tipo_cuenta} " +
                                "\n Cliente: ${c.acliente}"
                    )

            }

            override fun onFailure(call: Call<List<Cuenta>>, t: Throwable) {
                Log.d("Error", t.message)
            }
        })

    }

}