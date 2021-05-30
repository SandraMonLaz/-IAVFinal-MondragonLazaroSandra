using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispensadorComida : ObjetoInteractuable
{
    public int gasto = 10;
    public double aumentoHambre = 0.2;

    Transform puerta;

    protected string texto;

    void Start()
    {
        puerta = GameObject.Find("puerta").transform;
        texto = "Comer preparados alimenticios";
    }
    public override void Interactuar() 
    {
        base.Interactuar();
        textoBoton.text = texto;
        if(player.dinero > gasto)
        {
            player.dinero -= gasto;
            boton.onClick.AddListener(delegate { VeAlDestino(); });
            boton.SendMessage("VeAlDestino", SendMessageOptions.DontRequireReceiver);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            player.estado = Player.Estado.comer;
            player.aumentoHambre = aumentoHambre;

            puerta.Rotate(new Vector3(0, 0, 270));

            Invoke("DejarComer", 5f);
        }
    }

    void DejarComer()
    {
        player.estado = Player.Estado.idle;
        puerta.Rotate(new Vector3(0, 0, -270));
    }
}
