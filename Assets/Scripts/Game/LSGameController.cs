using UnityEngine;

public class LSGameController : MonoBehaviour
{
    GameObject currentStage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FightStart(GameObject calledObject)
    {
        if(calledObject.tag == "Stage")
        {
            currentStage = calledObject;
            if(currentStage != null)
            {
                Debug.Log("currentStage setted.");
            }
            else
            {
                Debug.Log("currentStage setting failed.");
            }


            currentStage.GetComponent<BoxCollider>().enabled = false;
            currentStage.SendMessage("StartGenerate");
            currentStage.SendMessage("CloseGates");
        }
    }

    void FightEnd()
    {
        Debug.Log("FightEnd called.");
        if (currentStage != null)
        {
            currentStage.SendMessage("StopGenerate");
            currentStage.SendMessage("OpenGates");
            currentStage = null;
        }
        else
        {
            Debug.Log("currentStage is null.");
        }

        GameObject[] spawnActors = GameObject.FindGameObjectsWithTag("Ghost");

        foreach (GameObject SpawnActor in spawnActors)
        {
            Destroy(SpawnActor);
        }
    }

    void KeySpawn()
    {
        Debug.Log("KeySpawn called.");
        if (currentStage != null)
        {
            currentStage.SendMessage("KeyGenerate");
        }
    }
    
}
