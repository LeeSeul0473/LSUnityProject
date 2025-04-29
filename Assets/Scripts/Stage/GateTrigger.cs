using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        Debug.Log("GateTrigger Overlap : " + gameObject.tag);
        GameObject gameController = GameObject.FindWithTag("GameController");
        Transform spawnPos = gameObject.transform;
        spawnPos.rotation = Quaternion.Euler(0f, 0f, 0f);
        Vector3 tempPosition = spawnPos.position;
        tempPosition.y = 0.0f;
        spawnPos.position = tempPosition;

        switch (gameObject.tag)
        {
            case "Door+Z":
                spawnPos.position += new Vector3(0f, 0f, 5f);
                gameController.SendMessage("StageCreate", spawnPos);
                break;

            case "Door-Z":
                spawnPos.position += new Vector3(0f, 0f, -5f);
                gameController.SendMessage("StageCreate", spawnPos);
                break;

            case "Door+X":
                spawnPos.position += new Vector3(5f, 0f, 0f);
                gameController.SendMessage("StageCreate", spawnPos);
                break;

            case "Door-X":
                spawnPos.position += new Vector3(-5f, 0f, 0f);
                gameController.SendMessage("StageCreate", spawnPos);
                break;
        }

    }
}
