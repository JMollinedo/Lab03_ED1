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
        /// Compara el objeto partido por Grupo
        /// </summary>
        /// <param name="Partido"></param>
        /// <returns></returns>
        public int CompareByGrupo(Partido Partido)
        {
            return Grupo.CompareTo(Partido.Grupo);
        }
        /// <summary>
        /// Compara el objeto partido por Pais 1
        /// </summary>
        /// <param name="Partido"></param>
        /// <returns></returns>
        public int ComparteByPais1(Partido Partido)
        {
            return Pais1.CompareTo(Partido.Pais1);
        }
        /// <summary>
        /// Compara el objeto partido por Pais 2
        /// </summary>
        /// <param name="Partido"></param>
        /// <returns></returns>
        public int CompareByPais2(Partido Partido)
        {
            return Pais2.CompareTo(Partido.Pais2);
        }
        /// <summary>
        /// Compara el objeto partido por Estadio
        /// </summary>
        /// <param name="Partido"></param>
        /// <returns></returns>
        public int CompareByEstadio(Partido Partido)
        {
            return Estadio.CompareTo(Partido.Estadio);
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

        /// <summary>
        /// Delegado para determinar Factor de Orden
        /// </summary>
        /// <param name="Partido">Partido compadado</param>
        /// <returns>Valor de Comparacion</returns>
        public delegate int Comparar(Partido Partido);

        /// <summary>
        /// Funcion comparcion por delegado
        /// </summary>
        /// <param name="partido">Partido a Comparar</param>
        /// <param name="criterio">Delegado</param>
        /// <returns>Valor de Comparación</returns>
        public int CompareTo(Partido partido, Comparar criterio)
        {
            return criterio(partido);
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