import android.util.Log
import com.example.app.API.Cuenta
import com.example.app.API.Usuarios
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class RestAPIService {
    fun addUser(userData: Usuarios){
        val retrofit = ServiceBuilder.buildService(RestAPI::class.java)
        retrofit.addUser(userData).enqueue(
            object : Callback<Usuarios> {
                override fun onFailure(call: Call<Usuarios>, t: Throwable) {
                    Log.d("Error",t.message)
                }
                override fun onResponse(call: Call<Usuarios>, response: Response<Usuarios>) {
                    Log.d("Exito","JSON enviado")
                }
            }
        )
    }

    fun getAccount(){
        val retrofit = ServiceBuilder.buildService(RestAPI::class.java)
        retrofit.getAccount().enqueue(object : Callback<List<Cuenta>> {
            override fun onResponse(call: Call<List<Cuenta>>, response: Response<List<Cuenta>>) {
                val datos = response.body()
                for (c in datos!!)
                    Log.v("CUENTA: ",
                        "Numero de cuenta: ${c.numero_cuenta} " +
                                "\n Descripcion: ${c.descripcion} " +
                                "\n Moneda: ${c.moneda} " +
                                "\n Tipo de cuenta: ${c.tipo_cuenta} " +
                                "\n Cliente: ${c.cliente}")
            }
            override fun onFailure(call: Call<List<Cuenta>>, t: Throwable) {
                Log.i("Error", "No recibio los datos de la cuenta")
            }

        })
    }


}