namespace ProyectoFinal_MAUI__FV__ME;

public partial class Objetivos_M_F : ContentPage
{
    public Objetivos_M_F()
    {
        InitializeComponent();
    }
    private void ChangePage(object sender, EventArgs e)
    {
        if (sender is Button button && int.TryParse(button.Text, out int pageNumber))
        {
            // Hide all labels
            page1Label.IsVisible = false;
            Image1.IsVisible = false;
            page2Label.IsVisible = false;
            Image2.IsVisible = false;
            page3Label.IsVisible = false;
            Image3.IsVisible = false;
            page4Label.IsVisible = false;
            Image4.IsVisible = false;
            page5Label.IsVisible = false;



            // Show the corresponding label for the selected page
            switch (pageNumber)
            {
                case 1:
                    page1Label.IsVisible = true;
                    Image1.IsVisible = true;
                    break;
                case 2:
                    page2Label.IsVisible = true;
                    Image2.IsVisible = true;
                    break;
                case 3:
                    page3Label.IsVisible = true;
                    Image3.IsVisible = true;
                    break;
                case 4:
                    page4Label.IsVisible = true;
                    Image4.IsVisible = true;
                    break;
                case 5:
                    page5Label.IsVisible = true;
                    break;
            }
        }
    }
}