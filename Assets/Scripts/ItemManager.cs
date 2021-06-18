using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemManager : MonoBehaviour
{
    public Transform placeholder; // Content placeholder to Instantiate gameobjects
    public GameObject rowItem; // Unity prefab to Instantiate

    private List<Item> items = new List<Item>();
    private List<GameObject> gameObjects = new List<GameObject>(); // Reference to Gameobjects to destroy them

    private void OnEnable()
    {
        ClearGos();

        List<GameData.ItemForSlotDatas> data = GameData.instance.itemForSlotDatas;
     
            for (int i = 0; i < data.Count; i++)
            {
                items.Add(new Item(data[i].ýd, data[i].name, data[i].record));
                ShowItemForSlot(i);
            }
        }

    private void ShowItemForSlot(int i)
    {
        Item item = items[i];

        var go = Instantiate(rowItem, placeholder.transform) as GameObject;
        ItemListRow row = go.GetComponent<ItemListRow>();

        row.SetUi(item);

        //Add Delegates to row item buttons
        row.removeButton.onClick.AddListener(RemoveItem(item));
        gameObjects.Add(go);
    }

    private UnityAction RemoveItem(Item item) => delegate {
        print("Remove item " + item.name);
        
    };

    //Clean Up
    private void ClearGos()
    {
        foreach (var go in gameObjects) Destroy(go);
        gameObjects.Clear();
    }
}


