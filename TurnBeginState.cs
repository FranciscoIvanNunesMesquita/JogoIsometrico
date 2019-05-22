using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBeginState : State
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(SelecUnit());

    }
    IEnumerator SelecUnit()
    {
        BreakDraw();
        machine.units.Sort((x, y) => x.chargeTime.CompareTo(y.chargeTime));
        Turn.unit = machine.units[0];

        yield return null;
        machine.ChangeTo<ChoseActionState>();
    }
    void BreakDraw()
    {
        for(int i=0; i<machine.units.Count-1; i++)
        {
            if (machine.units[i].chargeTime == machine.units[i + 1].chargeTime)
                machine.units[i + 1].chargeTime += 1;
        }
    }
}
