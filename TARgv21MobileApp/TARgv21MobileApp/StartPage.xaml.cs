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
    public partial class StartPage : ContentPage
    {
        public EventHandler BoxBtn_Clicked { get; }

        public StartPage()
        {
            //InitializeComponent();
            Button EditorBtn = new Button 
            {
                Text = "Edit page",
                BackgroundColor = Color.FromRgb(125, 10, 100)
            };

            Button TimerBtn = new Button
            {
                Text = "Timer page",
                BackgroundColor = Color.FromRgb(125, 10, 100)
            };
            Button BoxBtn = new Button
            {
                Text = "BoxView Page",
                BackgroundColor = Color.FromRgb(225, 90, 100)
            };

            StackLayout st = new StackLayout();
            st.Children.Add(EditorBtn);
            st.Children.Add(TimerBtn);
            st.Children.Add(BoxBtn);
            Content = st;

            EditorBtn.Clicked += EditorBtn_Clicked;
            TimerBtn.Clicked += TimerBtn_Clicked;
            BoxBtn.Clicked += BoxBtn_Clicked1;
        }

        private async void BoxBtn_Clicked1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BoxPage());
        }

        private async void TimerBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimerPage());
        }

        private async void EditorBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditorPage());
        }
    }
}