using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public struct NameAndSprite { //-> Estructura de datos sobre el item
    public string name;
    public Sprite sprite;
}//->Puede tener funciones, contructores

[System.Serializable]
public class Item { //-> Datos para crear y implementar una ID unica
    public int Id;
    public string Name;
    public Sprite Sprite;
}

public class ItemManager : MonoBehaviour {
    public NameAndSprite[] namesAndSprites;//<< Digo cuales seran los items que quiero cargar
    public List<Item> items = new();//<< Almaceno todos los items en mi Lista

    [SerializeField] int itemsAmount = 500; //Crear items
    [SerializeField] GameObject itemPrefab; //Prefab del modelo del boton
    [SerializeField] Transform inventoryPanel; //A donde se lo instancia los Botones?
    [SerializeField] ScrollRect BarraInventario;

    List<ItemSlot> misSlots = new(); //Almaceno todos mis items slots para des/activar su frameImagen

    private void Start() {
        GenerateItems();
        PopulateInventory();
    }

    void GenerateItems() {
        for (int i = 0; i < itemsAmount; i++) {
            var _randomIndex = Random.Range(0,namesAndSprites.Length);
            var _item = new Item {// << == Item item = new Item{}
                Id = i,
                Name = namesAndSprites[_randomIndex].name + " " + Random.Range(1000,9999),
                Sprite = namesAndSprites[_randomIndex].sprite,
            };
            items.Add(_item);
        }
    }

    public void PopulateInventory()
    {//seteo los botones con sus sprites y nombres
        for(int i = inventoryPanel.childCount - 1; i >= 0; i--)
        {
            Destroy(inventoryPanel.GetChild(i).gameObject);
        }//Uso un for Invertido para eliminar los hijos, de esta manera no tendre un error "indexOfRange"

        misSlots.Clear(); //<< buena practica, cuando repopular items en una lista, duplicacion de items
        for(int i = 0; i < items.Count; i++)
        {
            ItemSlot _itemCurrent = Instantiate(itemPrefab, inventoryPanel).GetComponent<ItemSlot>();
            _itemCurrent.SetItem(items[i]);
            misSlots.Add(_itemCurrent);
        }

        ClearHighlights();
        ScrollToTop();
    }

    public void ClearHighlights()
    {
        foreach(Transform child in inventoryPanel)
        {
            child.GetComponent<ItemSlot>().SetHighLight(false);//Es valido pero es muy costoso
        }

    }

    void ScrollToTop()
    {//Funcion dedicada para la scroll (BarraInventario)
        BarraInventario.verticalNormalizedPosition = 1f; //Seteo la barra para arriba
        Canvas.ForceUpdateCanvases();//forzar a la actualizacion del canvas, es ma a del unity
    }

    void ScrollToIndex(int index)
    {//Hago scroll hasta el item buscado
        //clamp vs clamp01 => clamp01 esta normalizado, esta limitado entre 0 a 1 "Es un Atajo" del clamp
        float f = Mathf.Clamp01(index / Mathf.Max(1f, items.Count - 1));
        float normalizedPosition = 1f - f;//invierto la polaridad del scroll (1=Arriba; 0=Abajo)
        Debug.Log("Resultado: " + f + " || Index: " + index + " || Max: " + Mathf.Max(1f, items.Count - 1));

        BarraInventario.verticalNormalizedPosition = normalizedPosition;
        Canvas.ForceUpdateCanvases();
    }

    public void HighlightSearchResult(int index)
    {
        ClearHighlights();
        if(index >= 0 && index < misSlots.Count)
        {
            misSlots[index].SetHighLight(true);
            ScrollToIndex(index);
        }
    }

}
