using UnityEngine;

public class LSAttackAction : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] public float meleeAttackDamage;
    [SerializeField] public float meleeAttackRadius;
    [SerializeField] public bool IsAttack = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meleeAttackRadius = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Attack Key Activated.");
            MeleeAttack();
        }
    }

    void MeleeAttack()
    {
        Vector3 pos = player.position + new Vector3(0.0f, 1.0f, 1.0f);
        Vector3 dir = pos - new Vector3(0.0f, 1.0f, 1.0f) + player.forward * meleeAttackRadius;
        Collider[] colls = Physics.OverlapSphere(pos, meleeAttackRadius);
        if(colls.Length > 0)
        {
            Debug.Log("Attack Hitted.");
            for(Collider hitActor : colls)
            {

            }
        }
        else
        {
            Debug.Log("Attack not Hitted.");
            
        }
    }
}
