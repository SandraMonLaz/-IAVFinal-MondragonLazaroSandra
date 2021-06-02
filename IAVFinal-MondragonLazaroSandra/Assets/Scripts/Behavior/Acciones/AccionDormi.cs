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
    }
}
