using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSlope : MonoBehaviour
{
    public float distance = 1;
    public LayerMask hitMask;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position+new Vector3(0,0.5f,0), transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction*distance, Color.red);
        if(Physics.Raycast(ray, out hit, distance, hitMask))
        {
            Debug.DrawRay(hit.point, hit.normal*2f, Color.blue);
            float angle = Vector3.Angle(hit.normal, -transform.forward);

            if(angle<150)
            {
                transform.Translate(Vector3.back * Time.deltaTime);
            }

        }
    }
}
