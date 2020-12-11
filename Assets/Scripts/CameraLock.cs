using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public Transform target;

    private void LateUpdate()
    {
        transform.position = target.position;
    }

}
