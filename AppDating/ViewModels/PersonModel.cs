using AppDating.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDating.ViewModels
{
    class PersonModel : Person
    {
        public RelayCommand TestClick { get; set; }
        public PersonModel()
        {
            TestClick = new RelayCommand(TestFun);
        }

        private void TestFun(object obj)
        {
            FullCardPerson.Person = this;
            Main.MainFrame.Navigate(new AppDating.Views.FullCard());
        }
    }
}
