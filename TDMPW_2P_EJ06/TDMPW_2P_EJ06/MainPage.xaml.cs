namespace TDMPW_2P_EJ06;

public partial class MainPage : ContentPage
{
    Random random = new Random();

	public MainPage()
	{
		InitializeComponent();

	}

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		var starColor = System.Drawing.Color.FromArgb(
			random.Next(0,256),
            random.Next(0, 256),
            random.Next(0, 256)
            );

        var endColor = System.Drawing.Color.FromArgb(
            random.Next(0, 256),
            random.Next(0, 256),
            random.Next(0, 256)
            );

        var colors = ColorUtility.ColorControls.GetColorGradient(starColor, endColor, 6);

        float stopOffset = .0f;

        var stops = new GradientStopCollection();

        foreach (var c in colors)
        {
            stops.Add(new GradientStop(Color.FromArgb(c.Name),stopOffset));
            stopOffset += .2f;
        }

        var gradiente = new LinearGradientBrush(stops, new Point(0,0), new Point(1,1));

        background.Background = gradiente;

        var hexColors = new string[colors.Count];
        for (int i = 0; i < colors.Count; i++)
        {
            hexColors[i] = colors[i].ToArgb().ToString("X8");
        }


        var coloresMaui = new Microsoft.Maui.Graphics.Color[colors.Count];
        for (int i = 0; i < colors.Count; i++)
        {
            coloresMaui[i] = new Microsoft.Maui.Graphics.Color(
                colors[i].R,
                colors[i].G,
                colors[i].B,
                colors[i].A
            );
        }


        Label[] etiquetas = { lblHex1, lblHex2, lblHex3, lblHex4, lblHex5, lblHex6 };
        for (int i = 0; i < colors.Count; i++)
        {
            etiquetas[i].Text = "#" + hexColors[i];
            etiquetas[i].BackgroundColor = coloresMaui[i];
        }

    }
}


