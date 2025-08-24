namespace Dispatcher;

public class DispatcherHelper(
    IDispatcher dispatcher) : IDispatcherHelper
{
    private readonly IDispatcher _dispatcher = dispatcher;

    //Action es un delegado en C#, básicamente una función que no devuelve nada (void) y no recibe parámetros.
    public void EjecutarEnUI(Action accion)
    {
        if (_dispatcher.IsDispatchRequired)
            _dispatcher.Dispatch(accion);
        else
            accion(); // Si ya estamos en el hilo principal
    }
}
