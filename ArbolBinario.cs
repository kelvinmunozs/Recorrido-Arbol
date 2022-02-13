using System;

namespace RecorridosArbol
{
    internal partial class Program
    {
        class ArbolBinario
        {
            public Nodo Root { get; set; }

            //Este bloque de codigo se encarga de añadir valores a nuestro arbol binario
            public bool Añadir(int valor)
            {
                Nodo antes = null, despues = this.Root;

                while (despues != null)
                {
                    antes = despues;
                    if (valor < despues.Data) //Insertamos el nodo en la posicion izquierda
                        despues = despues.NodoIzquierdo;
                    else if (valor > despues.Data) //Insertamos el nodo en la posicion derecha
                        despues = despues.NodoDerecho;
                    else
                    {
                        //Ya existe el mismo valor
                        return false;
                    }
                }

                Nodo nuevoNodo = new Nodo();
                nuevoNodo.Data = valor;

                if (this.Root == null)//El abol esta vacio
                    this.Root = nuevoNodo;
                else
                {
                    if (valor < antes.Data)
                        antes.NodoIzquierdo = nuevoNodo;
                    else
                        antes.NodoDerecho = nuevoNodo;
                }

                return true;
            }

            //Este bloque de codigo nos permite buscar
            public Nodo Buscar(int valor)
            {
                return this.Buscar(valor, this.Root);
            }

            //Este bloque de codigo nos permite eliminar un nodo con un valor en especifico
            public void Eliminar(int valor)
            {
                this.Root = Eliminar(this.Root, valor);
            }

            //Este bloque de codigo nos permite eliminar un nodo tomando en cuenta la llave que lo representa
            private Nodo Eliminar(Nodo padre, int llave)
            {
                if (padre == null) return padre;

                if (llave < padre.Data) padre.NodoIzquierdo = Eliminar(padre.NodoIzquierdo, llave);
                else if (llave > padre.Data)
                    padre.NodoDerecho = Eliminar(padre.NodoDerecho, llave);

                // Si el valor es igual que el valor del padre entonces se eliminara 
                else
                {
                    // Nodo con un solo hijo o sin hijos
                    if (padre.NodoIzquierdo == null)
                        return padre.NodoDerecho;
                    else if (padre.NodoDerecho == null)
                        return padre.NodoIzquierdo;

                    // Nodo con dos hijos para obtener el sucesor in-orden
                    padre.Data = Valormin(padre.NodoDerecho);

                    // Borra el sucesor in-orden
                    padre.NodoDerecho = Eliminar(padre.NodoDerecho, padre.Data);
                }

                return padre;
            }

            //Este bloque de codigo nos permite encontrar el valor minimo de un nivel en el arbol
            private int Valormin(Nodo Nodo)
            {
                int valmin = Nodo.Data;

                while (Nodo.NodoIzquierdo != null)
                {
                    valmin = Nodo.NodoIzquierdo.Data;
                    Nodo = Nodo.NodoIzquierdo;
                }

                return valmin;
            }

            //Este bloque de codigo nos permite buscar un nodo en especifico tomando en cuenta el valor que posee y su padre
            private Nodo Buscar(int valor, Nodo padre)
            {
                if (padre != null)
                {
                    if (valor == padre.Data) return padre;
                    if (valor < padre.Data)
                        return Buscar(valor, padre.NodoIzquierdo);
                    else
                        return Buscar(valor, padre.NodoDerecho);
                }

                return null;
            }

            //Este bloque de codigo nos permite obtener el nivel de profundidad de un arbol
            public int ObtenerProfundidad()
            {
                return this.ObtenerProfundidad(this.Root);
            }

            //Este bloque de codigo nos permite obtener el nivel de profundidad de un nodo en especifico
            private int ObtenerProfundidad(Nodo padre)
            {
                return padre == null ? 0 : Math.Max(ObtenerProfundidad(padre.NodoIzquierdo), ObtenerProfundidad(padre.NodoDerecho)) + 1;
            }

            //Este bloque de codigo nos permite realizar un recorrido Pre-Orden
            public void RecorridoPreOrden(Nodo padre)
            {
                if (padre != null)
                {
                    Console.Write(padre.Data + " ");
                    RecorridoPreOrden(padre.NodoIzquierdo);
                    RecorridoPreOrden(padre.NodoDerecho);
                }
            }

            //Este bloque de codigo nos permite realizar un recorrido In-Orden
            public void RecorridoInOrden(Nodo padre)
            {
                if (padre != null)
                {
                    RecorridoInOrden(padre.NodoIzquierdo);
                    Console.Write(padre.Data + " ");
                    RecorridoInOrden(padre.NodoDerecho);
                }
            }

            //Este bloque de codigo nos permite realizar un recorrido Post-Orden
            public void RecorridoPostOrden(Nodo padre)
            {
                if (padre != null)
                {
                    RecorridoPostOrden(padre.NodoIzquierdo);
                    RecorridoPostOrden(padre.NodoDerecho);
                    Console.Write(padre.Data + " ");
                }
            }
        }
        
    }
}
