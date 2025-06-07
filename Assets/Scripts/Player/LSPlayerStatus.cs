using UnityEngine;

public enum LSGameState
{
    Fighting,
    CatchingKey,
    CelectingRoom,
    Escape
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

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
        killedGhost = maxkilledGhost;
        playerState = LSGameState.CelectingRoom;
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
        playerState = LSGameState.Escape;
    }

    private void OnGUI()
    {
        GUI.skin = skin;
        Rect rect1 = new Rect(0,0,Screen.width,Screen.height);
        Rect rect2 = new Rect(0, Screen.height/8, Screen.width,Screen.height);
        Rect rect3 = new Rect(0, Screen.height/4, Screen.width,Screen.height);
        Rect rect4 = new Rect(0, Screen.height/3, Screen.width, Screen.height);
        GUI.Label(rect1, "HP : " + life.ToString(), "HP");

        switch (playerState)
        {
            case LSGameState.Fighting:
                GUI.Label(rect2, "Level : " + (key + 1).ToString(), "Key");
                GUI.Label(rect3, "Ghost : " + killedGhost.ToString(), "Ghost");
                GUI.Label(rect4, "Kill the Ghosts!", "Title");
                break;

            case LSGameState.Escape:
                GUI.Label(rect2, "");
                GUI.Label(rect3, "");
                GUI.Label(rect4, "Escape Door Generated!", "Title");
                break;

            case LSGameState.CatchingKey:
                GUI.Label(rect2, "");
                GUI.Label(rect3, "");
                GUI.Label(rect4, "Key is Generated!", "Title");
                break;

            case LSGameState.CelectingRoom:
                GUI.Label(rect2, "");
                GUI.Label(rect3, "");
                GUI.Label(rect4, "Celect Room.", "Title");
                break;

            default:
                break;
        }
    }


}
