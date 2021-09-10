import com.example.app.Usuarios
import retrofit2.Call
import retrofit2.http.Body
import retrofit2.http.Headers
import retrofit2.http.POST

interface RestApi {
        @Headers("Content-Type: application/json")
        @POST("/items")
        fun addUser(@Body userData: Usuarios): Call<Usuarios>
}