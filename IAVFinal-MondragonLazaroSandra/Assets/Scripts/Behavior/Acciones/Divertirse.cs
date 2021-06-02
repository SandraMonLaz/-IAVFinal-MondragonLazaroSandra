using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace BehaviorDesigner.Runtime.Tasks
{
    public class Divertirse : Mover
    {
        public override void OnStart()
        {
            base.OnStart();
            navMesh.destination = vista.getDiversion().transform.position;
            vista.getDiversion().SetActivo(true);
        }
    }
}
