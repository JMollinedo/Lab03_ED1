using Lab03_ED1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab03_ED1.DataBase
{
    public class DataAdmin
    {

        private static volatile DataAdmin Instance;
        private static object syncRoot = new object();
        private static Comparadores comparadores = new Comparadores();

        //public ArbolAVL<Partido> fArbolAVL = new ArbolAVL<Partido>();
        public ArbolAVL<Partido> fArbolAVL = new ArbolAVL<Partido>(comparadores.ComparisonByFecha);
        //public ArbolAVL<Partido> nArbolAVL = new ArbolAVL<Partido>();
        public ArbolAVL<Partido> nArbolAVL = new ArbolAVL<Partido>(comparadores.ComparisonByNoPartido);
        public List<Partido> ListaPartidos = new List<Partido>();
        public int PartidoId = 1;

        private DataAdmin() { }

        public static DataAdmin getInstance
        {
            get
            {
                if (Instance == null)
                {
                    lock (syncRoot)
                    {
                        if (Instance == null)
                        {
                            Instance = new DataAdmin();
                        }
                    }
                }
                return Instance;
            }
        }
    }
}