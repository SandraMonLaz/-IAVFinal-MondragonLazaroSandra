﻿using System.Collections;
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
    void OnTriggerStay(Collider other)
    {
        Debug.Log(activo);
        if (other.gameObject.name == "Player" && activo && !algoUsandose)
        {
            player.estado = Player.Estado.comer;
            player.aumentoHambre = aumentoHambre;
            player.dinero -= gasto;
            algoUsandose = true;

            plane.SetActive(true);
            Invoke("DejarComer", tiempo);
        }
    }

    void DejarComer()
    {
        base.DejarInteractuar();
        plane.SetActive(false);
    }

}
