using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimBehave : MonoBehaviour {
    public ItemManager itemManager;
    private Vector3 mousePos;
    private bool abbauen;
    public Ressource coll;

    private void Start()
    {

    }

    void Update () {
        mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector3 MouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 newpos= new Vector3(Mathf.RoundToInt(MouseWorldPos.x-0.5f), Mathf.RoundToInt(MouseWorldPos.y-0.5f), 0);
        transform.position = newpos;

        bool aktiv = itemManager.activeBar == 0 && itemManager.activeSlot < 2;
        GetComponent<SpriteRenderer>().enabled = aktiv;
        bool harvest = aktiv && Input.GetButton("Fire1");
        GetComponent<BoxCollider2D>().enabled = harvest;

        if (abbauen)
        {
             coll.give(4, 2, Time.deltaTime, itemManager, coll.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.layer != 10)
            Physics2D.IgnoreLayerCollision(0, collision.gameObject.layer);
        else
        {
            coll = collision.gameObject.GetComponent<Ressource>();
            abbauen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        abbauen = false;
    }
}
