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

            foreach(Collider hitActor in colls)
            {
                TakeDamageInterface DamageActor = (TakeDamageInterface)hitActor.gameObject.GetComponent<Item>();
                if(DamageActor != null)
                {
                    DamageActor.TakeDamage(10.0f);
                }
                else
                {
                    Debug.Log("TakeDamageInterface not found.");
                }
            }
        }
        else
        {
            Debug.Log("Attack not Hitted.");
            
        }
    }
}
