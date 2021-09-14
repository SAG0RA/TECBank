import com.example.app.API.Usuarios
import com.example.app.API.Cuenta
import retrofit2.Call
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.Headers
import retrofit2.http.POST

interface RestAPI {
        @Headers("Content-Type: application/json")
        @POST("/items")
        fun addUser(@Body userData: Usuarios): Call<Usuarios>

        @GET("/cuentas")
        fun getAccount(): Call<List<Cuenta>>
}