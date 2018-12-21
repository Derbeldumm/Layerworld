using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBehave : MonoBehaviour {
    public GameObject player;
    public ItemManager itemManager;
    // Update is called once per frame

    private void Start()
    {
    }
    void Update () {
        Vector3 newpos= new Vector3(Mathf.RoundToInt(player.GetComponent<Transform>().position.x - 1.5f * itemManager.items[0, itemManager.activeSlot]), Mathf.RoundToInt(player.GetComponent<Transform>().position.y - 1.5f * itemManager.items[0, itemManager.activeSlot]), 0);
        transform.position = newpos;
        if (itemManager.activeBar == 0 && itemManager.activeSlot < 2)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        transform.localScale = new Vector3Int(3, 3, 0) * itemManager.items[0,itemManager.activeSlot]; 
	}
}
