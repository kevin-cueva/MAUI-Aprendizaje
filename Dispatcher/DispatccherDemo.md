## Qué es el Dispatcher?

En MAUI (y en general en frameworks de UI como WPF, Xamarin, etc.), 
**el Dispatcher es el encargado de ejecutar código en el hilo principal (UI thread).**

La interfaz gráfica (labels, botones, listas, etc.) solo puede modificarse desde el hilo principal.

Pero muchas veces lanzamos tareas en hilos secundarios (por ejemplo, procesos largos como descargas, cálculos pesados, llamadas a APIs).

Si intentas actualizar la UI desde un hilo secundario, obtendrás un error.

Para solucionarlo, usamos el Dispatcher, que “manda de vuelta” el código al hilo principal.


### IsDispatchRequired
es una propiedad que responde:
true → si NO estamos en el hilo de UI y por lo tanto necesitamos “despachar” (mover) la ejecución al hilo principal.