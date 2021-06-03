using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

/// <summary>
/// Si el agente está siendo controlado por el jugador
/// </summary>
public class CondicionAccionControlada : Conditional
{
    Player player;

    public override void OnAwake()
    {
        player = gameObject.GetComponent<Player>();
    }
    public override TaskStatus OnUpdate()
    {
        if (player.accionControlada)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}
/// <summary>
/// Si alguna de las stats está por debajo de 30
/// </summary>
public class CondicionPocoEstado : Conditional
{
    Player player;

    public override void OnAwake()
    {
        player = gameObject.GetComponent<Player>();
    }
    public override TaskStatus OnUpdate()
    {
        if (player.higiene < 30|| player.hambre < 30 || player.diversión < 30 || player.higiene < 30 || player.baño < 30)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}
