using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace BehaviorDesigner.Runtime.Tasks
{
    public class Comer : Mover
    {
        public override void OnStart()
        {
            base.OnStart();
            navMesh.destination = vista.getHambre().transform.position;
            vista.getHambre().SetActivo(true);
        }
    }
}
