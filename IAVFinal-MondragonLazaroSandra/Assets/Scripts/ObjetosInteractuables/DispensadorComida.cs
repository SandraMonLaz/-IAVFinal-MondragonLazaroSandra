using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DispensadorComida : ObjetoInteractuable
{
    [SerializeField] GameObject textoAdvertencia;
    public int gasto = 10;
    public double aumentoHambre = 0.2;

    Transform puerta;
    protected float tiempo = 4;
    protected string texto;

    void Start()
    {
        puerta = GameObject.Find("puerta").transform;
        texto = "Comer preparados alimenticios";
    }
    public override void Interactuar() 
    {
        textoBoton.text = texto;
        if(player.dinero >= gasto)
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

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Player" && activo && !algoUsandose)
        {
            player.estado = Player.Estado.comer;
            player.aumentoHambre = aumentoHambre;
            player.dinero -= gasto;
            algoUsandose = true;


            puerta.Rotate(new Vector3(0, 0, 270));
            Invoke("DejarComer", tiempo);
        }
    }

    void DejarComer()
    {
        base.DejarInteractuar();
        puerta.Rotate(new Vector3(0, 0, -270));
    }

    void DesactivarTexto()
    {
        textoAdvertencia.gameObject.SetActive(false);
    }
}
