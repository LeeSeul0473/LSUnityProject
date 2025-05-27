using UnityEngine;

public class LSPlayerStatus : MonoBehaviour
{
    private int life = 100;
    private int score = 0;
    private GameObject gameController;
    public GUISkin skin;


    void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CatchKey()
    {
        score++;
        gameController.SendMessage("FightEnd");
    }

    void ApplyDamage(int amount)
    {
        life -= amount;
        if (life < 0)
        {
            //Destroy(transform.parent.gameObject);
        }
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        Rect rect1 = new Rect(0,0,Screen.width,Screen.height);
        Rect rect2 = new Rect(0, Screen.height/6, Screen.width,Screen.height);
        GUI.Label(rect1, "HP : " + life.ToString(), "HP");
        GUI.Label(rect2, "Key : " + score.ToString(), "Key");

    }


}
