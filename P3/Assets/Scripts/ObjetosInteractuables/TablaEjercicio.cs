using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablaEjercicio : ObjetoInteractuable
{
    [SerializeField] double aumentoDiversion = 0.1;
    [SerializeField] float tiempoEjercicio = 10;
    public override void Interactuar()
    {
        base.Interactuar();
        textoBoton.text = "Hacer ejercicio";

        boton.onClick.AddListener(delegate { VeAlDestino(); });
        boton.SendMessage("VeAlDestino", SendMessageOptions.DontRequireReceiver);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && activo)
        {
            player.estado = Player.Estado.ejercicio;
            player.aumentoDiversion = aumentoDiversion;
            algoUsandose = true;

            Invoke("DejarInteractuar", tiempoEjercicio);
        }
    }
}
