//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SubidaFicheros.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fichero
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string datos { get; set; }
        public string tipo { get; set; }
        public byte[] datosb { get; set; }
        public int tipoFichero { get; set; }
    }
}