using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace BehaviorDesigner.Runtime.Tasks
{
    public class Mover : Action
    {
        protected Vista vista;
        protected NavMeshAgent navMesh;
        protected Player player;
        public override void OnAwake()
        {
            vista = GetComponent<Vista>();
            navMesh = GetComponent<NavMeshAgent>();
            player = GetComponent<Player>();
        }
        public override void OnStart()
        {
            player.estado = Player.Estado.andar;
        }
        public override TaskStatus OnUpdate()
        {
            float distancia = (navMesh.destination - player.transform.position).magnitude;
            if (distancia > 2)
                return TaskStatus.Failure;
            return TaskStatus.Success;
        }
    }
}

