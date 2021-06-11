using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horno : DispensadorComida
{
    [SerializeField] GameObject plane;  //luz de feedback

    /// <summary>
    /// Inicializacion de varibales
    /// </summary>
    void Start()
    {
        texto = "Preparar comida";
        gasto = 20;
    }
    /// <summary>
    /// En caso de poder usarse va a comer
    /// </summary>
    /// <param name="other"></param>
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
    /// <summary>
    /// Deja de realizar la accion
    /// </summary>
    void DejarComer()
    {
        base.DejarInteractuar();
        plane.SetActive(false);
    }
    /// <summary>
    /// Informa a la IA del objeto clicado
    /// </summary>
    public override void ModificarObjetoIA()
    {
        vistaPlayer.setHambre(this);
    }
}
