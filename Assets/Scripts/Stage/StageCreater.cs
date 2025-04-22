using UnityEngine;

public class StageCreater : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StageCreate(Vector3 pos)
    {
        Collider[] colls = Physics.OverlapSphere(pos, 1.0f);
        if (colls.Length > 0)
        {
            foreach (Collider hitActor in colls)
            {
                TakeDamageInterface DamageActor = (TakeDamageInterface)hitActor.gameObject.GetComponent<Item>();
                if (DamageActor != null)
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
