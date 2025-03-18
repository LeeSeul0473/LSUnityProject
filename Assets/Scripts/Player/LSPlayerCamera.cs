using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSPlayerCamera : MonoBehaviour
{
    public Transform transCamPoint;
    [SerializeField]
    private float followSpeed = 10f;
    [SerializeField]
    private float sensitivity = 100f;
    [SerializeField]
    private float scrollSensitivity = 10f;
    [SerializeField]
    private float clampAngle = 70f;

    private float rotX;
    private float rotY;

    public Transform transCamera;
    private Vector3 dir;
    private Vector3 Raydir;
    private float dist;

    [SerializeField]
    private float minDist;
    [SerializeField]
    private float maxDist;
    [SerializeField]
    private float smoothness = 10;

    public void Init()
    {
        this.rotX = this.gameObject.transform.localRotation.eulerAngles.x;
        this.rotY = this.gameObject.transform.localRotation.eulerAngles.y;

        this.dir = this.transCamera.localPosition.normalized;
        this.dist = this.transCamera.localPosition.magnitude;
    }

    private void Update()
    {
        // y축을 기준으로 회전
        this.rotX += -(Input.GetAxis("Mouse Y")) * this.sensitivity + Time.deltaTime;
        // x축을 기준으로 회전
        this.rotY += Input.GetAxis("Mouse X") * this.sensitivity + Time.deltaTime;

        // 마우스 휠로 카메라 거리를 조절합니다.
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        this.dist -= mouseScroll * this.scrollSensitivity;
        this.dist = Mathf.Clamp(this.dist, minDist, maxDist);

        this.rotX = Mathf.Clamp(this.rotX, -this.clampAngle, this.clampAngle);
        Quaternion rot = Quaternion.Euler(this.rotX, this.rotY, 0);
        this.gameObject.transform.rotation = rot;
    }

    private void LateUpdate()
    {
        this.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.transCamPoint.position, this.followSpeed * Time.deltaTime);

        // 카메라와 플레이어 사이의 물체를 감지합니다.
        this.Raydir = this.gameObject.transform.TransformPoint(this.dir * this.maxDist);
        RaycastHit hit;
        if (Physics.Linecast(this.gameObject.transform.position, this.Raydir, out hit))
        {
            this.dist = Mathf.Clamp(hit.distance, this.minDist, this.maxDist);
        }

        this.transCamera.localPosition = Vector3.Lerp(this.transCamera.localPosition, this.dir * this.dist, Time.deltaTime * this.smoothness);
    }
}
