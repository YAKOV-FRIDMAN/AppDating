using AppDating.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;

namespace AppDating.ViewModels
{
    class Main : INotifyPropertyChanged
    {

        private object myVar;

        public object MyProperty
        {
            get { return myVar; }
            set { 

                myVar = value;
                PropertyChangedM(nameof(MyProperty));
                var s = (ListViewItem)myVar;
             
                MenuChangePage(s.Name);
            }
        }


        static public Frame MainFrame
        {
            get { return m; }
            set { m = value; }
        }


        static Frame m;
        public RelayCommand Loaded { get; set; }
        SearchLove searchLove;
        Chat chat;
        Login login;
        public Main()
        {
            searchLove = new SearchLove();
            chat = new Chat();
            login = new Login();
            Loaded = new RelayCommand((obj) =>
            {
                MainFrame = (Frame)obj;
                MainFrame.Navigate(searchLove);
            });

          
        }

        private void MenuChangePage(string name)
        {
            switch (name)
            {
                case "search":
                    MainFrame.Navigate(searchLove);
                    break;
                case "chat":
                    MainFrame.Navigate(chat);
                    break;
                case "login":
                    MainFrame.Navigate(new  MyCard());
                    break;
                default:
                    break;
            }
        }





        #region Notify

        public event PropertyChangedEventHandler PropertyChanged;
        public void PropertyChangedM(string nameProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
            #endregion
        }
    }
}
