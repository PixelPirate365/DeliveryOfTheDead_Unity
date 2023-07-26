using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject target; 

    [SerializeField]
    private float distance = 20f; 

    private void LateUpdate() {
        Vector3 position = target.transform.position;
        position.z -= distance; 
        transform.position = position;
    }
}
