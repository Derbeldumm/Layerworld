using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUpdate : MonoBehaviour {
    public ItemManager itemManager;
    public Text counter;
    Image bgi;
    Color32 inactive = new Color32(255, 255, 255, 100);
    Color32 active = new Color32(255, 255, 255, 255);
    string name;
    int number;

    private void Start()
    {
        name = transform.name.ToCharArray()[4].ToString();
        number = int.Parse(name);
    }

    // Update is called once per frame
    void Update () {
        //print(number);
        if (itemManager.activeSlot == number)
        {
            GetComponent<Image>().color = active;
           // print("ac");

        }
        else
        {
            GetComponent<Image>().color = inactive;
        }
        counter.text = itemManager.items[itemManager.activeBar,number].ToString();
        if (itemManager.changes > 0)
        {
            
            GetComponent<Image>().sprite = itemManager.bgis[itemManager.activeBar][number];
            itemManager.changes--;
            
        }   
	}
}
