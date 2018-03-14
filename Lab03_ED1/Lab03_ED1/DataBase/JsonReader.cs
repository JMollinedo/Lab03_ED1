using Lab03_ED1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace Lab03_ED1.DataBase
{
    public class JsonReader<T>
    {
        /// <summary>
        /// Datos en Archivo
        /// </summary>
        /// <param name="rutaOrigen">Ruta de Origen de Archivo</param>
        /// <returns></returns>
        public List<Partido> Datos(Stream rutaOrigen)
        {
            try
            {
                //Partido[] Partido = new Partido[12];
                List<Partido> Partidoss = new List<Partido>();
                StreamReader lector = new StreamReader(rutaOrigen);
                string temp = lector.ReadToEnd();

                var Partidos= JsonConvert.DeserializeObject(temp);

                lector.Close();
                return Partidoss;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}