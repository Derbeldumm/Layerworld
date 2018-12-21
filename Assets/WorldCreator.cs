    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldCreator : MonoBehaviour {
    private int breite = 128;
    private int tiefe = 20 ;
    public Tilemap world;
    public  GameObject[] Ressourcen;
    private int[] profile;
    public Tile Dirt;
    public Tile Stone;
    public Tile Erz;
    public GameObject Erde;
    public GameObject Stein;
    public GameObject Metall;
    public GameObject player;
    public GameObject tree;
    public ItemManager itemManager;
    private float time;
    private float RandomTreeTime;
    private int flatness = 5;
    private int upness = 2;
    private int downness = 1;


    // Use this for initialization
    void Start () {
        profile = new int[2 * breite + 1];
        profile[breite] = -3;
        
            int height = -3;
            for (int i = 0; i <= breite; i++)
            {
                GameObject neu = Instantiate(Erde);
                neu.transform.position = new Vector3(i, height, 0);
                neu.GetComponent<Bodenschatz>().welt = world;
                world.SetTile(new Vector3Int(i,height,0), Dirt);
                int change = 0;
                int rand = Random.Range(0, flatness);
                if (rand > flatness-upness)
                {
                    change = 1;
                    downness=1;
                    upness++;
                    flatness = 5;
                }
                else
                {
                    if (rand < downness)
                    {
                        change = -1;
                        downness++;
                        upness = 2;
                        flatness = 5;
                    }
                    else
                    {
                        downness=1;
                        upness = 2;
                        flatness++;
                    }
                }           
                profile[i] = height;
                height += change;
                if (flatness > 15 || upness > 7 || downness > 6)
                {
                    downness = 1;
                    upness = 2;
                    flatness = 5;
                }
            }
            
        for(int place = 0;place <= breite; place++)
        {
            for (int h = -tiefe+profile[place];h<profile[place]; h++)
            {
                if (Random.Range(0,h+tiefe+5) == 1)
                {
                    GameObject neu = Instantiate(Metall);
                    neu.transform.position = new Vector3Int(place, h, 0);
                    neu.GetComponent<Bodenschatz>().welt = world;
                    world.SetTile(new Vector3Int(place, h, 0), Erz);
                }
                else
                {
                    GameObject neu = Instantiate(Stein);
                    neu.transform.position = new Vector3Int(place, h, 0);
                    neu.GetComponent<Bodenschatz>().welt = world;
                    world.SetTile(new Vector3Int(place, h, 0), Stone);
                }
                
            }
        }

        Vector3 plapos = player.transform.position;
        plapos.x = breite / 2;
        plapos.y = profile[breite / 2] + 4;
        player.transform.position = plapos;

        for (int p = 0; p<10;p++)
        {
            PlantRandom();
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (time > RandomTreeTime)
        {
            PlantRandom();
            RandomTreeTime = Random.Range(10,20);
        }
	}

    bool PlantRandom()
    {
        int x = Random.Range(0, breite);
        int y = profile[x] + 1;
        Vector3 position = new Vector3(x, y, 0);
        return Plant(position);
    }
    bool Plant(Vector3 where)
    {
        if (!IstIn(where) && Platz(int.Parse(where.x.ToString())))
        {
            GameObject baum = Instantiate(tree);
            baum.transform.position = where;    
            itemManager.trees.Add(where);
            itemManager.trees.Add( where + new Vector3(1,0,0));
            itemManager.trees.Add(where + new Vector3(-1, 0, 0));
            return true;
        }
        else
        {
            return false;
        }
    }

    bool Platz(int xpos)
    {
        if (xpos < breite && xpos > 1)
        {
            return profile[xpos] == profile[xpos + 1] && profile[xpos] == profile[xpos - 1];
        }
        else
        {
            return false;
        }
    }

    bool IstIn(Vector3 was)
    {
        for (int a = 0; a< itemManager.trees.Count; a++)
        {
            if (itemManager.trees[a] == was)
            {
                return true;
            }
        }
        return false;
    }
}
