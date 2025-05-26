using UnityEngine;

public class LSPlayerStatus : MonoBehaviour
{
    private int life = 100;
    private int score = 0;
    private GameObject gameController;


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
            Destroy(transform.parent.gameObject);
        }
    }


}
