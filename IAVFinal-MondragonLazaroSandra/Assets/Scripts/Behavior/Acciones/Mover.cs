using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace BehaviorDesigner.Runtime.Tasks
{
    /// <summary>
    /// Mueve al agente hacia un destino dado cambiando el estado de este.
    /// </summary>
    public class Mover : Action
    {
        protected Vista vista;              //vista del agente, donde se encuentran los objetos que va a usar
        protected NavMeshAgent navMesh;     //navMesh del agente
        protected Player player;            //player, stats...
        public override void OnAwake()
        {
            vista = GetComponent<Vista>();
            navMesh = GetComponent<NavMeshAgent>();
            player = GetComponent<Player>();
        }
        /// <summary>
        /// Cuando empieza la acciónd de mover pasanmos al estado de andar
        /// </summary>
        public override void OnStart()
        {
            player.estado = Player.Estado.andar;
        }
        /// <summary>
        /// Miramos si ha llegado a su destino 
        /// </summary>
        /// <returns></returns>
        public override TaskStatus OnUpdate()
        {
            float distancia = (navMesh.destination - player.transform.position).magnitude;
            if (distancia > 1)
                return TaskStatus.Failure;
            return TaskStatus.Success;
        }
    }
}

