using UnityEngine;

public class StageCreater : MonoBehaviour
{
    [SerializeField]
    public GameObject stagePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StageCreate(Transform pos)
    {
        Collider[] colls = Physics.OverlapSphere(pos.position, 1.0f);
        if (colls.Length > 0)
        {
            foreach (Collider hitActor in colls)
            {
                if(hitActor.tag=="Stage")
                {
                    Debug.Log("Stage Exist");
                }
                else
                {
                    Instantiate(stagePrefab, pos.position, pos.rotation);
                }
            }
        }
        else
        {
            Debug.Log("Attack not Hitted.");

        }
    }
}
