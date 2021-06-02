﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;


public class CondicionHigiene : Conditional
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
        if (player.higiene < 50 && vista.getHigiene() != null)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}
