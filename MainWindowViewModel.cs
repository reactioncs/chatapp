using System.Collections.ObjectModel;
using ChatApp.MVVM.Model;
using ChatApp.Core;

namespace ChatApp
{
    class MainWindowViewModel : ObservableObject
    {
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
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                SelectedContact.Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });

                Message = "";
            });

            string[] names = new string[] { "Alice", "Bob", "Cathy", "David", "Elly" };
            for (int i = 0; i < 4; i++)
            {
                var Messages = new ObservableCollection<MessageModel>();

                for (int j = 0; j < 4; j++)
                {
                    Messages.Add(new MessageModel
                    {
                        Username = names[i + 1],
                        Message = "C/C++ compilation use case.",
                        IsNativeOrigin = false,
                        FirstMessage = true
                    });
                    Messages.Add(new MessageModel
                    {
                        Username = names[i + 1],
                        Message = "there to Make?",
                        IsNativeOrigin = true
                    });
                    Messages.Add(new MessageModel
                    {
                        Username = names[i + 1],
                        Message = "there to Make?",
                        IsNativeOrigin = true
                    });
                    Messages.Add(new MessageModel
                    {
                        Username = names[i],
                        Message = "C/C++ compilation use case.",
                        IsNativeOrigin = false,
                        FirstMessage = true
                    });
                    Messages.Add(new MessageModel
                    {
                        Username = names[i],
                        Message = "there to Make?",
                        IsNativeOrigin = true
                    });
                    Messages.Add(new MessageModel
                    {
                        Username = names[i],
                        Message = "there to Make?",
                        IsNativeOrigin = true
                    });
                }

                Contacts.Add(new ContactModel
                {
                    Username = names[i],
                    ImageSource = "./Icons/Contact.png",
                    Messages = Messages
                });
            }

            SelectedContact = Contacts[1];
        }
    }
}
