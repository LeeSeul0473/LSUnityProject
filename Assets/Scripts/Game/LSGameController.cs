using UnityEngine;
using UnityEngine.SceneManagement;

public class LSGameController : MonoBehaviour
{
    GameObject currentStage;
    private bool isEscape;
    int currentLevel;
    public GameObject playerStatus;
    private GameObject escapeDoor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        escapeDoor = GameObject.FindWithTag("Escape");
        escapeDoor.SetActive(false);
        isEscape = false;
        currentLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FightStart(GameObject calledObject)
    {
        if(!isEscape)
        {
            if (calledObject.tag == "Stage")
            {
                currentStage = calledObject;
                currentStage.GetComponent<BoxCollider>().enabled = false;
                currentStage.SendMessage("StartGenerate", currentLevel);
                currentStage.SendMessage("CloseGates");
            }

            playerStatus.SendMessage("FightStart");
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

        GameObject[] spawnActors = GameObject.FindGameObjectsWithTag("Ghost");

        foreach (GameObject SpawnActor in spawnActors)
        {
            Destroy(SpawnActor);
        }

        if(currentLevel == 5)
        {
            StartEscape();
        }
        else
        {
            currentLevel++;
        }
    }

    void KeySpawn()
    {
        //Debug.Log("KeySpawn called.");
        if (currentStage != null)
        {
            currentStage.SendMessage("KeyGenerate");
        }
    }

    void StartEscape()
    {
        GameObject[] stages = GameObject.FindGameObjectsWithTag("Stage");
        foreach (GameObject stage in stages)
        {
            stage.SendMessage("StartGenerate", currentLevel);
        }

        playerStatus.SendMessage("EscapeStart");
        escapeDoor.SetActive(true);
    }
    
    void GameClear()
    {
        SceneManager.LoadScene("ClearScene");
    }

    void GameOver()
    {
        SceneManager.LoadScene("OverScene");
    }
}
