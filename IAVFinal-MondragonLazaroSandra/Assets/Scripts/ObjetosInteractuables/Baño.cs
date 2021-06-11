using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baño : ObjetoInteractuable
{
    [SerializeField] double aumentoBaño;    //aumento de la constante vital de baño
    [SerializeField] float tiempo;          //tiempo que realiza la acción

    /// <summary>
    /// Modifica el texto del boton y su callback
    /// </summary>
    public override void Interactuar()
    {
        base.Interactuar();
        textoBoton.text = "Ir al Baño";

        boton.onClick.AddListener(delegate { VeAlDestino(); });
        boton.SendMessage("VeAlDestino", SendMessageOptions.DontRequireReceiver);
    }
    /// <summary>
    /// En caso de poder usarse usa el  baño
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && activo && !algoUsandose)
        {
            player.estado = Player.Estado.baño;
            player.aumentoBaño = aumentoBaño;
            algoUsandose = true;
            //Posicionamiento y rotacion
            player.transform.rotation = Quaternion.Euler(0,32,0);
            Invoke("DejarInteractuar", tiempo);
        }
    }
    /// <summary>
    /// Informa a la IA del objeto clicado
    /// </summary>
    public override void ModificarObjetoIA()
    {
        vistaPlayer.setBaño(this);
    }
}
