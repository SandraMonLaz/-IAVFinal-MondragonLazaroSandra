using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horno : DispensadorComida
{
    [SerializeField] GameObject plane;
    void Start()
    {
        texto = "Preparar comida";
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            player.estado = Player.Estado.comer;
            player.aumentoHambre = aumentoHambre;

            plane.SetActive(true);
            Invoke("DejarComer", 5f);
        }
    }

    void DejarComer()
    {
        player.estado = Player.Estado.idle;
        plane.SetActive(false);
    }

}
