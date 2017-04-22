using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TileSetType
{
    Node,
    Start,
}


[System.Serializable]
public class TileSetData
{

    public Vector2 pos;
    public TileSetType type;
    public string name; 




}
