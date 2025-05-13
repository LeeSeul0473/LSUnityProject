using UnityEngine;

public class LSPlayerMove : MonoBehaviour
{
    Camera mainCamera;
    CharacterController LScontroller;
    LSAniminstance Animinstance;
    public Transform CameraDir;

    public float walkspeed = 5f;
    public float runSpeed = 8f;
    public float speed;
    public float rotationSpeed = 10f;

    public bool bRun;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        LScontroller = this.GetComponent<CharacterController>();
        Animinstance = transform.Find("Ch11_nonPBR").GetComponent<LSAniminstance>();
    }

    // Update is called once per frame
    void Update()
    {
        //Run Input
        if(Input.GetKey(KeyCode.LeftShift))
        {
            bRun = true;
        }
        else
        {
            bRun = false;
        }

        InputMovement();
    }

    void InputMovement()
    {
        speed = bRun ? runSpeed : walkspeed;

        if((Input.GetAxisRaw("Vertical")!=0) || (Input.GetAxisRaw("Horizontal")!=0))
        {
            Vector3 forward = CameraDir.TransformDirection(Vector3.forward);
            Vector3 right = CameraDir.TransformDirection(Vector3.right);
            forward.y = 0f;
            right.y = 0f;

            Vector3 moveDirection = forward * Input.GetAxisRaw("Vertical") + right * Input.GetAxisRaw("Horizontal");

            LScontroller.Move(moveDirection.normalized * speed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), rotationSpeed * Time.deltaTime);
            
            if(Animinstance)
            {
                Animinstance.bisIdle = false;
            }
        }
        else
        {
            Animinstance.bisIdle = true;
        }
    }
}
