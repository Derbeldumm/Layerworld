using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

    public int[,] items;
    public int activeBar;
    [SerializeField]public Sprite[] materials = new Sprite[8];
    [SerializeField] public Sprite[] build1 = new Sprite[8];
    [SerializeField] public Sprite[] build2 = new Sprite[8];
    [SerializeField] public Sprite[] fighting = new Sprite[8];
    public Sprite[][] bgis;
    public int activeSlot;
    public int changes = 0;
    public List<Vector3> trees;

    void Start()
    {
        items = new int[,] {{ 2,3,5,0,0,0,0,0},{ 0,0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0,0},{ 0,0,0,0,0,0,0,0} };
        activeSlot = 0;
        activeBar = 0;
        bgis = new Sprite[4][];
        bgis[0] = materials;
        bgis[1] = build1;
        bgis[2] = build2;
        bgis[3] = fighting;

    }

    void Update () {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Input.GetButton("inv"))
            {
                activeBar = activeBar+5;
                activeBar = activeBar % 4;
                changes += 8;
            }
            else
            {
                activeSlot = activeSlot+9;
                activeSlot = activeSlot % 8;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Input.GetButton("inv"))
            {
                activeBar = activeBar+3;
                activeBar = activeBar % 4;
                changes += 8;
            }
            else
            {
                activeSlot = activeSlot+7;
                activeSlot = activeSlot % 8;
            }
        }
	}

    public void add(string str,int mass)
    {
        switch (str)
        {
            case "wood":
                items[0, 3] += mass;
                break;
            case "stone":
                items[0, 4] += mass;
                break;
            case "erz":
                items[0, 5] += mass;
                break;
            case "dust":
                items[0, 6] += mass;
                break;
            case "breter":
                items[0, 7] += mass;
                break;
            case "eisen":
                items[0, 8] += mass;
                break;
        }
    }
}
