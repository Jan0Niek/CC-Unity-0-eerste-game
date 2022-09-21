using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollection : MonoBehaviour
{

    int numCoins=0;
    [SerializeField]
    GameObject coinText;
    GameObject[] coins;
    [SerializeField]
    GameObject coinNumToGetText;
    void Start(){
        coins = GameObject.FindGameObjectsWithTag("coin");
        for (int i = 0; i < coins.Length; i++)
        {
           coins[i].transform.Rotate(new Vector3(45, 45, 45), Space.World);
        }
        coinNumToGetText.GetComponent<TextMeshPro>().SetText("Get all "+coins.Length+" coins!");
    }
    void Update(){
        for (int i = 0; i < coins.Length; i++)
        {
           coins[i].transform.Rotate(new Vector3(0.05f, 0.15f, 0.05f), Space.World);
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag=="coin"){
            col.gameObject.SetActive(false);
            numCoins++;
            coinText.GetComponent<TextMeshProUGUI>().SetText("Coins: "+numCoins);

        }
    }
    public int getCoinCount(){
        return numCoins;
    }
}
