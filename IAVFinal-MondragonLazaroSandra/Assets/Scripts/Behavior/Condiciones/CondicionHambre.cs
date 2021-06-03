using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

/// <summary>
/// Si el agente tiene hambre
/// </summary>
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
/// <summary>
/// Si el agente tiene suficiente dinero para comprar comida
/// </summary>
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

        else if (player.hambre < 50)
            return TaskStatus.Success;

        else return TaskStatus.Failure;
    }
}
