using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListasEnlazadas;


namespace MSTest_Tarea2
{

    
    [TestClass]
public class UnitTest1
// en las pruebas unitarias, definimos el resultado esperado y lo comparamos con AreEqual
{

    //por como la lista esta definida, no aceptara valores que no sean int, 
    //por lo tanto no hae falta verificarlo. Lo mismo con null, siempre pide un parametro.

    //
    //PRUEBAS UNITARIAS DEL PROBLEMA 1 - MEZCLAR LISTAS
    //

    [TestMethod]
    //prueba de entrada (uno vacio, otro ascendente) con salida descendente. 
    //mezcla (9,40,50) con ()
    //Devuelve la mezcla de ambas en descendente (50,40,9)

    public void TestMethod_Mezclar_Desc_Vacio()
    {

        //lista vacia
        ListaDoble resultado = new ListaDoble();

        //listas a mezclar
        ListaDoble list1 = new ListaDoble(); //vacia

        ListaDoble list2 = new ListaDoble(); 
        list2.InsertInOrder(9);
        list2.InsertInOrder(40);
        list2.InsertInOrder(50);

        list2.MergeSorted(list1, list2, SortDirection.Descending);

        resultado = list2;

        //lista de prueba para comparar resultados

        ListaDoble prueba = new ListaDoble();
        prueba.InsertInOrder(9);
        prueba.InsertInOrder(40);
        prueba.InsertInOrder(50);
        prueba.Invertir();

        Console.WriteLine("Resultado esperado es: ");
        prueba.PrintList();

        Assert.IsTrue(resultado.Comparar(prueba), "la lista no se mezclo correctamente");
        Console.WriteLine("Resultado obtenido: ");
        resultado.PrintList();

    }

    [TestMethod]
    //prueba de entrada (uno vacio, otro ascendente) con salida ascendente. 
    //mezcla (10,15) con ()
    //Devuelve la mezcla de ambas en ascendente (10,15)

    public void TestMethod_Mezclar_Asc_Vacio()
    {

        //lista vacia
        ListaDoble resultado = new ListaDoble();

        //listas a mezclar
        ListaDoble list1 = new ListaDoble();
        list1.InsertInOrder(15);
        list1.InsertInOrder(10);

        ListaDoble list2 = new ListaDoble(); //vacia

        list2.MergeSorted(list1, list2, SortDirection.Ascending);

        resultado = list2;

        //lista de prueba para comparar resultados

        ListaDoble prueba = new ListaDoble();
        prueba.InsertInOrder(10);
        prueba.InsertInOrder(15);

        Console.WriteLine("Resultado esperado es: ");
        prueba.PrintList();

        Assert.IsTrue(resultado.Comparar(prueba), "la lista no se mezclo correctamente");
        Console.WriteLine("Resultado obtenido: ");
        resultado.PrintList();

    }


    [TestMethod]
    //prueba de entrada (ambos ascendente) con salida ascendente. 
    //mezcla (0,2,10) con (3,7,40)
    //Devuelve la mezcla de ambas en ascendente (0,2,3,7,10,40)

    public void TestMethod_Mezclar_Asc()
    {

        //lista vacia
        ListaDoble resultado = new ListaDoble();

        //listas a mezclar
        ListaDoble list1 = new ListaDoble();
        list1.InsertInOrder(0);
        list1.InsertInOrder(2);
        list1.InsertInOrder(10);

        ListaDoble list2 = new ListaDoble();
        list2.InsertInOrder(3);
        list2.InsertInOrder(7);
        list2.InsertInOrder(40);

        list2.MergeSorted(list1, list2, SortDirection.Ascending);

        resultado = list2;

        //lista de prueba para comparar resultados

        ListaDoble prueba = new ListaDoble();
        prueba.InsertInOrder(0);
        prueba.InsertInOrder(2);
        prueba.InsertInOrder(3);
        prueba.InsertInOrder(7);
        prueba.InsertInOrder(10);
        prueba.InsertInOrder(40);

        Console.WriteLine("Resultado esperado es: ");
        prueba.PrintList();

        Assert.IsTrue(resultado.Comparar(prueba), "la lista no se mezclo correctamente");
        Console.WriteLine("Resultado obtenido: ");
        resultado.PrintList();

    }

    [TestMethod]
    //prueba de entrada (ambos ascendente) con salida descendente.
    //mezcla (10, 15) con (9, 40, 50)
    //Devuelve la mezcla de ambas en descendente (50, 40, 15, 10, 9)

    public void TestMethod_Mezclar_Des()
    {

        //lista vacia
        ListaDoble resultado = new ListaDoble();

        //listas a mezclar
        ListaDoble list1 = new ListaDoble();
        list1.InsertInOrder(10);
        list1.InsertInOrder(15);

        ListaDoble list2 = new ListaDoble();
        list2.InsertInOrder(9);
        list2.InsertInOrder(50);
        list2.InsertInOrder(40);

        list2.MergeSorted(list1, list2, SortDirection.Ascending);

        resultado = list2;

        //lista de prueba para comparar resultados

        ListaDoble prueba = new ListaDoble();
        prueba.InsertInOrder(9);
        prueba.InsertInOrder(10);
        prueba.InsertInOrder(40);
        prueba.InsertInOrder(50);
        prueba.InsertInOrder(15);

        Console.WriteLine("Resultado esperado es: ");
        prueba.PrintList();
        Console.WriteLine("Resultado obtenido: ");
        resultado.PrintList();

        Assert.IsTrue(resultado.Comparar(prueba), "la lista no se mezclo correctamente");

    }

    //
    //PRUEBAS UNITARIAS DEL PROBLEMA 2 - INVERTIR LISTA
    //

    [TestMethod]
    //prueba de entrada una lista vacia. Devuelve una lista vacia.
    public void TestMethod_Invertir_Vacio()
    {
        //lista a testear

        ListaDoble list = new ListaDoble();
        list.Invertir();
        ListaDoble resultado = list;

        //lista para probar
        ListaDoble prueba = new ListaDoble();

        Assert.IsTrue(resultado.Comparar(prueba), "la lista no se invirtio correctamente");
        Console.WriteLine("Resultado esperado: ");
        prueba.PrintList();
        Console.WriteLine("Resultado obtenido: ");
        resultado.PrintList();
        
    }

    [TestMethod]
    //prueba de entrada 2. Devuelve 2
    public void TestMethod_Invertir2()
    {

        //lista a testear

        ListaDoble list = new ListaDoble();

        list.InsertInOrder(2);
        list.Invertir();
        ListaDoble resultado = list;

        //lista de testing creada sin orden
        ListaDoble prueba = new ListaDoble();
        prueba.InsertarF(2);
        
        

        Assert.IsTrue(resultado.Comparar(prueba), "la lista no se invirtio correctamente");
        Console.WriteLine("Resultado esperado: ");
        prueba.PrintList();
        Console.WriteLine("Resultado obtenido: ");
        resultado.PrintList();

    }

    [TestMethod]
    //prueba de entrada 0,1,2,30,50. Devuelve 50,30,2,1,0
    public void TestMethod_Invertir0_1_2_30_50()
    {

        //lista a testear

        ListaDoble list = new ListaDoble();

        list.InsertInOrder(1);
        list.InsertInOrder(0);
        list.InsertInOrder(30);
        list.InsertInOrder(50);
        list.InsertInOrder(2);
        list.Invertir();
        ListaDoble resultado = list;

        //lista de testing creada sin orden
        ListaDoble prueba = new ListaDoble();
        prueba.InsertarF(50);
        prueba.InsertarF(30);
        prueba.InsertarF(2);
        prueba.InsertarF(1);
        prueba.InsertarF(0);
        
        
        Console.WriteLine("Resultado esperado: ");
        prueba.PrintList();
        Assert.IsTrue(resultado.Comparar(prueba), "la lista no se invirtio correctamente");
        Console.WriteLine("Resultado obtenido: ");
        resultado.PrintList();

    }
    
    //
    //PRUEBAS UNITARIAS DEL PROBLEMA 3 - GET MIDDLE
    //

    [TestMethod]
    //prueba de entrada lista vacia. Devuelve una excepcion por vacia
    //Get Middle se definio para que tire una excepcion si la lista es vacia
    public void TestMethod_GetMiddle_Vacio()
    {
        ListaDoble list = new ListaDoble();

        try //se realiza un try para que intente la operacion
        {
            list.GetMiddle();
            Assert.Fail("Se esperaba una excepción de tipo InvalidOperationException.");
        }

        catch (System.InvalidOperationException ex)
        //por como se planteo, el metodo va a devolver una excepcion
        //por lo tanto, se captura la excepcion y se compara que sea igual
        {
            Assert.AreEqual("lista esta vacia", ex.Message);
            Console.WriteLine($"Excepción capturada correctamente: {ex.Message}");
        }


    }

    [TestMethod]
    //prueba de entrada 1. Devuelve 1
    public void TestMethod_GetMiddle1()
    {

        ListaDoble list = new ListaDoble();

        list.InsertInOrder(1);

        int result = list.GetMiddle();
        Assert.AreEqual(1, result);
        Console.WriteLine($"Resultado obtenido correctamente: {result}");

    }

    [TestMethod]
    //prueba de entrada 1,2. Devuelve 2
    public void TestMethod_GetMiddle1_2()
    {

        ListaDoble list = new ListaDoble();

        list.InsertInOrder(1);
        list.InsertInOrder(2);

        int result = list.GetMiddle();
        Assert.AreEqual(2, result);
        Console.WriteLine($"Resultado obtenido correctamente: {result}");

    }

    [TestMethod]
    //prueba de entrada 0,1,2. Devuelve 1
    public void TestMethod_GetMiddle0_1_2()
    {

        ListaDoble list = new ListaDoble();

        list.InsertInOrder(1);
        list.InsertInOrder(2);
        list.InsertInOrder(0);

        int result = list.GetMiddle();
        Assert.AreEqual(1, result);
        Console.WriteLine($"Resultado obtenido correctamente: {result}");

    }

    [TestMethod]
    //prueba de entrada 0,1,2,3. Devuelve 2
    public void TestMethod_GetMiddle0_1_2_3()
    {

        ListaDoble list = new ListaDoble();

        list.InsertInOrder(1);
        list.InsertInOrder(2);
        list.InsertInOrder(0);
        list.InsertInOrder(3);

        int result = list.GetMiddle();
        Assert.AreEqual(2, result);
        Console.WriteLine($"Resultado obtenido correctamente: {result}");

    }
    
}

}
