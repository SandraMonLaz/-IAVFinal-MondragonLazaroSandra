using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ObjetoInteractuable : MonoBehaviour
{
    [SerializeField]
    protected Button boton;             //Botón para que el jugador interactua
    [SerializeField]
    protected Text textoBoton;          //Texto del botón
    [SerializeField]
    protected NavMeshAgent navMesh;     //NavMesh del agente que controla el jugador
    [SerializeField]
    protected Player player;            //Player

    /// <summary>
    /// Método que se llama cuando se clicla al objeto.
    /// </summary>
    public virtual void Interactuar()
    {
        boton.gameObject.SetActive(true);
        Debug.Log(gameObject.name);
    }
    public void VeAlDestino()
    {
        navMesh.destination = transform.position;
        player.estado = Player.Estado.andar;
        boton.gameObject.SetActive(false);
    }
}
