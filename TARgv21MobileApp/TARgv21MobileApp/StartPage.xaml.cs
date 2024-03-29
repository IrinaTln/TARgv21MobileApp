﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv21MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        StackLayout st;
        ScrollView scrollView;

        List<ContentPage> pages = new List<ContentPage>() 
        { 
            new EditorPage(), 
            new TimerPage(), 
            new BoxPage(), 
            new TrafficLights(), 
            new DateTimePage(), 
            new StepperSliderPage(),
            new ColorSliderPage(),
            new FramePage(),
            new ImagePage(),
            new PopUpPage(),
            new DictionaryPage(),
            new PickerPage(),
            new TablePage(),
            new FilePage()
        };

        List<string> texts = new List<string> 
        { 
            "Editor page", 
            "Timer page", 
            "BoxView Page", 
            "Traffic lights Page", 
            "Date Time Page", 
            "Stepper Slider Page",
            "Color Slider Page",
            "Frame page",
            "Image page",
            "PopUp Page",
            "Dictionary Page",
            "Picker Page",
            "Table Page",
            "File Page"
        };
        
        //This staff for making buttons all the time with differnts colors
        //Random random = new Random();
        
        public EventHandler BoxBtn_Clicked { get; }

        public StartPage()
        {

            Button TrafficLightsButton = new Button
            {
                Text = "Traffic lights Page",
                BackgroundColor = Color.FromHex("#33ff99")
                              
            };

            st = new StackLayout();

            for (int i = 0; i < pages.Count; i++)
            {
                Button button = new Button
                {
                    Text = texts[i],
                    BackgroundColor = Color.FromHex("#33ff99"),
                    //BackgroundColor = Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), - this staff for colored random buttons
                    TabIndex = i
                };
                st.Children.Add(button);
                button.Clicked += Button_Clicked;
            }

            scrollView = new ScrollView
            {
                Content = st
            };

            Content = scrollView;
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button sampel = sender as Button;
            await Navigation.PushAsync(pages[sampel.TabIndex]);
        }
    }
}