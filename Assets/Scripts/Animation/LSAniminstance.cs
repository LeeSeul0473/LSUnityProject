using UnityEngine;

public class LSAniminstance : MonoBehaviour
{
    public Animator animator;
    public GameObject owner;
    private CharacterController ownerController;

    public float movingThreshold = 5.0f;
    public float jumpingThreshold = 100.0f;

    private int groundSpeedHash;
    private int isIdleHash;
    private int isFallingHash;
    private int isJumpingHash;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        ownerController = owner.GetComponent<CharacterController>();

        groundSpeedHash = Animator.StringToHash("GroundSpeed");
        isIdleHash = Animator.StringToHash("IsIdle");
        isFallingHash = Animator.StringToHash("IsFalling");
        isJumpingHash = Animator.StringToHash("IsJumping");

    }

    // Update is called once per frame
    void Update()
    {
        if (ownerController != null)
        {
            Vector3 velocityValue = ownerController.velocity;
            float groundSpeedValue = new Vector2(velocityValue.x, velocityValue.z).magnitude;
            bool isIdleValue = groundSpeedValue < movingThreshold;
            bool isFallingValue = !ownerController.isGrounded;
            bool isJumpingValue = isFallingValue && (velocityValue.y > jumpingThreshold);

            animator.SetFloat(groundSpeedHash, groundSpeedValue);
            animator.SetBool(isIdleHash, isIdleValue);
            animator.SetBool(isFallingHash, isFallingValue);
            animator.SetBool(isJumpingHash, isJumpingValue);
            Debug.Log("groundSpeedValue : " + groundSpeedValue);
        }
        else
        {
            Debug.Log("No ownerController");
        }
    }
}