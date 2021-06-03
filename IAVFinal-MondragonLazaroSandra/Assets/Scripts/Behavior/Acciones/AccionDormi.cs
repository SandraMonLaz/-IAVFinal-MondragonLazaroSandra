using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace BehaviorDesigner.Runtime.Tasks
{
    /// <summary>
    /// Accion que se realiza cuando se va a dormir
    /// </summary>
    public class AccionDormi : Mover
    {
        public override void OnStart()
        {
            base.OnStart();
            //Ponemos el destino y el objeto activo
            navMesh.destination = vista.getSueño().transform.position;
            vista.getSueño().SetActivo(true);
        }
        public override TaskStatus OnUpdate()
        {
            //Vemos si se ha llegado al destino
            float distancia = (navMesh.destination - player.transform.position).magnitude;
            if (distancia > 3)
                return TaskStatus.Failure;
            return TaskStatus.Success;
        }
    }
    /// <summary>
    /// Accion que realiza cuando una de sus stats está por debajo de 30
    /// </summary>
    public class AccionMover : Mover
    {
        enum estadistica { hambre, higiene, diversion, sueño, baño };
        public override void OnStart()
        {
            base.OnStart();
            double aux = 30;
            estadistica e = estadistica.baño;
            //Miramos cual es la mas baja de todas
            if (player.diversión < aux)
            {
                aux = player.diversión;
                e = estadistica.diversion;
            }
            if (player.hambre < aux)
            {
                aux = player.hambre;
                e = estadistica.hambre;
            }
            if (player.higiene < aux)
            {
                aux = player.higiene;
                e = estadistica.higiene;
            }
            if (player.baño < aux)
            {
                aux = player.baño;
                e = estadistica.baño;
            }
            if (player.sueño < aux)
            {
                aux = player.sueño;
                e = estadistica.sueño;
            }

            //En función de cual se se le manda a un lugar u otro
            if (e == estadistica.diversion)
                MandarALugar(vista.getDiversion());
            if (e == estadistica.hambre)
                MandarALugar(vista.getHambre());
            if (e == estadistica.sueño)
                MandarALugar(vista.getSueño());
            if (e == estadistica.baño)
                MandarALugar(vista.getBaño());
            if (e == estadistica.higiene)
                MandarALugar(vista.getHigiene());
        }
        public override TaskStatus OnUpdate()
        {
            float distancia = (navMesh.destination - player.transform.position).magnitude;
            if (distancia > 3)
                return TaskStatus.Failure;
            return TaskStatus.Success;
        }

        void MandarALugar(ObjetoInteractuable o)
        {
            navMesh.destination = o.transform.position;
            o.SetActivo(true);
        }
    }
}
