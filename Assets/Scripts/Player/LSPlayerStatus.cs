using UnityEngine;

public enum LSGameState
{
    Fighting,
    CatchingKey,
    CelectingRoom,
}

public class LSPlayerStatus : MonoBehaviour
{
    private int life = 100;
    private int key = 0;
    private int killedGhost;
    private GameObject gameController;
    public GUISkin skin;
    private int maxkilledGhost = 5;
    private LSGameState playerState;

    bool isEscaping;

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
        killedGhost = maxkilledGhost;
        playerState = LSGameState.CelectingRoom;
        isEscaping = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CatchKey()
    {
        //Debug.Log("CatchKey called");
        key++;
        gameController.SendMessage("FightEnd");
        playerState = LSGameState.CelectingRoom;
    }

    void ApplyDamage(int amount)
    {
        life -= amount;
        if (life <= 0)
        {
            gameController.SendMessage("GameOver");
        }
    }

    void KilledGhost()
    {
        if(playerState == LSGameState.Fighting)
        {
            //Debug.Log("KilledGhost called.");
            killedGhost--;

            if (killedGhost <=0)
            {
                gameController.SendMessage("KeySpawn");
                playerState = LSGameState.CatchingKey;
            }
        }
    }

    void FightStart()
    {
        killedGhost = maxkilledGhost;
        playerState = LSGameState.Fighting;
    }

    void EscapeStart()
    {
        isEscaping = true;
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        Rect rect1 = new Rect(50,100,Screen.width,Screen.height);
        Rect rect2 = new Rect(50, Screen.height/8+100, Screen.width,Screen.height);
        Rect rect3 = new Rect(50, Screen.height/4+100, Screen.width,Screen.height);
        Rect rect4 = new Rect(50, Screen.height/3 + 100, Screen.width, Screen.height);
        GUI.Label(rect1, "HP : " + life.ToString(), "HP");

        switch (playerState)
        {
            case LSGameState.Fighting:
                GUI.Label(rect2, "Level : " + (key + 1).ToString(), "Key");
                GUI.Label(rect3, "Ghost : " + killedGhost.ToString(), "Ghost");
                if (isEscaping)
                {
                    GUI.Label(rect4, "Find Escape Door!", "State");
                }
                else
                {
                    GUI.Label(rect4, "Kill the Ghosts!", "State");
                }
                break;

            case LSGameState.CatchingKey:
                GUI.Label(rect2, "");
                GUI.Label(rect3, "");
                if (isEscaping)
                {
                    GUI.Label(rect4, "Find Escape Door!", "State");
                }
                else
                {
                    GUI.Label(rect4, "Key is Generated!", "State");
                }
                break;

            case LSGameState.CelectingRoom:
                GUI.Label(rect2, "");
                GUI.Label(rect3, "");
                if (isEscaping)
                {
                    GUI.Label(rect4, "Find Escape Door!", "State");
                }
                else
                {
                    GUI.Label(rect4, "Select Room.", "State");
                }
                break;

            default:
                break;
        }
    }
}
