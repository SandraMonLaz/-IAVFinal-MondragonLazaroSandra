using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class CondicionSueño : Conditional
{
    Player player;
    void Start()
    {
        player = gameObject.GetComponent<Player>();
    }
    public override TaskStatus OnUpdate()
    {
        if (player.sueño < 30)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}
