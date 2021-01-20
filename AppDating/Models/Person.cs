using System;
using System.Collections.Generic;
using System.Text;

namespace AppDating.Models
{
    class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public double Age { get; set; }
        public string Image { get; set; }
        public string AboutMyself { get; set; }
        public Enums.Education Education { get; set; }

        public double Height { get; set; }
        public int Children { get; set; }
        /// <summary>
        /// מקצוע
        /// </summary>
        public string Profession { get; set; }
        public string Ctiy { get; set; }
        public string BodyStructure { get; set; }
        /// <summary>
        /// מוצא אתני
        /// </summary>
        public string EthnicOrigin { get; set; }

    }
}
