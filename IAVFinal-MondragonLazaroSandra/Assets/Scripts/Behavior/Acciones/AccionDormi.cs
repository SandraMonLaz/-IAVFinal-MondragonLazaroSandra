using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace BehaviorDesigner.Runtime.Tasks
{
    public class AccionDormi : Mover
    {
        public override void OnStart()
        {
            base.OnStart();
            navMesh.destination = vista.getSueño().transform.position;
            vista.getSueño().SetActivo(true);
        }
        public override TaskStatus OnUpdate()
        {
            float distancia = (navMesh.destination - player.transform.position).magnitude;
            if (distancia > 3)
                return TaskStatus.Failure;
            return TaskStatus.Success;
        }
    }
}
