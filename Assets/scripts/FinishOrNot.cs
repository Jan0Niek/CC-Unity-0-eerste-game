using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishOrNot : MonoBehaviour
{
    [SerializeField]
    GameObject fakeWinText;
    [SerializeField]
    GameObject trueWinObject;
    [SerializeField]
    GameObject coinsParent;
    // Start is called before the first frame update
    void Start()
    {
        fakeWinText.SetActive(false);
        trueWinObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Player")){
            if(col.gameObject.GetComponent<CoinCollection>().getCoinCount() ==coinsParent.transform.childCount){
                trueWinObject.SetActive(true);
            }else{
                fakeWinText.SetActive(true);
            }
        }
    }
}
