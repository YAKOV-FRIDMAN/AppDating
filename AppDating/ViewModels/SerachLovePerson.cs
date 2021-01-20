using AppDating.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppDating.ViewModels
{
    class SerachLovePerson
    {
        public ObservableCollection<PersonModel> People { get; set; }
        public RelayCommand TestClick { get; set; }
        public SerachLovePerson()
        {
            People = GetPeople();
          TestClick = new RelayCommand(TestFun);
        }
        private void TestFun(object obj)
        {

        }

        ObservableCollection<PersonModel> GetPeople()
        {


            return new ObservableCollection<PersonModel>
            {
                new PersonModel(){LastName ="chava" , Image="/Assets/9.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new PersonModel(){LastName ="moahe" , Image="/Assets/10.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram" },
                new PersonModel(){LastName ="dana" , Image="/Assets/9.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new PersonModel(){LastName ="yosi" , Image="/Assets/10.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new PersonModel(){LastName ="chava" , Image="/Assets/9.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new PersonModel(){LastName ="chava" , Image="/Assets/10.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new PersonModel(){LastName ="chava" , Image="/Assets/9.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
                new PersonModel(){LastName ="chava" , Image="/Assets/10.png",   Age=21 ,FirstName = "coen" , AboutMyself="i'm drinking in the mornig coffe, and riding in the evnig book" , Children=0, BodyStructure ="thin" , Ctiy="tel aviv" ,EthnicOrigin= "Ashkenazic" , Height = 168.5 ,Profession="Pogram"},
            };
        }
    }
}
