using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dormir : ObjetoInteractuable
{
    [SerializeField] double aumentoSueño = 0.3;     //aumento de la constante vital de sueño por tick
    [SerializeField] float tiempoSueño = 20;        //tiempo que dura la accion

    /// <summary>
    /// Modifica el texto del boton y su callback
    /// </summary>
    public override void Interactuar()
    {
        base.Interactuar();
        textoBoton.text = "Dormir";

        boton.onClick.AddListener(delegate { VeAlDestino(); });
        boton.SendMessage("VeAlDestino", SendMessageOptions.DontRequireReceiver);
    }
    /// <summary>
    /// En caso de poder usarse usa la cama
    /// </summary>
    /// <param name="other"></param>
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
    /// <summary>
    /// Informa a la IA del objeto clicado
    /// </summary>
    public override void ModificarObjetoIA()
    {
        vistaPlayer.setSueño(this);
    }
}
