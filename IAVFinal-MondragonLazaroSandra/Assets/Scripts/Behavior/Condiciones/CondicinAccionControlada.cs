﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class CondicionAccionControlada : Conditional
{
    Player player;

    void start()
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