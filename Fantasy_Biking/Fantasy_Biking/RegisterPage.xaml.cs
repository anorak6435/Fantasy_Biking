using Fantasy_Biking.Logic;
using Fantasy_Biking.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fantasy_Biking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private string UserPicturePath = string.Empty;
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            (bool couldRegister, string errMsg) = UserLogic.Register(userNameEntry.Text, PasswordEntry.Text, PasswordRepeatEntry.Text, UserPicturePath);
            if (!couldRegister)
            {
                await DisplayAlert("Waarschuwing!", errMsg, "cancel");
            } else
            {
                // show succes message
                await DisplayAlert("Succes!", "You registered succesfully", "ok");
                await Navigation.PopAsync();
            }
        }


        private async void NewProfileImage_Clicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Option: From where get the image?", "Cancel", null, "Camera", "Gallery");
            switch (action)
            {
                case "Camera":
                    await PicFromCamera();
                    break;
                case "Gallery":
                    PicFromGallery();
                    break;
            }
        }

        private async Task PicFromCamera()
        {
            var photo = await MediaPicker.CapturePhotoAsync();
            await LoadPhotoAsync(photo);
            if (UserPicturePath != string.Empty)
            {
                UserPic.Source = UserPicturePath; // Update the picture on the page
            }   
        }

        async Task LoadPhotoAsync(FileResult photo)
        {
            // canceled
            if (photo == null)
            {
                UserPicturePath = string.Empty;
                return;
            }
            // save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            UserPicturePath = newFile;
        }

        private async void PicFromGallery()
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Kies uw foto"
            });

            if (result is null)
            {
                _ = DisplayAlert("Let Op!", "Geen afbeelding ontvangen!", "terug");
            }
            else
            {
                UserPicturePath = result.FullPath;

                var stream = await result.OpenReadAsync();
                UserPic.Source = ImageSource.FromStream(() => stream);
            }
        }
    }
}