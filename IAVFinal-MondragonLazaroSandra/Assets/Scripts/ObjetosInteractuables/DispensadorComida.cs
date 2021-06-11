using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DispensadorComida : ObjetoInteractuable
{
    [SerializeField] GameObject textoAdvertencia;   //texto de advertencia en caso de carecer de dinero
    public int gasto = 10;                          //precio a pagar por la comida
    public double aumentoHambre = 0.2;              //aumento del hambre por tick

    Transform puerta;                               //puerta de la never
    protected float tiempo = 4;                     //tiempo que dura la accion
    protected string texto;                         //texto que aparece en el boton

    /// <summary>
    /// Inicializacion de variables
    /// </summary>
    void Start()
    {
        puerta = GameObject.Find("puerta").transform;
        texto = "Comer preparados alimenticios";
    }
    /// <summary>
    /// En caso de tener dinero se actualiza el callback del botón. En caso de no tenerlo
    /// se emite el mensaje de feedback
    /// </summary>
    public override void Interactuar() 
    {
        textoBoton.text = texto;
        if(player.dinero >= gasto)  //si tenemos dinero suficiente
        {
            base.Interactuar();
            boton.onClick.AddListener(delegate { VeAlDestino(); });
            boton.SendMessage("VeAlDestino", SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            boton.gameObject.SetActive(false);
            textoAdvertencia.gameObject.SetActive(true);
            Invoke("DesactivarTexto", 2);
        }
    }

    /// <summary>
    /// Si no esta siendo usado alimentamos al player
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Player" && activo && !algoUsandose)
        {
            player.estado = Player.Estado.comer;
            player.aumentoHambre = aumentoHambre;
            player.dinero -= gasto;
            algoUsandose = true;

            //feedvack de la puerta
            puerta.Rotate(new Vector3(0, 0, 270));
            Invoke("DejarComer", tiempo);
        }
    }
    /// <summary>
    /// Deja de realizar la accion de comer
    /// </summary>
    void DejarComer()
    {
        base.DejarInteractuar();
        puerta.Rotate(new Vector3(0, 0, -270));
    }
    /// <summary>
    /// Deja de emitir el mensaje de advertencia
    /// </summary>
    void DesactivarTexto()
    {
        textoAdvertencia.gameObject.SetActive(false);
    }
    /// <summary>
    /// Informa a la IA del objeto clicado
    /// </summary>
    public override void ModificarObjetoIA()
    {
        vistaPlayer.setHambre(this);
    }
}
