﻿using System;

namespace OrdinaMTech.Cv.Shared.Models
{
    public class Ervaring
    {
        public int id { get; set; }
        public DateTime DatumVan { get; set; }
        public DateTime? DatumTm { get; set; }
        public string Organisatie { get; set; }
        public string Functie { get; set; }
        public string Project { get; set; }
        public string Beschrijving { get; set; }
    }
}