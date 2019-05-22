using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    public Unit unitPrefab;
    //job
    //objetos do mapa
    public static MapLoader instance;
    GameObject holder;
    void Awake()
    {
        instance = this;
        holder = new GameObject("Units Holder");
    }
    void Start()
    {
        holder.transform.parent = Board.instance.transform;    
    }

    public void CriaUnidades()
    {
        Unit unit1 = CreateUnit(new Vector3Int(2, 1, 0), "Jogador1");
        Unit unit2 = CreateUnit(new Vector3Int(3, 1, 0), "Inimigo");

        StateMachineController.instance.units.Add(unit1);
        StateMachineController.instance.units.Add(unit2);

        unit1.faction = 0;
        unit2.faction = 1;


    }

    public Unit CreateUnit(Vector3Int pos, string name)
    {
        TileLogic t = Board.GetTile(pos);
        Unit unit = Instantiate(unitPrefab, t.worldPos,
            Quaternion.identity, holder.transform);
        unit.tile = t;
        unit.name = name;
        return unit;
    }
}
