using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horno : DispensadorComida
{
    [SerializeField] GameObject plane;
    void Start()
    {
        texto = "Preparar comida";
        gasto = 20;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && activo)
        {
            player.estado = Player.Estado.comer;
            player.aumentoHambre = aumentoHambre;
            player.dinero -= gasto;
            algoUsandose = true;

            plane.SetActive(true);
            Invoke("DejarComer", 5f);
        }
    }

    void DejarComer()
    {
        base.DejarInteractuar();
        plane.SetActive(false);
    }

}
