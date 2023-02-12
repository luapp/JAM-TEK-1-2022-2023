using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject superman;

    void Update()
    {
        transform.position = superman.transform.position + new Vector3(0.0f, 1.5f, -7.5f);
    }
}
