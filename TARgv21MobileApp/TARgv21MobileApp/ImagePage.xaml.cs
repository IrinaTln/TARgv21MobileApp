using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv21MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        Switch _switch;
        Image image;
        int pressed;
        public ImagePage()
        {
            image = new Image { Source = "audi.jpg"};
            TapGestureRecognizer tapper = new TapGestureRecognizer();
            tapper.Tapped += Tapper_Tapped;
            tapper.NumberOfTapsRequired = 2;
            image.GestureRecognizers.Add(tapper);

            _switch = new Switch 
            { 
                IsToggled = true,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
            _switch.Toggled += _switch_Toggled;
            this.Content = new StackLayout { Children = { image, _switch } };
        }

        private void Tapper_Tapped(object sender, EventArgs e)
        {
            pressed++;
            var imagesender = (Image)sender;
            if (pressed % 2 == 0)
            {
                image.Source = "opel.jpg";
            }
            else
            {
                image.Source = "audi.jpg";
            }
        }

        private void _switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value) 
            { 
                image.IsVisible = true;
            }
            else
            {
                image.IsVisible = false;
            }
        }
    }
}