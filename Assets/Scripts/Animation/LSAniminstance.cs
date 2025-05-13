using UnityEngine;
using UnityEngine.UIElements;

public class LSAniminstance : MonoBehaviour
{
    public Animator animator;
    public GameObject owner;
    private CharacterController ownerController;

    public bool bisIdle = true;
    private int isIdleHash;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        ownerController = owner.GetComponent<CharacterController>();

        isIdleHash = Animator.StringToHash("IsIdle");

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool(isIdleHash, bisIdle);
        Debug.Log($"isIdle 설정: {bisIdle}, 애니메이터 값: {animator.GetBool(isIdleHash)}");
    }

    void PlayAttack()
    {
        animator.SetTrigger("Attack");
    }
}