using AppDating.Models;
using AppDating.Utils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace AppDating.ViewModels
{
    class ChatModel : ViewModelBase
    {
        MediaPlayer mediaPlayer;
        DispatcherTimer timer;
        Record record = null;
        public ObservableCollection<Person> People { get; set; }
        public RelayCommand SendTextMessageCommand { get; set; }
        public RelayCommand SendTextMessagerigehCommand { get; set; }
        public RelayCommand SendImageMessageCommand { get; set; }
        public RelayCommand OpenImageCommand { get; set; }
        public RelayCommand SendAudioOfMicrofn { get; set; }
        public RelayCommand PlayPushe { get; set; }
        public bool IsOriginNative { get; set; }

        private Participant _selectedParticipant;

        private bool _recordOn;
        private bool _isPlay;
        private double _positon;
        private double _positonMax;

        public double PositoMax
        {
            get { return _positonMax; }
            set 
            {
                _positonMax = value;
                OnPropertyChanged();
            }
        }

        public double Positon
        {
            get { return _positon; }
            set
            { 
                _positon = value; 
                OnPropertyChanged();
            }
        }

        public bool IsPlay
        {
            get { return _isPlay; }
            set 
            {
                _isPlay = value;
                OnPropertyChanged();
            }
        }

        public bool RecordOn
        {
            get { return _recordOn; }
            set 
            { 
                _recordOn = value;
                OnPropertyChanged();
            }
        }

        public Participant SelectedParticipant
        {
            get { return _selectedParticipant; }
            set
            {
                _selectedParticipant = value;
                if (SelectedParticipant.HasSentNewMessage) SelectedParticipant.HasSentNewMessage = false;
                OnPropertyChanged();
            }
        }
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        private string _profilePic;
        public string ProfilePic
        {
            get { return _profilePic; }
            set
            {
                _profilePic = value;
                OnPropertyChanged();
            }
        }
        private string _textMessage;
        public string TextMessage
        {
            get { return _textMessage; }
            set
            {
                _textMessage = value;
                OnPropertyChanged();
            }
        }


        public ChatModel()
        {
            People = GetPeople();
            SelectedParticipant = new Participant();
            SendTextMessageCommand = new RelayCommand(SendTextMessage);
            SendTextMessagerigehCommand = new RelayCommand(SendTextMessageRe);
            SendImageMessageCommand = new RelayCommand(SendImageMessage);
            OpenImageCommand = new RelayCommand(OpenImageInDesktop);
            SendAudioOfMicrofn = new RelayCommand(RecordAudioAndSend);
            PlayPushe = new RelayCommand(StartOffAudio);
            record = new Record();
        }

        private void StartOffAudio(object obj)
        {

            var c = (string)obj;

            if (!IsPlay)
                StartAudio(c);
            else
                StopAudio();
        }

        void StartAudio(string filename)
        {
           // if(mediaPlayer == null)
               mediaPlayer = new MediaPlayer();

            mediaPlayer.Open(new Uri(filename));
            mediaPlayer.MediaOpened += (o, e) => 
            {
                PositoMax = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                timer = new DispatcherTimer();
                mediaPlayer.Play();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Start();
                timer.Tick += Timer_Tick;
                IsPlay = true;
            };
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Positon = mediaPlayer.Position.TotalSeconds;
        }

        void StopAudio()
        {
            mediaPlayer.Stop();
            timer.Stop();
            mediaPlayer = null;
            IsPlay = false;
        }

    
        private void RecordAudioAndSend(object obj)
        {
            RecordOn = record.RecordOn;
            var fileName = Path.GetRandomFileName();
            if (RecordOn == false)
                record.StartRecord();
            
            else
            {
                record.StopRecord(@$"c:\newfolderrecord\{fileName}");
                SendRecord($@"c:\newfolderrecord\{fileName}.wav");
            }
           
            RecordOn = record.RecordOn;


        }

        

        void SendRecord(string filePath)
        {
            ChatMessage msg = new ChatMessage
            {
                Audio = filePath,
                Time = DateTime.Now,
                IsOriginNative = false,
                Author = UserName
            };
            SelectedParticipant.Chatter.Add(msg);

        }


        private void OpenImageInDesktop(object obj)
        {
            var chatMess = obj as ChatMessage;
            var img = chatMess.Picture;
            if (string.IsNullOrEmpty(img) || !File.Exists(img)) return;
            new Process { StartInfo = new ProcessStartInfo(img) { UseShellExecute = true } }.Start();

        }

        private void SendImageMessage(object obj)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == true)
            {

                var pic = openFile.FileName;
                if (string.IsNullOrEmpty(pic)) return;
              //  var img =   File.ReadAllBytes(pic);


                ChatMessage msg = new ChatMessage
                {
                    Author = UserName,
                    Picture = pic,
                   // Picture = @"C:\Users\user1\source\repos\AppDating\AppDating\Assets\6.jpg",
                    Time = DateTime.Now,
                    Message  = _textMessage,
                    IsOriginNative = false
                };
                SelectedParticipant.Chatter.Add(msg);


            }
        }
        string ByteToFileName(byte[] imageData)
        {
            string fileName = Path.GetTempFileName();

            File.WriteAllBytes(fileName, imageData);
            return fileName;

        }
        public static ImageSource ByteToImage(byte[] imageData)
        {
             
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }

        private void SendTextMessage(object obj)
        {
            ChatMessage msg = new ChatMessage
            {   
                Author = UserName,
                Message = _textMessage,
                Time = DateTime.Now,
                IsOriginNative = false
            };
            SelectedParticipant.Chatter.Add(msg);
        } 
        private void SendTextMessageRe(object obj)
        {
            ChatMessage msg = new ChatMessage
            {   
                Author = UserName,
                Message = _textMessage,
                Time = DateTime.Now,
                IsOriginNative = true
            };
            SelectedParticipant.Chatter.Add(msg);
        }

        ObservableCollection<Person> GetPeople()
        {
            return new ObservableCollection<Person>
            {
                new Person(){LastName ="chava" , Image="/Assets/9.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new Person(){LastName ="yosi" , Image="/Assets/10.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram" },
                new Person(){LastName ="dana" , Image="/Assets/9.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new Person(){LastName ="moashe" , Image="/Assets/10.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new Person(){LastName ="chava" , Image="/Assets/9.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new Person(){LastName ="chava" , Image="/Assets/10.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new Person(){LastName ="chava" , Image="/Assets/9.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new Person(){LastName ="chava" , Image="/Assets/10.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new Person(){LastName ="chava" , Image="/Assets/9.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new Person(){LastName ="chava" , Image="/Assets/10.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new Person(){LastName ="chava" , Image="/Assets/9.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new Person(){LastName ="chava" , Image="/Assets/10.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new Person(){LastName ="chava" , Image="/Assets/9.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new Person(){LastName ="chava" , Image="/Assets/10.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new Person(){LastName ="chava" , Image="/Assets/9.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new Person(){LastName ="chava" , Image="/Assets/10.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new Person(){LastName ="chava" , Image="/Assets/9.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new Person(){LastName ="chava" , Image="/Assets/10.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
            };
        }
    }
}
