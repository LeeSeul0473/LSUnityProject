using UnityEngine;

public class LSPlayerCamera
{
    [SerializeField] Transform target; // 카메라가 따라갈 대상 (캐릭터)
    [SerializeField] private float minDistance = 1f; // 카메라 최소 거리
    [SerializeField] private float maxDistance = 5f; // 카메라 최대 거리
    [SerializeField] private float cameraDist = 3f; // 현재 카메라 거리 & 초기 거리

    public float sensitivity = 100f; // 마우스 감도
    public float minXRot = -50f; // 카메라의 최소 X축 회전값
    public float maxXRot = 50f; // 카메라의 최대 X축 회전값

    private float rotationX = 0f; // 현재 X축 회전값
    private Vector2 mouseDir; // 현재 마우스 입력값 저장
    private Vector3 cameraDir; // 플레이어 -> 카메라 방향

    // 마우스 입력을 받아 카메라 회전에 반영
    void MouseInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Canceled)
        {
            mouseDir = Vector3.zero;
            return;
        }
        mouseDir = context.ReadValue<Vector2>();
    }

    // 마우스 휠 입력을 받아 카메라 줌 조절
    void MouseWheelInput(InputAction.CallbackContext context)
    {
        float y = context.ReadValue<Vector2>().y;
        cameraDist += Mathf.Clamp(-y, -1f, 1f);
        cameraDist = Mathf.Clamp(cameraDist, minDistance, maxDistance);
    }

    // 카메라 회전
    void MoveCamera()
    {
        transform.position = target.position;
        Vector2 mouseDelta = mouseDir * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseDelta.x);
        rotationX -= mouseDelta.y;
        rotationX = Mathf.Clamp(rotationX, minXRot, maxXRot);
        transform.localRotation = Quaternion.Euler(rotationX, transform.localEulerAngles.y, 0f);

        mouseDir = Vector2.zero;
    }

    void SetCameraDist()
    {
        float dist = cameraDist;
        Vector3 dir = (Camera.main.transform.position - transform.position).normalized;
        Ray ray = new Ray(transform.position + Vector3.up * 0.2f, dir);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, cameraDist))
            dist = (hit.point - transform.position).magnitude;

        Camera.main.transform.localPosition = cameraDir * dist;
    }
}
