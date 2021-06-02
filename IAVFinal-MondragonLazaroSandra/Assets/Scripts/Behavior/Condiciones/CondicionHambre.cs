using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class CondicionHambre : Conditional
{
    Player player;
    Vista vista;

    public override void OnAwake()
    {
        player = gameObject.GetComponent<Player>();
        vista = gameObject.GetComponent<Vista>();

    }
    public override TaskStatus OnUpdate()
    {
        if (player.hambre < 50 && vista.getHambre() != null)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}
public class CondicionDinero : Conditional
{
    Player player;
    Vista vista;

    public override void OnAwake()
    {
        player = gameObject.GetComponent<Player>();
        vista = gameObject.GetComponent<Vista>();

    }
    public override TaskStatus OnUpdate()
    {
        if (vista.getHambre() != null && vista.getPrecioHambre() <= player.dinero)
            return TaskStatus.Failure;

        return TaskStatus.Success;
    }
}
