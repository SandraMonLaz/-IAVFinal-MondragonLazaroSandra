using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraClick : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            //Miramos la posición del mouse con respecto a la pantalla, de ahí lanzamos un ray
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Si el rayo colisiona con algo
            if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform.gameObject != null)
            {
                //Si el objeto es interactuable y no está siendo usado
                ObjetoInteractuable interactuable = hit.transform.GetComponent<ObjetoInteractuable>();
                if(interactuable != null && !interactuable.AlgoUsandose())
                {
                    interactuable.Interactuar();
                }
            }
        }
    }

}
