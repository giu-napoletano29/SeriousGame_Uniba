using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public bool empty;
    public Sprite icon;
    public int ID;
    public string type;
    public string desc;

    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = icon;
    }
}
