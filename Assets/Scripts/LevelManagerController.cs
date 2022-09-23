using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerController : MonoBehaviour
{
    public PlayerController gamePlayer;
    public int coins;
    public Text Score;

    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController> ();
        Score.text = "x" + coins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins(int numberOfCoins){
        coins += numberOfCoins;
        Score.text = "x" + coins;
    }
}
