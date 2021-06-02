using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class CondicionHambre : Conditional
{
    Player player;
    void Start()
    {
        player = gameObject.GetComponent<Player>();
    }
    public override TaskStatus OnUpdate()
    {
        if (player.hambre < 50)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}
