using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSPlayerCamera : MonoBehaviour
{
    public Transform objectToFollow;
    [SerializeField]
    private float followSpeed = 10f;

    public void Start()
    {
    }

    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.objectToFollow.position, this.followSpeed * Time.deltaTime);
    }
}
