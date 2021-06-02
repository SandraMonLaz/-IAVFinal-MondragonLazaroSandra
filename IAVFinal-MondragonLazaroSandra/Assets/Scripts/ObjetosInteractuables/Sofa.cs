using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sofa : ObjetoInteractuable
{
    [SerializeField] Material[] materials;    //Dos materiales
    [SerializeField] Renderer tv;    //Dos materiales
    [SerializeField] double aumentoDiversion;    
    [SerializeField] float tiempo;
    public override void Interactuar()
    {
        base.Interactuar();
        textoBoton.text = "Ver la Tele";

        boton.onClick.AddListener(delegate { VeAlDestino(); });
        boton.SendMessage("VeAlDestino", SendMessageOptions.DontRequireReceiver);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && activo)
        {
            player.estado = Player.Estado.verTele;
            player.aumentoDiversion = aumentoDiversion;
            tv.material = materials[1];
            algoUsandose = true;
            //Posicionamiento y rotacion
            player.transform.LookAt(tv.transform, Vector3.up);
            Invoke("DejarDeVer", tiempo);
        }
    }

    void DejarDeVer()
    {
        base.DejarInteractuar();
        tv.material = materials[0];
    }
}
