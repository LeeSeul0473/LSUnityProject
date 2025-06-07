using UnityEngine;

public class LSPlayerStatus : MonoBehaviour
{
    private int life = 100;
    private int key = 0;
    private int killedGhost = 0;
    private GameObject gameController;
    public GUISkin skin;
    private bool isFightTime;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
        isFightTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CatchKey()
    {
        Debug.Log("CatchKey called");
        key++;
        gameController.SendMessage("FightEnd");
        isFightTime = true;
        killedGhost = 0;
    }

    void ApplyDamage(int amount)
    {
        life -= amount;
        if (life < 0)
        {
            //Destroy(transform.parent.gameObject);
        }
    }

    void KilledGhost()
    {
        if(isFightTime)
        {
            Debug.Log("KilledGhost called.");
            killedGhost++;
            if (killedGhost == 1)
            {
                gameController.SendMessage("KeySpawn");
                isFightTime = false;
            }
        }
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        Rect rect1 = new Rect(0,0,Screen.width,Screen.height);
        Rect rect2 = new Rect(0, Screen.height/8, Screen.width,Screen.height);
        Rect rect3 = new Rect(0, Screen.height/4, Screen.width,Screen.height);
        Rect rect4 = new Rect(0, 0, Screen.width,Screen.height/8);
        GUI.Label(rect1, "HP : " + life.ToString(), "HP");
        GUI.Label(rect2, "Key : " + key.ToString(), "Key");
        if (isFightTime)
        {
            GUI.Label(rect3, "Ghost : " + killedGhost.ToString(), "Ghost");
            GUI.Label(rect4, "");
        }
        else
        {
            GUI.Label(rect3, "");
            GUI.Label(rect4, "Key is Generated!", "Title");
        }

    }


}
