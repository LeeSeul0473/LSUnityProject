using System.Collections;
using UnityEngine;

public class LSGhostMove : MonoBehaviour
{
    public float moveSpeed = 1f;
    private float rotationSpeed;
    public int attackDamage = 5;
    private CharacterController characterController;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        characterController = GetComponent<CharacterController>();
        rotationSpeed = 10f;
    }

    private void Update()
    {
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
        moveDirection.y = 0;
        characterController.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SendMessage("ApplyDamage", attackDamage);
            Destroy(gameObject);
        }
    }

    private void ApplyLevel(float inMoveSpeed, int inAttackDamage)
    {
        moveSpeed = inMoveSpeed;
        attackDamage = inAttackDamage;
    }
}
