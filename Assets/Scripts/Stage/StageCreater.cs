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

    void StageCreate(Vector3 pos)
    {
        Debug.Log("StageCreate called");
        Collider[] colls = Physics.OverlapSphere(pos, 1.0f);
        if (colls.Length > 0)
        {
            foreach (Collider hitActor in colls)
            {
                if(hitActor.tag=="Stage")
                {
                    Debug.Log("Stage Exist");
                    return;
                }
                else
                {
                    Instantiate(stagePrefab, pos, Quaternion.Euler(0f, 0f, 0f));
                    return;
                }
            }
        }
        else
        {
            Instantiate(stagePrefab, pos, Quaternion.Euler(0f, 0f, 0f));
            return;
        }
    }
}
