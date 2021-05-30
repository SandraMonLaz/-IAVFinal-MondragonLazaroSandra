using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nevera : ObjetoInteractuable
{
    public int gasto = 10;
    public double aumentoHambre = 0.2;
    public override void Interactuar() 
    {
        boton.gameObject.SetActive(true);
        textoBoton.text = "Comer preparados alimenticios";
        if(player.dinero > gasto)
        {
            player.dinero -= gasto;
            boton.onClick.AddListener(delegate { VeAlDestino(); });
            boton.SendMessage("VeAlDestino", SendMessageOptions.DontRequireReceiver);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("HOAL");
        if(other.gameObject.name == "Player")
        {
            player.estado = Player.Estado.comer;
            player.aumentoHambre = aumentoHambre;

            Invoke("DejarComer", 5f);
        }
    }

    public void DejarComer()
    {
        player.estado = Player.Estado.idle;
    }
}
