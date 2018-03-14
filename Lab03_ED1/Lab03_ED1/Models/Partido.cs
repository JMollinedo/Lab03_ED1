using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Lab03_ED1.Models
{
    public class Partido : IComparable
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "No. Partido")]
        public int noPartido { get; set; }
        [Display(Name = "Fecha de Partido")]
        public string FechaPartido { get; set; }
        public string Grupo { get; set; }
        [Display(Name = "País 1")]
        public string Pais1 { get; set; }
        [Display(Name = "País 2")]
        public string Pais2 { get; set; }
        public string Estadio { get; set; }

        /// <summary>
        /// Compara el objeto partido por NoPartido
        /// </summary>
        /// <param name="Partido"></param>
        /// <returns></returns>
        public int CompareByNoPartido(Partido Partido)
        {
            return noPartido.CompareTo(Partido.noPartido);
        }
        /// <summary>
        /// Compara el objeto partido por Fecha
        /// </summary>
        /// <param name="Partido"></param>
        /// <returns></returns>
        public int CompareByFecha(Partido Partido)
        {
            return FechaPartido.CompareTo(Partido.FechaPartido);
        }
        /// <summary>
        /// Método CompareTo Modelo PARTIDO
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            try
            {
                Partido Partido = obj as Partido;
                return CompareByFecha(Partido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Partido(int noPartido, string FechaPartido, string Grupo, string Pais1, string Pais2, string Estadio)
        {
            this.noPartido = noPartido;
            this.FechaPartido = FechaPartido;
            this.Grupo = Grupo;
            this.Pais1 = Pais1;
            this.Pais2 = Pais2;
            this.Estadio = Estadio;
        }

    }
}