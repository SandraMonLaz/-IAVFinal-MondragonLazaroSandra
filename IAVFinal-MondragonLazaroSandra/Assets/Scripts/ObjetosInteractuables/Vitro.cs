using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitro : DispensadorComida
{
    void Start()
    {
        texto = "Preparar comida";
        gasto = 20;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && activo && !algoUsandose)
        {
            player.estado = Player.Estado.comer;
            player.aumentoHambre = aumentoHambre;
            player.dinero -= gasto;
            algoUsandose = true;

            Invoke("DejarInteractuar", tiempo);
        }
    }
    public override void ModificarObjetoIA()
    {
        vistaPlayer.setHambre(this);
    }
}
