using Lab03_ED1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab03_ED1.DataBase
{
    public class Comparadores
    {
        /// <summary>
        /// Funcion que compara dos partidos
        /// </summary>
        /// <param name="p1">Partido 1</param>
        /// <param name="p2">Partido 2</param>
        /// <returns>Valor de orden por Fecha</returns>
        public int ComparisonByFecha(Partido p1, Partido p2)
        {
            int temp = p1.CompareByFecha(p2);
            if (temp == 0)
            {
                temp = p1.CompareByNoPartido(p2);
            }
            return temp;
        }
        /// <summary>
        /// Funcion que compara dos partidos
        /// </summary>
        /// <param name="p1">Partido 1</param>
        /// <param name="p2">Partido 2</param>
        /// <returns>Valor de orden por No. Partidos</returns>
        public int ComparisonByNoPartido(Partido p1, Partido p2)
        {
            int temp = p1.CompareByNoPartido(p2);
            if (temp == 0)
            {
                temp = p1.CompareByFecha(p2);
            }
            return temp;
        }
        /// <summary>
        /// Delegado para determinar Factor de Orden entre dos objetos
        /// </summary>
        /// <param name="p1">Partido 1</param>
        /// <param name="p2">Partido 2</param>
        /// <returns>Valor de Comparación</returns>
        public delegate int Comparador(Partido p1, Partido p2);
        /// <summary>
        /// Funcion comparcion por delegado
        /// </summary>
        /// <param name="p1">Partido 1</param>
        /// <param name="p2">Partido 2</param>
        /// <param name="criterio">Funcion de Comparcion</param>
        /// <returns>Valor de Comparacion</returns>
        public int ComparisonBy(Partido p1, Partido p2, Comparador criterio)
        {
            return criterio(p1, p2);
        }
    }
}