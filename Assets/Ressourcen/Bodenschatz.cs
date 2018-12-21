using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bodenschatz : Ressource {
    public Tilemap welt;

    public void OnDestroy()
    {
        Vector3Int pos = new Vector3Int(int.Parse(transform.position.x.ToString()), int.Parse(transform.position.y.ToString()), 0);
        welt.SetTile(pos,new Tile() as Tile);
    }
}
