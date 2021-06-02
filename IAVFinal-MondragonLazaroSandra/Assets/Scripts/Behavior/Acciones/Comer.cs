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

namespace BehaviorDesigner.Runtime.Tasks
{
    public class Trabajar : Mover
    {
        public override void OnStart()
        {
            base.OnStart();
            navMesh.destination = vista.getOrdenador().transform.position;
            vista.getOrdenador().SetActivo(true);
            vista.getOrdenador().accion = 2;
        }
    }
}
