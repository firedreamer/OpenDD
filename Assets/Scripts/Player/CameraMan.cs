using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMan : MonoBehaviour
{
    public Transform targetTransform;
    public Transform cameraPivot;
    public Transform cameraTransform;
    public LayerMask collisionLayers;
    public float collisionRadius = 0.2f;
    private float defaultPosition;
    public float followSpeed = 0.2f;
    public float pushOffset  = 0.2f;
    public float minPushOffset  = 0.2f;
    public float lookAngle, pivotAngle;
    public float cameraLookSpeed, cameraPivotSpeed;
    public float minPivot =-35f, maxPivot = 35f;
    private Vector3 cameraFollowVelocity = Vector3.zero;
    private Vector3 cameraVectorPosition;
    private InputManager inputManager;

    private void Awake() 
    {
        targetTransform = FindObjectOfType<PlayerManager>().transform;    
        inputManager = FindObjectOfType<InputManager>();    
        cameraTransform = Camera.main.transform;
        defaultPosition = cameraTransform.localPosition.z;
    }

    public void UniversalCameraHandler()
    {
        RotateCamera();
        FollowTarget();       
        HandleCameraCollisions(); 
    }
    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, followSpeed);
        transform.position = targetPosition;
    }
    private void RotateCamera()
    {
        lookAngle = lookAngle + (inputManager.cameraX * cameraLookSpeed);
        pivotAngle = pivotAngle - (inputManager.cameraY * cameraPivotSpeed);
        pivotAngle = Mathf.Clamp(pivotAngle, minPivot, maxPivot);        

        Vector3 rotation = Vector3.zero;
        rotation.y = lookAngle;
        Quaternion targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;
    }

    private void HandleCameraCollisions()
    {
        float targetPosition = defaultPosition;
        RaycastHit hit;
        Vector3 direction = cameraTransform.position - cameraPivot.position;
        direction.Normalize();
        if(Physics.SphereCast(cameraPivot.transform.position, collisionRadius, direction, out hit, Mathf.Abs(targetPosition), collisionLayers))
        {
            float distance = Vector3.Distance(cameraPivot.position, hit.point);
            targetPosition = targetPosition + (distance - pushOffset);
        }
        if(Mathf.Abs(targetPosition) < minPushOffset)
        {
            targetPosition = targetPosition + minPushOffset;
        }

        cameraVectorPosition.z=Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
        cameraTransform.localPosition = cameraVectorPosition;
    }
}
