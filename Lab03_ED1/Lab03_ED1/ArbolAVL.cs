using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab03_ED1
{
    /// <summary>
    /// Nodo de Arbol AVL
    /// </summary>
    /// <typeparam name="T">Tipo de Dato en Nodo</typeparam>
    public class NodoArbolAVL <T>
    {
        /// <summary>
        /// Valor en el nodo
        /// </summary>
        public T value;
        /// <summary>
        /// Factor de Equilibrio del Nodo en el Arbol
        /// </summary>
        public int factorEquilibrio;
        /// <summary>
        /// Nodo hijo izquierdo
        /// </summary>
        public NodoArbolAVL<T> hijoIzquierdo;
        /// <summary>
        /// Nodo hijo derecho
        /// </summary>
        public NodoArbolAVL<T> hijoDerecho;
        /// <summary>
        /// Nodo es hoja del Arbol
        /// </summary>
        public bool EsHoja
        {
            get
            {
                return hijoDerecho == null && hijoIzquierdo == null;
            }
        }
        /// <summary>
        /// Contructor de Nodo
        /// </summary>
        /// <param name="nodeValue">Valor del Nodo</param>
        public NodoArbolAVL(T nodeValue)
        {
            value = nodeValue;
            factorEquilibrio = 0;
            hijoIzquierdo = null;
            hijoDerecho = null;
        }
    }
    /// <summary>
    /// Arbol ALV
    /// </summary>
    /// <typeparam name="T">Tipo de Dato en Arbol</typeparam>
    public class ArbolAVL <T> where T : IComparable
    {
        /// <summary>
        /// Nodo Raiz de Arbol
        /// </summary>
        public NodoArbolAVL<T> Raiz;
        /// <summary>
        /// Constructor de Arbol
        /// </summary>
        public ArbolAVL()
        {
            Raiz = null;
        }

        //Buscar
        /// <summary>
        /// Funcion de busqueda de valor en Arbol
        /// </summary>
        /// <param name="valorBuscado">Valor que se busca en el arbol</param>
        /// <returns>Nodo con el valor buscado</returns>
        public NodoArbolAVL<T> Buscar(T valorBuscado)
        {
            return Buscar(valorBuscado, Raiz);
        }
        
        /// <summary>
        /// Función recursiva que recibe un valor, y devuelve un nodo que contenga ese valor
        /// </summary>
        /// <param name="value"> valor a buscar </param>
        /// <param name="raiz"></param>
        /// <returns></returns>
        private NodoArbolAVL<T> Buscar(T value, NodoArbolAVL<T> raiz)
        {
            if (Raiz == null)
            {
                return null;
            }
            else if (raiz.value.CompareTo(value) == 0)
            {
                return raiz;
            }
            else if (raiz.value.CompareTo(value) == -1)
            {
                return Buscar(value, raiz.hijoDerecho);
            }
            else
            {
                return Buscar(value, raiz.hijoIzquierdo);
            }
        }

        //Obtener Factor de Equilibrio
        public int ObtenerFactorEquilibrio(NodoArbolAVL <T> x)
        {
            if (x == null)
            {
                return -1;
            }
            else
               return x.factorEquilibrio;
        }

        //Rotación Simple Izquierda
        public NodoArbolAVL<T> RotacionIzquierda(NodoArbolAVL<T> Nodo)
        {
            NodoArbolAVL<T> Auxiliar = Nodo.hijoIzquierdo;
            Nodo.hijoIzquierdo = Auxiliar.hijoDerecho;

            Auxiliar.hijoDerecho = Nodo;
            //Obtiene el mayor factor de equilibrio de sus hijos.
            Nodo.factorEquilibrio = Math.Max(ObtenerFactorEquilibrio(Nodo.hijoIzquierdo), ObtenerFactorEquilibrio(Nodo.hijoDerecho) + 1);
            Auxiliar.factorEquilibrio = Math.Max(ObtenerFactorEquilibrio(Auxiliar.hijoIzquierdo), ObtenerFactorEquilibrio(Auxiliar.hijoDerecho)) + 1;
            return Auxiliar;
        }
        //Rotación Simple Derecha
        public NodoArbolAVL<T> RotacionDerecha(NodoArbolAVL<T> Nodo)
        {
            NodoArbolAVL<T> Auxiliar = Nodo.hijoDerecho;
            Nodo.hijoDerecho = Auxiliar.hijoIzquierdo;

            Auxiliar.hijoIzquierdo = Nodo;
            //Obtiene el mayor factor de equilibrio de sus hijos.
            Nodo.factorEquilibrio = Math.Max(ObtenerFactorEquilibrio(Nodo.hijoIzquierdo), ObtenerFactorEquilibrio(Nodo.hijoDerecho)) + 1;
            Auxiliar.factorEquilibrio = Math.Max(ObtenerFactorEquilibrio(Auxiliar.hijoIzquierdo), ObtenerFactorEquilibrio(Auxiliar.hijoDerecho)) + 1;
            return Auxiliar;
        }

        //Rotación Doble Izquierda
        public NodoArbolAVL<T> RotacionDobleIzquierda(NodoArbolAVL<T> Nodo)
        {
            NodoArbolAVL<T> Auxiliar;
            Nodo.hijoIzquierdo = RotacionDerecha(Nodo.hijoIzquierdo);
            Auxiliar = RotacionIzquierda(Nodo);
            return Auxiliar;
        }
        //Rotación Doble Derecha
        public NodoArbolAVL<T> RotacionDobleDerecha(NodoArbolAVL<T> Nodo)
        {
            NodoArbolAVL<T> Auxiliar;
            Nodo.hijoDerecho = RotacionIzquierda(Nodo.hijoDerecho);
            Auxiliar = RotacionDerecha(Nodo);
            return Auxiliar;
        }
        
        //Metodo InsertarAVL
        public NodoArbolAVL <T> InsertarAVL(NodoArbolAVL <T> Nuevo, NodoArbolAVL<T> SubArbol)
        {
            NodoArbolAVL<T> NuevoPadre = SubArbol;
            if (Nuevo.value.CompareTo(SubArbol.value) == -1)
            {
                if (SubArbol.hijoIzquierdo == null)
                {
                    SubArbol.hijoIzquierdo = Nuevo;
                }
                else
                {
                    SubArbol.hijoIzquierdo = InsertarAVL(Nuevo, SubArbol.hijoIzquierdo);
                    if (ObtenerFactorEquilibrio(SubArbol.hijoIzquierdo) - ObtenerFactorEquilibrio (SubArbol.hijoDerecho) == 2 )
                    {
                        if (Nuevo.value.CompareTo(SubArbol.hijoIzquierdo) == -1)
                        {
                            NuevoPadre = RotacionIzquierda(SubArbol);
                        }
                        else
                        {
                            NuevoPadre = RotacionDobleIzquierda(SubArbol);
                        }
                    }
                }
            }
            else if(Nuevo.value.CompareTo(SubArbol.value) == 1)
            {
                if (SubArbol.hijoDerecho == null)
                {
                    SubArbol.hijoDerecho = Nuevo;
                }
                else
                {
                    SubArbol.hijoDerecho = InsertarAVL(Nuevo, SubArbol.hijoDerecho);
                    if (ObtenerFactorEquilibrio(SubArbol.hijoDerecho) - ObtenerFactorEquilibrio(SubArbol.hijoIzquierdo) == 2)
                    {
                        if (Nuevo.value.CompareTo(SubArbol.hijoDerecho) == 1)
                        {
                            NuevoPadre = RotacionDerecha(SubArbol);
                        }
                        else
                        {
                            NuevoPadre = RotacionDobleDerecha(SubArbol);
                        }
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Nodo Duplicado");
            }
            //Actualizando Factor Equilibrio
            if (SubArbol.hijoIzquierdo == null && SubArbol.hijoDerecho != null)
            {
                SubArbol.factorEquilibrio = SubArbol.hijoDerecho.factorEquilibrio + 1;
            }
            else if (SubArbol.hijoDerecho == null && SubArbol.hijoIzquierdo != null)
            {
                SubArbol.factorEquilibrio = SubArbol.hijoIzquierdo.factorEquilibrio + 1;
            }
            else
            {
                SubArbol.factorEquilibrio = Math.Max(ObtenerFactorEquilibrio(SubArbol.hijoIzquierdo), ObtenerFactorEquilibrio(SubArbol.hijoDerecho)) +1;
            }
            return NuevoPadre;
        }
        public void Insertar(T value)
        {
            NodoArbolAVL<T> Nuevo = new NodoArbolAVL<T>(value);
            if (Raiz == null)
            {
                Raiz = Nuevo;
            }
            else
            {
                Raiz = InsertarAVL(Nuevo, Raiz);
            }
        }

        /// <summary>
        /// Elimina un Nodo mediante sustitucion
        /// </summary>
        /// <param name="NodoAEliminar">Nodo a Eliminar </param>
        /// <returns>Nodo de Reemplazo</returns>
        private NodoArbolAVL<T> Reemplazar(NodoArbolAVL<T> NodoAEliminar)
        {
            NodoArbolAVL<T> remplazoPadre = NodoAEliminar;
            NodoArbolAVL<T> reemplazo = NodoAEliminar;
            NodoArbolAVL<T> auxiliar = NodoAEliminar.hijoDerecho;
            while (auxiliar != null)
            {
                remplazoPadre = reemplazo;
                reemplazo = auxiliar;
                auxiliar = auxiliar.hijoIzquierdo;
            }
            if (reemplazo != NodoAEliminar.hijoDerecho)
            {
                remplazoPadre.hijoIzquierdo = reemplazo.hijoDerecho;
                reemplazo.hijoDerecho = NodoAEliminar.hijoDerecho;
            }
            return reemplazo;
        }

        /// <summary>
        /// Delegado para Realizar Ordenes
        /// </summary>
        /// <param name="Datos">Lista con Datos Ordenados</param>
        public delegate void Ordenes(ref List<T> Datos);

        /// <summary>
        /// Metodo para realizar ordenamientos utilzando delegados
        /// </summary>
        /// <param name="Datos">Lista de Datos Ordenados</param>
        /// <param name="orden">Tipo de orden</param>
        /// <example>
        /// Ordenar InOrder
        /// <code>
        /// Ordenar(ref ListaDatos, InOrder);
        /// </code>
        /// </example>
        public void Ordenar(ref List<T> Datos, Ordenes orden)
        {
            orden(ref Datos);
        }

        /// <summary>
        /// Metodo que recorre el arbol en Preorden
        /// </summary>
        /// <param name="Datos">Datos Ordenados</param>
        public void PreOrder(ref List<T> Datos)
        {
            PreOrder(Raiz, ref Datos);
        }
        /// <summary>
        /// Metodo que recorre el arbol en Inorden
        /// </summary>
        /// <param name="Datos">Datos Ordenados</param>
        public void InOrder(ref List<T> Datos)
        {
            InOrder(Raiz, ref Datos);
        }
        /// <summary>
        /// Metodo que recorre el arbol en Inorden
        /// </summary>
        /// <param name="Datos">Datos Ordenados</param>
        public void PostOrder(ref List<T> Datos)
        {
            PostOrder(Raiz, ref Datos);
        }

        /// <summary>
        /// Metodo Recursivo que recorre el arbol
        /// </summary>
        /// <param name="Aux">Nodo Raiz</param>
        /// <param name="Elements">Lista de Datos en Orden</param>
        private void PreOrder(NodoArbolAVL<T> Aux, ref List<T> Elements)
        {
            if (Aux != null)
            {
                Elements.Add(Aux.value);
                PreOrder(Aux.hijoIzquierdo, ref Elements);
                PreOrder(Aux.hijoDerecho, ref Elements);
            }
        }
        /// <summary>
        /// Metodo Recursivo que recorre el arbol
        /// </summary>
        /// <param name="Aux">Nodo Raiz</param>
        /// <param name="Elements">Lista de Datos en Orden</param>
        private void InOrder(NodoArbolAVL<T> Aux, ref List<T> Elements)
        {
            if (Aux != null)
            {
                InOrder(Aux.hijoIzquierdo, ref Elements);
                Elements.Add(Aux.value);
                InOrder(Aux.hijoDerecho, ref Elements);
            }
        }
        /// <summary>
        /// Metodo Recursivo que recorre el arbol
        /// </summary>
        /// <param name="Aux">Nodo Raiz</param>
        /// <param name="Elements">Lista de Datos en Orden</param>
        private void PostOrder(NodoArbolAVL<T> Aux, ref List<T> Elements)
        {
            if (Aux != null)
            {
                PostOrder(Aux.hijoIzquierdo, ref Elements);
                PostOrder(Aux.hijoDerecho, ref Elements);
                Elements.Add(Aux.value);
            }
        }

    }
}