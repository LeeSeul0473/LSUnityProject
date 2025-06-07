using UnityEngine;

public class LSEscape : MonoBehaviour
{
    private GameObject gameController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter Called");
        if (other.tag == "Player")
        {
            gameController.SendMessage("GameClear");
        }
    }
}
