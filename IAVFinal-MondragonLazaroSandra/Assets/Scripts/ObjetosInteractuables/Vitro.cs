using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitro : DispensadorComida
{
    /// <summary>
    /// Inicializaciond de variables
    /// </summary>
    void Start()
    {
        texto = "Preparar comida";
        gasto = 20;
    }
    /// <summary>
    /// En caso de poder realizar la accion la realiza
    /// </summary>
    /// <param name="other"></param>
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
    /// <summary>
    /// Informa a la IA del objeto clicado
    /// </summary>
    public override void ModificarObjetoIA()
    {
        vistaPlayer.setHambre(this);
    }
}
