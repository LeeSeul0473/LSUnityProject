using System.Collections;
using UnityEngine;

public class LSKeyMove : MonoBehaviour
{
    private float Velocity;
    private float SustainTime;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Velocity = -4.0f;
        SustainTime = 1.0f;

        if (player != null)
        {
            StartCoroutine(WaitAndMove(player, SustainTime));   
        }
    }

    IEnumerator WaitAndMove(GameObject player, float time)
    {
        while (true)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            GetComponent<Rigidbody>().AddForce(direction * Velocity, ForceMode.VelocityChange);

            yield return new WaitForSeconds(time);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SendMessage("CatchKey", 10);
            Destroy(gameObject);
        }
    }
}
