using UnityEngine;

public class LSPlayerCamera
{
    [SerializeField] Transform target; // ī�޶� ���� ��� (ĳ����)
    [SerializeField] private float minDistance = 1f; // ī�޶� �ּ� �Ÿ�
    [SerializeField] private float maxDistance = 5f; // ī�޶� �ִ� �Ÿ�
    [SerializeField] private float cameraDist = 3f; // ���� ī�޶� �Ÿ� & �ʱ� �Ÿ�

    public float sensitivity = 100f; // ���콺 ����
    public float minXRot = -50f; // ī�޶��� �ּ� X�� ȸ����
    public float maxXRot = 50f; // ī�޶��� �ִ� X�� ȸ����

    private float rotationX = 0f; // ���� X�� ȸ����
    private Vector2 mouseDir; // ���� ���콺 �Է°� ����
    private Vector3 cameraDir; // �÷��̾� -> ī�޶� ����

    // ���콺 �Է��� �޾� ī�޶� ȸ���� �ݿ�
    void MouseInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Canceled)
        {
            mouseDir = Vector3.zero;
            return;
        }
        mouseDir = context.ReadValue<Vector2>();
    }

    // ���콺 �� �Է��� �޾� ī�޶� �� ����
    void MouseWheelInput(InputAction.CallbackContext context)
    {
        float y = context.ReadValue<Vector2>().y;
        cameraDist += Mathf.Clamp(-y, -1f, 1f);
        cameraDist = Mathf.Clamp(cameraDist, minDistance, maxDistance);
    }

    // ī�޶� ȸ��
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
