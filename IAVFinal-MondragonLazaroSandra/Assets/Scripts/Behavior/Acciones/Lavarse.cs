using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace BehaviorDesigner.Runtime.Tasks
{
    public class Lavarse : Mover
    {
        public override void OnStart()
        {
            base.OnStart();
            navMesh.destination = vista.getHigiene().transform.position;
            vista.getHigiene().SetActivo(true);
        }
    }
}
