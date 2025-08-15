using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTranform : MonoBehaviour
{
    Transform targetTransform;

    public void SetTargetTransform(Transform targetTransform)
    {
        this.targetTransform = targetTransform;
    }

    void LateUpdate()
    {
        if (targetTransform == null)
        {
            return;
        }

        transform.position = targetTransform.position;
        transform.rotation = targetTransform.rotation;
    }
}
