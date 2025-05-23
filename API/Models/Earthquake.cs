using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Earthquake
    {
        public int Id { get; set; }
        public required DateOnly Date { get; set; }
        public required double Latitude { get; set; }
        public required double Longitude { get; set; }
        public required double Depth { get; set; }
        public required double Magnitude { get; set; }

        //TO DO: Agregar mas atributos, pero hay que actualizar el webscraping para tener un JSON completo

        

    }
}