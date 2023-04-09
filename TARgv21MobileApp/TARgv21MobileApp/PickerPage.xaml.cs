using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv21MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerPage : ContentPage
    {
        Picker picker;
        WebView webview;
        Frame frame;       
        string[] pages = new string[3] { "https://tahvel.edu.ee/#/", "https://moodle.edu.ee/my/", "https://www.tthk.ee/" };
        StackLayout stack;
        public PickerPage()
        {
            picker = new Picker 
            { 
                Title = "Pages"
            };

            picker.Items.Add("Tahvel");
            picker.Items.Add("Moodle");
            picker.Items.Add("TTHK");

            webview = new WebView 
            {
                Source = new UrlWebViewSource { Url = pages[0] }
            };

            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            frame = new Frame 
            { 
                Content = webview,
                BorderColor = Color.FromHex("#ffcccc"),
                CornerRadius = 10,
                HeightRequest = 400,
                WidthRequest = 150,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HasShadow = true
            };

            stack = new StackLayout { Children = {picker, frame} };
            Content = stack;

        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            webview.Source = new UrlWebViewSource { Url = pages[picker.SelectedIndex] } ;
        }
    }
}