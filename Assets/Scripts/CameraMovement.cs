using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    void Update()
    {
        /*A harfi ile kamera sola doner.*/
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0f, -0.5f, 0f));
        }
        /*D harfi ile kamera sola doner.*/
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0f, 0.5f, 0f));
        }

    }
}
