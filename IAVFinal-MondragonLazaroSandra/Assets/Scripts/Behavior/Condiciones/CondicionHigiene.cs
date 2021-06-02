using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;


public class CondicionHigiene : Conditional
{
    Player player;
    void Start()
    {
        player = gameObject.GetComponent<Player>();
    }
    public override TaskStatus OnUpdate()
    {
        if (player.higiene < 50)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}
