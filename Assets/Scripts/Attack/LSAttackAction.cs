using UnityEngine;


public class LSAttackAction : MonoBehaviour
{
    private float meleeAttackRadius;
    //[SerializeField] public bool IsAttack = false;
    [SerializeField] public LSAniminstance Animinstance;
    private GameObject player;
    Vector3 attackPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meleeAttackRadius = 1.5f;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            MeleeAttack();
        }
    }

    void MeleeAttack()
    {
        //Animinstance.SendMessage("PlayAttack");
        attackPosition = player.transform.position + player.transform.forward * 1f;
        attackPosition.y = 0.7f;
        //Debug.Log("attack Position : " + attackPosition);
        //Debug.Log("Player Position : " + player.transform.position);
        Collider[] colls = Physics.OverlapSphere(attackPosition, meleeAttackRadius);
        if (colls.Length > 0)
        {
            foreach (Collider hitActor in colls)
            {
                if (hitActor.tag == "Ghost")
                {
                    Destroy(hitActor.gameObject);
                }
            }
        }
        else
        {
            Debug.Log("Attack not Hitted.");
            
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition, meleeAttackRadius);
    }
}
