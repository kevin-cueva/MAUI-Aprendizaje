namespace Dispatcher;

public class DispatcherDemo : ContentPage
{
    private readonly IDispatcherHelper _dispatcherHelper;

    private Label miLabel;

    public DispatcherDemo()
    {
        // Obtengo el dispatcher del contexto actual
        _dispatcherHelper = new DispatcherHelper(Dispatcher);

        miLabel = new Label
        {
            Text = "Esperando...",
            FontSize = 24,
            HorizontalOptions = LayoutOptions.Center
        };

        var miBoton = new Button
        {
            Text = "Iniciar contador"
        };
        miBoton.Clicked += OnCounterClicked;

        Content = new VerticalStackLayout
        {
            Padding = 20,
            Children = { miLabel, miBoton }
        };
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await Task.Run(async () =>
        {
            for (int i = 1; i <= 5; i++)
            {
                await Task.Delay(1000);

                // ✅ ahora uso el helper
                _dispatcherHelper.EjecutarEnUI(() =>
                {
                    miLabel.Text = $"Contando... {i}";
                });
            }
        });

        _dispatcherHelper.EjecutarEnUI(() =>
        {
            miLabel.Text = "✅ Listo!";
        });
    }
}
