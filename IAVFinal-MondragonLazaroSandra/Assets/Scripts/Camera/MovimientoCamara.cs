using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    void Update()
    {
        int deltaX = 0;
        int deltaY = 0;
        if (Input.GetKeyDown(KeyCode.W)) deltaX = -1;
        if (Input.GetKeyDown(KeyCode.S)) deltaX = 1;
        if (Input.GetKeyDown(KeyCode.A)) deltaY = -1;
        if (Input.GetKeyDown(KeyCode.D)) deltaY = 1;

        Vector3 dir = new Vector3(deltaX, 0, deltaY);
        transform.position += dir;
    }
}
