using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [HideInInspector]
    public Stats stats;
    // Start is called before the first frame update
    void Awake()
    {
        stats = GetComponentInChildren<Stats>();
    }


}
