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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform.gameObject != null)
            {
                ObjetoInteractuable interactuable = hit.transform.GetComponent<ObjetoInteractuable>();
                if(interactuable != null && !interactuable.AlgoUsandose())
                {
                    interactuable.Interactuar();
                }
            }
        }
    }

}
