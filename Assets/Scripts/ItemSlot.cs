using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Image itemImage, frameImagen;
    [SerializeField] TextMeshProUGUI itemNameText;
    [SerializeField] Color highlightColor;

    Color defaultColor;

    private void Awake() {
        defaultColor = frameImagen.color;
    }

    public Item CurrentItem { get; private set; }//autopropiedad
    //Es buena practica almacenar la info del propio item, para desplazarlo y etc

    public void SetItem(Item item) {
        CurrentItem = item;
        itemImage.sprite = CurrentItem.Sprite;
        itemNameText.text = $"{CurrentItem.Name} (#:{CurrentItem.Id})";
    }

    public void SetHighLight(bool on) {//Prendo o Apago el Marco del item
        frameImagen.color = on ? highlightColor : defaultColor;
    }

}
