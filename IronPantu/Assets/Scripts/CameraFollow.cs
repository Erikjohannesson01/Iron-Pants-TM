using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float lerpSpeed = 0.125f;


    private void LateUpdate()
    {

        Vector3 targetPos = new Vector3(target.position.x, target.position.y, -10);
        Vector3 lerpPos = Vector3.Lerp(transform.position, targetPos, lerpSpeed);
        transform.position = lerpPos;


    }
}
