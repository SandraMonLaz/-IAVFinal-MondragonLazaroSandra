using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

/// <summary>
/// Si la stat de diversion esta por debajo de 40
/// </summary>
public class CondicionDiversion : Conditional
{
    Player player;
    Vista vista;

    public override void OnAwake()
    {
        vista = gameObject.GetComponent<Vista>();
        player = gameObject.GetComponent<Player>();
    }
    public override TaskStatus OnUpdate()
    {
        if (player.diversión < 40 && vista.getDiversion() != null)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}
/// <summary>
/// Si existe algún objeto de diversion
/// </summary>
public class CondicionDiversionNormal : Conditional
{
    Vista vista;

    public override void OnAwake()
    {
        vista = gameObject.GetComponent<Vista>();
    }
    public override TaskStatus OnUpdate()
    {
        if (vista.getDiversion() != null)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}
