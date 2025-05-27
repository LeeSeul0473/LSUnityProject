using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class LSGhostMove : MonoBehaviour
{
    private float moveSpeed;
    private float rotationSpeed;
    private CharacterController characterController;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        characterController = GetComponent<CharacterController>();
        moveSpeed = 1f;
        rotationSpeed = 10f;
    }

    private void Update()
    {
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
        moveDirection.y = 0;
        characterController.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), rotationSpeed * Time.deltaTime);
    }

    IEnumerator WaitAndMove(GameObject player, float time)
    {
        while (true)
        {


            yield return new WaitForSeconds(time);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SendMessage("ApplyDamage", 5);
            Destroy(gameObject);
        }
    }
}
