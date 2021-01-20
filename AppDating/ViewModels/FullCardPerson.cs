using AppDating.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppDating.ViewModels
{
     class FullCardPerson
    {
        static public Person Person { get; set; }
        public Person MyPerson { get; set; } = Person;
        public ObservableCollection<Person> People { get; set; }
      
        public FullCardPerson()
        {
            People = GetPeople();
          
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
            };
        }
    }
}
