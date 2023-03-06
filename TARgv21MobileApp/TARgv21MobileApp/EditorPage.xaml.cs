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
    public partial class EditorPage : ContentPage
    {
        Editor editor;
        Button backBtn;
        Label label;
        public EditorPage()
        {
            editor = new Editor
            {
                TextColor = Color.White,
                Placeholder = "Insert here text",
                BackgroundColor = Color.Gray
            };
            editor.TextChanged += Editor_TextChanged;
            label = new Label
            {
                Text = "...",
                TextColor = Color.Gray,
                BackgroundColor = Color.White
            };
            
            backBtn = new Button { Text = "Back" };
            backBtn.Clicked += BackBtnClicked;
            StackLayout stack = new StackLayout
            {
                Children = { editor, label, backBtn }
            };

            stack.BackgroundColor = Color.Gold;
            Content = stack;
        }

        int i = 0;
        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            //label.Text = editor.Text;
            editor.TextChanged -= Editor_TextChanged;
            char key = e.NewTextValue?.LastOrDefault() ?? ' ';

            if (key =='A' || key == 'a')
            {
                i++;
                label.Text = key.ToString() + ": " + i;
            }

            editor.TextChanged +=Editor_TextChanged;
        }

        private async void BackBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}