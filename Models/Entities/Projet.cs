﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEM_C_E.Models.Entities
{
    public class Projet
    {
        public int IdProjet { get; set; }
        public string Nom { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public float HeureCumuler { get; set; }
    }
}
