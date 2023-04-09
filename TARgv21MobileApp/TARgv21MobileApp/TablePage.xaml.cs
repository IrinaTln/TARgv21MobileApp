using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Messaging;

namespace TARgv21MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TablePage : ContentPage
    {
        TableView table;
        SwitchCell switchCell;
        ImageCell imageCell;
        TableSection picture;
        Button callButton, smsButton, mailButton;
        EntryCell tel, email, insertText, name;

        public TablePage()
        {
            tel = new EntryCell
            {
                Label = "Telefon",
                Placeholder = "Insert phone number",
                Keyboard = Keyboard.Telephone
            };
            email = new EntryCell
            {
                Label = "Email",
                Placeholder = "Insert email",
                Keyboard = Keyboard.Email
            };
            insertText = new EntryCell
            {
                Label = "Sms:",
                Placeholder = "Write message",
                Keyboard = Keyboard.Default
            };
            name = new EntryCell
            {
                Label = "Name:",
                Placeholder = "Insert name",
                Keyboard = Keyboard.Default
            };
        

            switchCell = new SwitchCell
            {
                Text="Show more"
            };
            switchCell.OnChanged += SwitchCell_OnChanged;

            callButton = new Button
            {
                Text = "Call",
                BackgroundColor = Color.Gray,
                TextColor = Color.Black
            };
            callButton.Clicked += CallButton_Clicked;
            smsButton = new Button
            {
                Text = "Send sms",
                BackgroundColor = Color.Gray,
                TextColor = Color.Black
            };
            smsButton.Clicked += SmsButton_Clicked;
            mailButton = new Button
            {
                Text = "Send email",
                BackgroundColor = Color.Gray,
                TextColor = Color.Black
            };
            mailButton.Clicked += MailButton_Clicked;

            imageCell = new ImageCell
            {
                ImageSource = ImageSource.FromFile("spaceship2.jpg"),
                Text = "Spaceship",
                Detail = "Info"
            };
            picture = new TableSection();

            table = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Insert data")
                {
                    new TableSection("Main info:")
                    {
                        new EntryCell
                        {
                            Label = "Name:",
                            Placeholder = "Insert name",
                            Keyboard = Keyboard.Default
                        }
                    },
                    new TableSection("Contact info:")
                    {
                        new EntryCell
                        {
                            Label = "Phone:",
                            Placeholder = "Insert your number",
                            Keyboard = Keyboard.Telephone
                        },
                        new EntryCell
                        {
                            Label = "Email:",
                            Placeholder = "Insert your email",
                            Keyboard = Keyboard.Email
                        },
                        switchCell
                    },
                    picture,
                    

                }
            };
            Content = table;
        }

        private void MailButton_Clicked(object sender, System.EventArgs e)
        {
            var mail = CrossMessaging.Current.EmailMessenger;
            if (mail.CanSendEmail)
            {
                mail.SendEmail(tel.Text, "Hello!", insertText.Text);
            }
        }

        private void SmsButton_Clicked(object sender, System.EventArgs e)
        {
            var sms = CrossMessaging.Current.SmsMessenger;
            if (sms.CanSendSms)
            {
                sms.SendSms(tel.Text, "Hello, " + name.Text + "!\n" + insertText.Text);
            }
        }

        private void CallButton_Clicked(object sender, System.EventArgs e)
        {
            var call = CrossMessaging.Current.PhoneDialer;
            if (call.CanMakePhoneCall)
            {
                call.MakePhoneCall(tel.Text);
            }
        }

        private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                picture.Title = "Picture";
                picture.Add(imageCell);
                switchCell.Text = "Hide";
                picture.Add(tel);
                picture.Add(email);
                picture.Add(insertText);
                picture.Add(name);
            }
            else
            {
                picture.Title = "";
                picture.Remove(imageCell);
                switchCell.Text = "Show";
                picture.Remove(tel);
                picture.Remove(email);
                picture.Remove(insertText);
                picture.Remove(name);
            }
        }
    }
}