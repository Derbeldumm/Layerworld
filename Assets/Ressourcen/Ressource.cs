using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressource : MonoBehaviour {

    public int art;
    public int Wiederstand;
    public float CollectTime;
    public int bar;
	
    public void give(int effiziens, int Schnelligkeit, float time, ItemManager itemManager, GameObject du)
    {
        print(du.name);
        if (CollectTime > 1f)
        {
            CollectTime -= 1f;
            itemManager.items[bar, art] += effiziens;
            Wiederstand -= Schnelligkeit;
        }
        CollectTime += time;
        if (Wiederstand <= 0)
        {
            Destroy(du);
        }
    }

   
}
