using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    
    private LevelManagerController gameLevelManager;
    public int coinValue;

    // Start is called before the first frame update
    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManagerController> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player"){
            gameLevelManager.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }
}
