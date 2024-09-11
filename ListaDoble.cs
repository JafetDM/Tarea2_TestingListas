using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace ListasEnlazadas
{

public class Nodo
{

    //atributos 
    public int Data;
    public Nodo Next;
    public Nodo Prev;

    //metodos


    public Nodo(int data) //constructor
    {
        Data = data;
        Next = null;
        Prev = null;
    }

}

public class ListaDoble
{

    //atributos 

    private Nodo head;
    private Nodo cola;
    private Nodo Middle;
    private int contador;

    public ListaDoble()
    {
        head = null;
        cola = null;
        Middle = null;
        contador = 0;
    }

    public void InsertInOrder(int data)
    {
        Nodo auxiliar = new Nodo(data);
        contador ++;

        if (head == null) // si la lista esta vacia 
        {
            head = auxiliar;
            cola = auxiliar;
            Middle = auxiliar;

        }

        else if (data <= head.Data) 
        //si el numero a agregar es mayor a la cabeza, se agrega al inicio
        {
            auxiliar.Next = head; 
            head.Prev = auxiliar;
            head = auxiliar; //el elemento agregado se vuelve la nueva cabeza

        }

        else if (data >= cola.Data)
        //si el numero a agregar es menor al ultimo dato, se agrega al final
        {
            cola.Next = auxiliar;
            auxiliar.Prev = cola;
            cola = auxiliar; //el elemento agregado se vuelve la nueva cola
        }

        else //busca en el medio de la lista para ver donde colocarlo
        {
            Nodo current = head; //nodo usado para recorrer
            while (current != null && data >= current.Data)
            {
                current = current.Next; 
                //mientras sea menor, recorre la lista (o bien hasta que llegue al final)
            }

            //si encuentra un nodo current que sea mayor al dato
            // coloca el nuevo numero en medio 
            auxiliar.Next = current; //el siguiente del nuevo se vuelve el elemento encontrado
            auxiliar.Prev = current.Prev; //el previo del nuevo se vuelve el que era el previo del elemento encontrado

            if (current.Prev != null)
            {
                current.Prev.Next = auxiliar;
            }

            current.Prev = auxiliar;
        }

        ActualizaMedio(auxiliar); //actualiza el elemento central
    }

    private void ActualizaMedio(Nodo auxiliar)
    {
        if (contador == 1) //solo hay un elemento
        {
            Middle = head; //la cabeza es la mitad
        }

        else if (contador % 2 == 0) 
        //si hay un numero par de elementos
        //el elemento central se vuelve el siguiente
        {
            if (auxiliar.Data >= Middle.Data) // Si el nuevo nodo está después del medio
            {
                Middle = Middle.Next; // Avanza el nodo central
            }
        }

        else 
        //si hay un numero impar de elementos
        //el elemento central se mantiene 
        {
            if (auxiliar.Data < Middle.Data) // Si el nuevo nodo está después del medio
            {
                Middle = Middle.Prev; // Avanza el nodo central
            }
        }

        

    }

    public int GetMiddle()
    {
       if (Middle != null)
        {
            return Middle.Data;
        }
        
        throw new InvalidOperationException("lista esta vacia");
    }

    public void PrintList ()
    {
        Nodo auxiliar = head;
        while (auxiliar != null)
        {
            Console.Write(auxiliar.Data +  " ");
            auxiliar = auxiliar.Next;
        }
        Console.WriteLine();
    }

}


}
