using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private FieldOfView fov;

    private void Update()
    {
        
        Vector3 targetPosition = Utils.GetMouseWorldPosition();
        Vector3 aimDir = (targetPosition - transform.position).normalized;
        aimDir.z += 90;
        
        fov.SetOrigin(transform.position);
        fov.SetAimDirection(aimDir);
    }
}
