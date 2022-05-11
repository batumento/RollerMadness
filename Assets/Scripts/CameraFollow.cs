
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float CameraFollowTime = 5f;

    private Vector3 offsetVector;

    // Start is called before the first frame update
    void Start()
    {
        offsetVector = CalculateOffsett(target);
    }

   

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveTheCamera();
    }

    private void MoveTheCamera()
    {
        if(target != null)
        {
            Vector3 targetToMove = target.position + offsetVector;
            transform.position = Vector3.Lerp(transform.position, targetToMove, CameraFollowTime * Time.deltaTime);
            transform.LookAt(target.transform.position);
        }
    }

    private Vector3 CalculateOffsett(Transform newTarget)
    {
        offsetVector = transform.position - newTarget.position;
        return offsetVector;
    }

}
