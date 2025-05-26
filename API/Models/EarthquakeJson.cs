using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    /**
        * Esta clase es un modelo para deserializar el JSON de terremotos.
        * Se usa para leer el JSON y convertirlo en objetos de C#.
        * 
        * El JSON tiene la siguiente estructura:
        * {
        *   "date": "2023-10-01",
        *   "latitude": 34.05,
        *   "longitude": -118.25,
        *   "depth": 10.0,
        *   "magnitude": 5.0
        * }
        */
        
    public class EarthquakeJson
    {
        public string Date { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Depth { get; set; }
        public double Magnitude { get; set; }
    }
}