using UnityEngine;
using System.Collections;


public class LSAttackAction : MonoBehaviour
{
    private float meleeAttackRadius;
    [SerializeField] public LSAniminstance Animinstance;
    private GameObject player;
    private LSPlayerStatus PlayerStatus;
    Vector3 attackPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meleeAttackRadius = 1.2f;
        player = GameObject.FindWithTag("Player");
        PlayerStatus = GetComponent<LSPlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(MeleeAttack());
        }
    }

    IEnumerator MeleeAttack()
    {
        Animinstance.SendMessage("PlayAttack");
        attackPosition = player.transform.position + player.transform.forward * 1f;
        attackPosition.y = 0.7f;
        //Debug.Log("attack Position : " + attackPosition);
        //Debug.Log("Player Position : " + player.transform.position);

        yield return new WaitForSeconds(0.3f);

        //Debug.Log("MeleeAttack Begin");
        Collider[] colls = Physics.OverlapSphere(attackPosition, meleeAttackRadius);
        if (colls.Length > 0)
        {
            foreach (Collider hitActor in colls)
            {
                if (hitActor.tag == "Ghost")
                {
                    Destroy(hitActor.gameObject);
                    if(PlayerStatus != null)
                    {
                        PlayerStatus.SendMessage("KilledGhost");
                    }
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
