using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

/// <summary>
/// Si la stat del baño esta por debajo de 50
/// </summary>
public class CondicionBaño : Conditional
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
        if (player.baño < 50 && vista.getBaño() != null)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}
