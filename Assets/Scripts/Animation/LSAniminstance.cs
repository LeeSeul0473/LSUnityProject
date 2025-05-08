using UnityEngine;

public class LSAniminstance : MonoBehaviour
{
    public Animator animator;
    public GameObject Owner;
    private CharacterController OwnerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator=GetComponent<Animator>();
        if(Owner)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
