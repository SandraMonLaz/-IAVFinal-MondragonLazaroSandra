using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dormir : ObjetoInteractuable
{
    [SerializeField] double aumentoSueño = 0.3;
    [SerializeField] float tiempoSueño = 20;

    public override void Interactuar()
    {
        base.Interactuar();
        textoBoton.text = "Dormir";

        boton.onClick.AddListener(delegate { VeAlDestino(); });
        boton.SendMessage("VeAlDestino", SendMessageOptions.DontRequireReceiver);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && activo && !algoUsandose)
        {
            player.estado = Player.Estado.dormir;
            player.aumentoSueño = aumentoSueño;

            player.transform.rotation = Quaternion.Euler(0, -30, 0);
            algoUsandose = true;

            Invoke("DejarInteractuar", tiempoSueño);
        }
    }
    public override void ModificarObjetoIA()
    {
        vistaPlayer.setSueño(this);
    }
}
