using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLogic
{
    public Vector3Int pos;
    public Vector3 worldPos;
    public GameObject content;
    public Floor floor;
    public int contentOrder;
    //public TileType tileType;

    public TileLogic() { }
    public TileLogic(Vector3Int cellPoss,Vector3 worldPosition,Floor tempFloor)
    {
        pos = cellPoss;
        worldPos = worldPosition;
        floor = tempFloor;
        contentOrder = tempFloor.contentOrder;


    }
    public static TileLogic Create(Vector3Int cellPoss, Vector3 worldPosition, Floor tempFloor)
    {
        TileLogic tileLogic = new TileLogic(cellPoss, worldPosition, tempFloor);
        return tileLogic;
    }
}
