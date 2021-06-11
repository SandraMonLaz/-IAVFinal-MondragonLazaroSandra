using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordenador : ObjetoIntMultiple
{
    [SerializeField] double aumentoDiversion = 0.7;     //aumento de la diversion en cada tick
    [SerializeField] float tiempo = 10;                 //tiempo que dura la accion
    [SerializeField] Material[] materials;              //materiales para el feedback de la pantalla del ordenador
    [SerializeField] Renderer pc;                       //componente de renderer del pc

    /// <summary>
    /// Modifica el texto de los botones
    /// </summary
    public override void Interactuar()
    {
        base.Interactuar();
        textoBoton.text = "Jugar";
        textoBoton2.text = "Trabajar";

    }
    /// <summary>
    /// Realiza la accion en caso de poder hacerlo. Dependiendo del botón cliclado realizará la accion de 
    /// trabajar o la de jugar en el ordenador
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && activo && !algoUsandose)
        {
            if(accion == 1)
            {
                player.estado = Player.Estado.jugarOrdenador;
                player.aumentoDiversion = aumentoDiversion;
                pc.material = materials[0];
            }
            else
            {
                player.estado = Player.Estado.trabajar;
                pc.material = materials[1];
                Debug.Log("trabajar");
            }

            algoUsandose = true;
            Invoke("DejarHacer", tiempo);
        }
    }
    /// <summary>
    /// Deja de realizar la accion. En caso de que su acción fuera trabajar, aumenta el dinero
    /// del agente
    /// </summary>
    void DejarHacer()
    {
        base.DejarInteractuar();
        pc.material = materials[2];
        if (accion == 2) player.dinero += 20;
    }
    /// <summary>
    /// Informa a la IA del objeto clicado
    /// </summary>
    public override void ModificarObjetoIA()
    {
        vistaPlayer.setOrdenador(this);
    }
}
