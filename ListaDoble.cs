using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace ListasEnlazadas
{

    public enum SortDirection //enum utilizado para dar direccion
{
    Ascending,
    Descending
}

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

    public void DeleteFirst()
    {
        if (head == null) //si esta vacia
        {
            throw new InvalidOperationException
            ("La lista está vacía. No se puede eliminar el primer elemento.");
        }

        else if (head == cola) //si solo tiene un elemento
        {
            contador = contador - 1;
            head = null;
            cola = null;
        }

        else
        {
            contador = contador -1;
            head = head.Next;
            head.Prev = null;
        }

        // Actualizar el nodo central
        if (contador % 2 == 0)
        {
            Middle = Middle.Next;
        }
    }

    public void DeleteLast()
    {
        if (head == null) //si esta vacia
        {
            throw new 
            InvalidOperationException
            ("La lista está vacía. No se puede eliminar el primer elemento.");
        }

        else if (head == cola) //si solo hay un elemento
        {
            contador --;
            head = null;
            cola = null;
        }

        else
        {
            contador --;
            cola = cola.Prev;
            cola.Next = null;
        }

        // Actualizar el nodo central
        if (contador % 2 != 0)
        {
            Middle = Middle.Prev;
        }

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

    public void Invertir()
    {
        Nodo current = head; // Nodo para recorrer la lista
        Nodo temp = null; // Nodo temporal para intercambiar punteros

        // Intercambiar los punteros Next y Prev de cada nodo
        while (current != null)
        {
            temp = current.Prev; // Guardar el puntero Prev
            current.Prev = current.Next; // Cambiar Prev al Next
            current.Next = temp; // Cambiar Next al puntero anterior (guardado en temp)

            // Mover al siguiente nodo
            current = current.Prev; // Como hemos intercambiado, current.Prev es el siguiente nodo
        }

        // Ajustar head y tail (cola)
        if (temp != null)
        {
            head = temp.Prev; // temp apunta al nodo previo al antiguo head
            cola = head;      // cola es el nuevo head, ya que hemos invertido
        }
    }

    public void InsertarF(int data) //metodo que inserta al final para crear 
    //una lista sin orden, solo es usada para testing
    {
        Nodo auxiliar = new Nodo(data);
        contador ++;

        if (head == null) //si la lista esta vacia
        {
            head = auxiliar;
            cola = auxiliar;
        }

        else
        {
            cola.Next = auxiliar; //establece el ultimo nodo despues de la cola
            auxiliar.Prev = cola; //convierte la cola en el previo del auxiliar
            cola = auxiliar; // convierte al auxiliar en la nueva cola

        }
    } 

    // Metodo para fusionar dos listas
    public void 
    MergeSorted(ListaDoble listA, ListaDoble listB, SortDirection direction)
    {
        //creamos una lista donde almacenar la fusion y nodos para recorrer cada lista
        ListaDoble mergedList = new ListaDoble();
        Nodo currentA = listA.head;
        Nodo currentB = listB.head;

        //fusion en orden ascendente
        if (direction == SortDirection.Ascending)
        {
           while(currentA != null) //recorremos todo el nodo, agregamos en orden
           {
            mergedList.InsertInOrder(currentA.Data);
            currentA = currentA.Next;
           }

           while(currentB != null)//recorremos todo el nodo, agregamos en orden
           {
            mergedList.InsertInOrder(currentB.Data);
            currentB = currentB.Next;
           }
        }
        else if (direction == SortDirection.Descending)
        {
            //fusion en orden descendente
            while(currentA != null) //recorremos todo el nodo, agregamos en orden
           {
            mergedList.InsertInOrder(currentA.Data);
            currentA = currentA.Next;
           }

           while(currentB != null)//recorremos todo el nodo, agregamos en orden
           {
            mergedList.InsertInOrder(currentB.Data);
            currentB = currentB.Next;
           }

            // como la lista estara ascendente pero la queremos descendente, la invertimos
            mergedList.Invertir();
        }

        //finalmente, asignamos la cabeza y cola de la lista creada a nuestra lista b
        //asi la lista b ha sido mezclada en la lista 1

        this.head = mergedList.head;
        this.cola = mergedList.cola;
    }


    //Metodo usado para comparar dos listas. Usado para el testing
    public bool Comparar(ListaDoble otraLista)
{
    Nodo currentA = this.head;
    Nodo currentB = otraLista.head;

    while (currentA != null && currentB != null)
    {
        if (currentA.Data != currentB.Data) 
        {
            return false; // Los valores no coinciden
        }
        
        currentA = currentA.Next;
        currentB = currentB.Next;
    }

    // Si una lista es más larga que la otra o en efecto son iguales
    return true;
}

}
}
