using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baño : ObjetoInteractuable
{
    [SerializeField] double aumentoBaño;
    [SerializeField] float tiempo;
    public override void Interactuar()
    {
        base.Interactuar();
        textoBoton.text = "Ir al Baño";

        boton.onClick.AddListener(delegate { VeAlDestino(); });
        boton.SendMessage("VeAlDestino", SendMessageOptions.DontRequireReceiver);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && activo)
        {
            player.estado = Player.Estado.baño;
            player.aumentoBaño = aumentoBaño;
            Invoke("DejarInteractuar", tiempo);
            algoUsandose = true;

            //Posicionamiento y rotacion
            player.transform.rotation = Quaternion.Euler(0,32,0);
        }
    }
}
