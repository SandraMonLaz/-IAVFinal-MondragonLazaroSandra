using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoHigiene : ObjetoInteractuable
{
    [SerializeField] double aumentoHigiene = 2;
    [SerializeField] float tiempo = 5;
    [SerializeField] string texto = "Lavarse manos";


        public override void Interactuar()
    {
        base.Interactuar();
        textoBoton.text = texto;

        boton.onClick.AddListener(delegate { VeAlDestino(); });
        boton.SendMessage("VeAlDestino", SendMessageOptions.DontRequireReceiver);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && activo && !algoUsandose)
        {
            player.estado = Player.Estado.lavar;
            player.aumentoHigiene = aumentoHigiene;
            algoUsandose = true;

            Invoke("DejarInteractuar", tiempo);
        }
    }
}
