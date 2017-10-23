using System;
using System.IO;
using System.Threading.Tasks;
using MvvmApp.Model;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace MvvmApp.ViewModel
{
    public class PhotoViewModel : ObservableObject
    {

        private ImageSource photo;

        public ImageSource Photo
        {
            get { return photo; }
            set { photo = value; OnPropertyChanged(); }
        }

        public Command TakePhotoCommand
        { get; set; }

        public PhotoViewModel()
        {
            TakePhotoCommand
            = new Command(async () => await TakePhoto());
        }

        async Task TakePhoto()
        {
            if(Plugin.Media.CrossMedia.Current.IsCameraAvailable
               && Plugin.Media.CrossMedia.Current.IsTakePhotoSupported)
            {

                StoreCameraMediaOptions cameraOptions
                = new StoreCameraMediaOptions()
                {
                    PhotoSize = PhotoSize.Full,
                    Directory = "People",
                    Name = "person.jpg",
                };

                var photoFile
                = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(cameraOptions);

                if(photoFile!=null)
                {
                    Stream photoStream = photoFile.GetStream();
                    Photo = ImageSource.FromStream(() => photoStream);
                   
                }
            }
        }
    }
}
