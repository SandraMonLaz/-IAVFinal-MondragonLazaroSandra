using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordenador : ObjetoIntMultiple
{
    // Start is called before the first frame update
    [SerializeField] double aumentoDiversion = 0.7;
    [SerializeField] float tiempo = 10;
    [SerializeField] Material[] materials;
    [SerializeField] Renderer pc;

    public override void Interactuar()
    {
        base.Interactuar();
        textoBoton.text = "Jugar";
        textoBoton2.text = "Trabajar";

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && activo)
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
            }

            algoUsandose = true;
            Invoke("DejarHacer", tiempo);
        }
    }

    void DejarHacer()
    {
        base.DejarInteractuar();
        pc.material = materials[2];
        if (accion == 2) player.dinero += 20;
    }

}
