using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Camera playerCarCamera;
    void Update()
    {

        Vector3 trackCamera = transform.TransformDirection(new Vector3(0, 5f, -10f));

        playerCarCamera.transform.position = transform.position + trackCamera;
        playerCarCamera.transform.LookAt(transform.position + Vector3.up * 3.5f);

    }

}
