using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSPlayerCamera : MonoBehaviour
{
    public Transform objectToFollow;
    [SerializeField]
    private float followSpeed = 10f;
    [SerializeField]
    private float mousesensitivity = 90f;
    [SerializeField]
    private float scrollSensitivity = 10f;
    [SerializeField]
    private float clampAngle = 70f;

    private float rotX;
    private float rotY;

    public Transform mainCamera;
    public Vector3 dir;
    public Vector3 rayDir;
    public float dist;

    [SerializeField]
    private float minDist = 1f;
    [SerializeField]
    private float maxDist = 2f;
    [SerializeField]
    private float smoothness = 10;

    public void Start()
    {
        this.rotX = this.gameObject.transform.localRotation.eulerAngles.x;
        this.rotY = this.gameObject.transform.localRotation.eulerAngles.y;

        this.dir = this.mainCamera.localPosition.normalized;
        this.dist = this.mainCamera.localPosition.magnitude;
    }

    private void Update()
    {
    // Rotation Section
        //Get Input
        this.rotX += -(Input.GetAxis("Mouse Y")) * this.mousesensitivity + Time.deltaTime;
        this.rotY += Input.GetAxis("Mouse X") * this.mousesensitivity + Time.deltaTime;
        
        //Caculate Rotation
        this.rotX = Mathf.Clamp(this.rotX, -this.clampAngle, this.clampAngle);
        Quaternion rot = Quaternion.Euler(this.rotX, this.rotY, 0);
        this.gameObject.transform.rotation = rot;


        // 마우스 휠로 카메라 거리를 조절합니다.
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        this.dist -= mouseScroll * this.scrollSensitivity;
        this.dist = Mathf.Clamp(this.dist, minDist, maxDist);
    }

    private void LateUpdate()
    {
        this.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.objectToFollow.position, this.followSpeed * Time.deltaTime);

        // 카메라와 플레이어 사이의 물체를 감지합니다.
        this.rayDir = this.gameObject.transform.TransformPoint(this.dir * this.maxDist);
        RaycastHit hit;
        if (Physics.Linecast(this.gameObject.transform.position, this.rayDir, out hit))
        {
            this.dist = Mathf.Clamp(hit.distance, this.minDist, this.maxDist);
            //Debug.Log($"물체감지 {hit.distance}");
        }

        this.mainCamera.localPosition = Vector3.Lerp(this.mainCamera.localPosition, this.dir * this.dist, Time.deltaTime * this.smoothness);
    }
}
