using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    public GameObject slotHolder;

    private void Start()
    {
        allSlots = 3;
        slot = new GameObject[allSlots];

        for(int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            Debug.Log("Slot " + i + " | name: " + slot[i].GetComponent<Slot>().item);
            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
            Debug.Log("Empty " + slot[i].GetComponent<Slot>().empty);
        }
    }
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp , item.ID, item.type, item.desc, item.icon);
        }
    }

    void AddItem(GameObject itemObj , int ID, string type, string desc, Sprite icon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            Debug.Log("AddItem empty: " + slot[i].GetComponent<Slot>().empty + " name: " + slot[i].GetComponent<Slot>().name + " obj: " + slot[i].GetComponent<Slot>().item);
            if (slot[i].GetComponent<Slot>().empty)
            {
                itemObj.GetComponent<Item>().PickedUp = true;

                slot[i].GetComponent<Slot>().item = itemObj;
                slot[i].GetComponent<Slot>().icon = icon;
                slot[i].GetComponent<Slot>().type = type;
                slot[i].GetComponent<Slot>().ID = ID;
                slot[i].GetComponent<Slot>().desc = desc;

                itemObj.transform.parent = slot[i].transform;
                itemObj.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
                Debug.Log("Post if");
                return;
            }
        }
    }
}

