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
                string dataAsString = lector.ReadToEnd();
                lector.Close();
                dataAsString.Remove(0, 1);
                dataAsString.Remove(dataAsString.Length - 1, 1);
                string temp = string.Empty;
                foreach (char c in dataAsString)
                {
                    if(!string.IsNullOrEmpty(temp) || c == '{')
                    {
                        temp = temp + c;
                    }
                    if(c == '}')
                    {
                        try
                        {
                            PartidoParcer(temp, ref Partidoss);
                        }catch(Exception ex)
                        {
                            throw ex;
                        }
                        temp = string.Empty;
                    }
                }
                return Partidoss;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PartidoParcer(string partidoDato, ref List<Partido> listaPartidos)
        {
            try
            {
                Partido nuevo = JsonConvert.DeserializeObject<Partido>(partidoDato);
                listaPartidos.Add(nuevo);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}