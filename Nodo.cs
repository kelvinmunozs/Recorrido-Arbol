namespace RecorridosArbol
{
    internal partial class Program
    {
        //Esta clase nos facilita trabajar con los nodos en nuestro arbol
        class Nodo
        {
            public Nodo NodoIzquierdo { get; set; }
            public Nodo NodoDerecho { get; set; }
            public int Data { get; set; }
        }
        
    }
}
