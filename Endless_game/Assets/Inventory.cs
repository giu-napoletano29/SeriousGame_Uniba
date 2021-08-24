using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;
    private Collider bin;
    private bool BinEnabled = false;

    public GameObject slotHolder;

    private void Start()
    {
        allSlots = 3;
        slot = new GameObject[allSlots];

        for(int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
    }
    void Update()
    {
        int i = -1;
        if (BinEnabled)
        {

            if (Input.GetKeyDown(KeyCode.U))
            {
                Debug.Log("Upress");
                i = 0;
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                Debug.Log("Ipress");
                i = 1;
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                Debug.Log("Opress");
                i = 2;
            }
            RemoveItem(i, bin.tag);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();

            AddItem(itemPickedUp , item.ID, item.type, item.desc, item.icon);
        }

        
        if (other.tag == "Bin_plastic" || other.tag == "Bin_glass" || other.tag == "Bin_paper")
        {
            BinEnabled = true;
            bin = other;
            Debug.Log("Bin enabled");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bin_plastic" || other.tag == "Bin_glass" || other.tag == "Bin_paper")
        {
            BinEnabled = false;
            Debug.Log("Bin disabled");
        }
    }

    void AddItem(GameObject itemObj , int ID, string type, string desc, Sprite icon)
    {
        for (int i = 0; i < allSlots; i++)
        {
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
                return;
            }
        }
    }

    void RemoveItem(int i, string type)
    {
        if (i > -1)
        {
            if (string.Equals(type, slot[i].GetComponent<Slot>().type))
            {

                slot[i].GetComponent<Slot>().item = null;
                slot[i].GetComponent<Slot>().icon = null;
                slot[i].GetComponent<Slot>().ID = -1;
                slot[i].GetComponent<Slot>().desc = null;

                //slot[i].transform.GetChild(0);
                slot[i].transform.DetachChildren();
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
    }
}

