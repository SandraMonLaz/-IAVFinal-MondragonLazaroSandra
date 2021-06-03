using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Accion de ir al baño
/// </summary>
namespace BehaviorDesigner.Runtime.Tasks
{
    public class IrAlBaño : Mover
    {
        public override void OnStart()
        {
            base.OnStart();
            navMesh.destination = vista.getBaño().transform.position;
            vista.getBaño().SetActivo(true);
        }
    }
}
