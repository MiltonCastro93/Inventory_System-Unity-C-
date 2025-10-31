using UnityEngine;
using TMPro;
using System;
using System.Diagnostics; //Tomar Tiempo con Stopwatch

public class ItemSearch : MonoBehaviour {

    [SerializeField] ItemManager itemManager;//debo tener ref en donde guardo todos mis items
    [SerializeField] TMP_InputField searchInput;
    [SerializeField] TMP_Text resultText;

    bool sortedById = false; //Acomodar por ID
    bool sortedByName = false;

    string FormatTime(Stopwatch sw) { //Una funcion extra para medir el tiempo
        return $"{sw.Elapsed.TotalMilliseconds:F3} ms";
    }

    public void Search() { //Lo llamo desde un boton de la UI
        string query = searchInput.text;//almaceno el nombre/ID en un string

        if (string.IsNullOrWhiteSpace(query)) { //verifica si esta null o espacio en blanco
            resultText.text = "Please enter a search query";
            return;//si detecta, sale del bucle
        }

        string output = $"Searching for '{query}'...\n";

        int _id;
        if(int.TryParse(query, out _id))
        {//convierto string a int, si no tiene numeros no entra
            var sw = Stopwatch.StartNew();//Prendo el cronometro
            int indexLineal = LinealIdSearch(_id);//Proceso de busqueda por item (ID int)
            sw.Stop();//Una vez terminada la Busqueda lo detengo.

            output += $"Lineal ID Search:{FormatTime(sw)}\n";

            sw.Restart();
            int indexBinary = sortedById ? BinaryIdSearch(_id) : -1;
            sw.Stop();
            output += $"Binary ID Search: {FormatTime(sw)}\n";

            if(indexLineal >= 0)//BUSQUEDA LINEAL
            {
                output += $"Lineal Encontro : {itemManager.items[indexLineal].Name} (#:{itemManager.items[indexLineal].Id})\n";
                itemManager.HighlightSearchResult(indexLineal);
            } 
            else 
            {
                output += "Item not Found.";
                itemManager.ClearHighlights();
            }

            if(indexBinary >= 0)//BUSQUEDA BINARIA
            {
                output += $"Binary Encontro : {itemManager.items[indexBinary].Name} (#:{itemManager.items[indexBinary].Id})\n";
            }
            else if (sortedById)
            {
                output += "Item not found in Binary search.";
            }
            else
            {
                output += "List not sorted by ID. Binary Search Skipped.";
            }

        }
        else 
        {//si no, buscara por nombre
            var sw = Stopwatch.StartNew();
            int indexLineal = LinealNameSearch(query);//Proceso de busqueda por item (Name String)
            sw.Stop();
            output += $"Lineal Name Search:{FormatTime(sw)}\n";

            sw.Restart();
            int indexBinary = sortedByName ? BinaryNameSearch(query) : -1;
            sw.Stop();
            output += $"Binary Name Search:{FormatTime(sw)}\n";

            if (indexLineal >= 0)
            {
                output += $"Lineal Encontro : {itemManager.items[indexLineal].Name} (#:{itemManager.items[indexLineal].Id})\n";
                itemManager.HighlightSearchResult(indexLineal);
            }
            else
            {
                output += "Item not Found.";
                itemManager.ClearHighlights();
            }

            if (indexBinary >= 0)//BUSQUEDA BINARIA
            {
                output += $"Binary Encontro : {itemManager.items[indexBinary].Name} (#:{itemManager.items[indexBinary].Id})\n";
            }
            else if (sortedById)
            {
                output += "Item not found in Binary search.";
            }
            else
            {
                output += "List not sorted by Name. Binary Search Skipped.";
            }

        }

        resultText.text = output;
    }

    int LinealIdSearch(int ID) //BUSQUEDA LINEAL POR ID
    {
        for (int i = 0; i < itemManager.items.Count; i++) 
        {
            if (itemManager.items[i].Id == ID) 
            {
                return i;
            }
        }
        return -1;
    }

    int LinealNameSearch(string NAME)  //BUSQUEDA LINEAL POR NAME
    {
        for(int i = 0; i < itemManager.items.Count; i++) 
        {
            if (itemManager.items[i].Name == NAME) 
            {
                return i;
            }
        }
        return -1;
    }

    int BinaryIdSearch(int id)
    {
        int left = 0;
        int right = itemManager.items.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;//"Pivote"
            int midId = itemManager.items[mid].Id;

            if(midId == id) return mid;
            if (midId < id) left = mid + 1;//se puede hacer ++mid
            else right = mid - 1;
        }
        return -1;
    }

    int BinaryNameSearch(string NAME)
    {
        int left = 0;
        int right = itemManager.items.Count - 1;

        while(left <= right)
        {
            int mid = left + (right - left) / 2;
            string midName = itemManager.items[mid].Name;
            int comparison = string.Compare(midName, NAME, StringComparison.Ordinal);

            if (comparison == 0) return mid;
            if (comparison < 0) left = mid + 1;
            else right = mid - 1;

        }
        return -1;
    }

    public void SortById() { //Lo llamo desde el Boton de la UI
        var sw = Stopwatch.StartNew();
        // Es un delegado, pide 2 Obj del mismo tipo, le paso el valor ID de cada uno
        ItemSort.Quick(itemManager.items, (a, b) => a.Id.CompareTo(b.Id));//<<Cambiar entre metodos de ordenamiento
        sw.Stop();
        resultText.text = $"Sorted By ID in {FormatTime(sw)}";

        sortedById = true;
        sortedByName = false;

        itemManager.PopulateInventory();
    }

    public void SortByName() {
        var sw = Stopwatch.StartNew();
        ItemSort.Quick(itemManager.items, (a, b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));
        sw.Stop();
        resultText.text = $"Sorted By Name in {FormatTime(sw)}";

        sortedByName = true;
        sortedById = false;

        itemManager.PopulateInventory();
    }

}
