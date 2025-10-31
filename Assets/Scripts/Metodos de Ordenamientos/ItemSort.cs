using System;
using System.Collections.Generic;
using UnityEngine;

public static class ItemSort//<<Normalmente, se la llama Utils y se almacenan los metodos
{
    public static void Bubble(List<Item> list, Comparison<Item> comparison)
    {//Ordena comparando elementos, agrupando de a 2 y los intercambia
        if(list == null || list.Count <= 1) return;

        bool swapped = true;//Bandera
        int n = list.Count;//Cantidad de veces para repasar

        while (swapped)
        {
            swapped = false;
            for(int i = 1; i < n; i++)
            {
                if (comparison(list[i - 1], list[i]) > 0) //Verifico que sea > a "0"
                {
                    (list[i - 1], list[i]) = (list[i], list[i - 1]); 
                    //var temp = list[i - 1];//"Item Temporal"
                    //list[i - 1] = list[i];//Item Proximo
                    //list[i] = temp;
                    swapped = true;
                }
            }
            n--;
        }

    }
    //************************************************************************
    public static void Insertion(List<Item> list, Comparison<Item> comparison)
    {
        if (list == null || list.Count <= 1) return;

        //arranco desde el 1, ya que, el 0 sera el pivote
        for (int i = 1; i < list.Count; i++) {
            Item key = list[i];
            int j = i - 1;
            
            while(j >= 0 && comparison(list[j], key) > 0) 
            {
                list[j + 1] = list[j];
                j--;
            }
            list[j + 1] = key;
        }
    }
    //************************************************************************
    public static void Quick(List<Item> list, Comparison<Item> comparison)
    {
        if (list == null || list.Count <= 1) return;

        QuickSort(list, 0, list.Count - 1, comparison);
    }

    static void QuickSort(List<Item> list, int low, int high, Comparison<Item> comparison)
    {
        if (low >= high) return; //Si o si, debo un return, si no, se rompera tu PC

        int p = Partition(list, low, high, comparison);//genero las particiones
        QuickSort(list, low, p - 1, comparison);//Pivote Izquierdo
        QuickSort(list, p + 1, high, comparison);//Pivote Derecho
    }

    static int Partition(List<Item> list, int low, int high, Comparison<Item> comparison)
    {
        Item pivot = list[high];//elijo el ultimo numero como pivote
        int i = low;

        for(int j = low; j < high; j++)
        {
            if (comparison(list[j], pivot) < 0)
            {
                (list[i], list[j]) = (list[j], list[i]);
                i++;
            }
        }
        (list[i], list[high]) = (list[high], list[i]);
        return i;
    }

}
