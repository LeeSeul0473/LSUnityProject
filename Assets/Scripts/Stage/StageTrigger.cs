using UnityEngine;

public class StageTrigger : MonoBehaviour
{
    public GameObject doorPZMesh;
    public GameObject doorPZTrigger;
    public GameObject doorMZMesh;
    public GameObject doorMZTrigger;
    public GameObject doorPXMesh;
    public GameObject doorPXTrigger;
    public GameObject doorMXMesh;
    public GameObject doorMXTrigger;
    private GameObject gameController;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
        OpenGates();
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
            gameController.SendMessage("FightStart", this.gameObject);
        }
    }

    private void OnTriggerEnd(Collider other)
    {
        //Debug.Log("OnTriggerEnter Called");
        if (other.tag == "Ghost")
        {
            Destroy(other.gameObject);
        }
    }

    private void OpenGates()
    {
        //Debug.Log("OpenGates Called");
        doorPZMesh.gameObject.SetActive(false);
        doorPZTrigger.gameObject.SetActive(true);

        doorMZMesh.gameObject.SetActive(false);
        doorMZTrigger.gameObject.SetActive(true);

        doorPXMesh.gameObject.SetActive(false);
        doorPXTrigger.gameObject.SetActive(true);

        doorMXMesh.gameObject.SetActive(false);
        doorMXTrigger.gameObject.SetActive(true);
    }

    private void CloseGates()
    {
        //Debug.Log("CloseGates Called");

        doorPZMesh.gameObject.SetActive(true);
        doorPZTrigger.gameObject.SetActive(false);

        doorMZMesh.gameObject.SetActive(true);
        doorMZTrigger.gameObject.SetActive(false);

        doorPXMesh.gameObject.SetActive(true);
        doorPXTrigger.gameObject.SetActive(false);

        doorMXMesh.gameObject.SetActive(true);
        doorMXTrigger.gameObject.SetActive(false);
    }
}
