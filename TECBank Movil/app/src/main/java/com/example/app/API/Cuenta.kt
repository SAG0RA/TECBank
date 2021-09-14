package com.example.app.API

data class Cuenta(
    val numero_cuenta: String,
    val descripcion: String,
    val moneda: String,
    val tipo_cuenta: String,
    val cliente: String
)