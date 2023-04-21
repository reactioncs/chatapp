using System.Collections.ObjectModel;
using ChatApp.MVVM.Model;
using ChatApp.Core;
using System.ComponentModel.Design;

namespace ChatApp
{
    class MainWindowViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        public RelayCommand SendCommand { get; set; }

        private ContactModel mSelectedContact;
        public ContactModel SelectedContact
        {
            get { return mSelectedContact; }
            set
            {
                mSelectedContact = value;
                OnPropertyChanged();
            }
        }

        private string mMessage;
        public string Message
        {
            get { return mMessage; }
            set 
            { 
                mMessage = value;
                OnPropertyChanged();
            }
        }


        public MainWindowViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });

                Message = "";
            });

            Messages.Add(new MessageModel
            {
                Username = "Alice",
                UsernameColor = "#409aff",
                ImageSource = "./Icons/Contact.png",
                Message = ">>>>>>>Test<<<<<<<",
                Time = System.DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true 
            });

            for (int i = 0; i < 4; i++)
            {
                Messages.Add(new MessageModel
                {
                    Username = "Alice",
                    UsernameColor = "#409aff",
                    ImageSource = "./Icons/Contact.png",
                    Message = "12121212",
                    Time = System.DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false
                });
            }

                for (int i = 0; i < 4; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"Allll{i}",
                    ImageSource = "./Icons/Contact.png",
                    Messages = Messages
                });
            }
            SelectedContact = Contacts[1];
        }
    }
}
