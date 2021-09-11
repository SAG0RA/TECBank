import android.util.Log
import com.example.app.Usuarios
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import retrofit2.Retrofit

class RestApiService {
    fun addUser(userData: Usuarios){
        val retrofit = ServiceBuilder.buildService(RestApi::class.java)
        retrofit.addUser(userData).enqueue(
            object : Callback<Usuarios> {
                override fun onFailure(call: Call<Usuarios>, t: Throwable) {
                    Log.d("MAL PAPA MAL",t.message)
                }
                override fun onResponse( call: Call<Usuarios>, response: Response<Usuarios>) {
                    Log.d("Exito","EASY GAME")
                }
            }
        )
    }
}