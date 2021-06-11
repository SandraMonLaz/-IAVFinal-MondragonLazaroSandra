using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablaEjercicio : ObjetoInteractuable
{
    [SerializeField] double aumentoDiversion = 0.1;     //aumento de diversion por cada tick
    [SerializeField] float tiempoEjercicio = 10;        //tiempo que dura la accion
    /// <summary>
    /// Modifica los textos y callback del boton
    /// </summary>   
    public override void Interactuar()
    {
        base.Interactuar();
        textoBoton.text = "Hacer ejercicio";

        boton.onClick.AddListener(delegate { VeAlDestino(); });
        boton.SendMessage("VeAlDestino", SendMessageOptions.DontRequireReceiver);
    }

    /// <summary>
    /// En caso de poder realiza la accion de realizar ejercicio
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && activo && !algoUsandose)
        {
            player.estado = Player.Estado.ejercicio;
            player.aumentoDiversion = aumentoDiversion;
            algoUsandose = true;

            Invoke("DejarInteractuar", tiempoEjercicio);
        }
    }
    /// <summary>
    /// Informa a la IA del objeto clicado
    /// </summary>
    public override void ModificarObjetoIA()
    {
        vistaPlayer.setDiversion(this);
    }
}
