using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class RestartToLastCheckpoint : MonoBehaviour
{
    GameObject lastCheckpoint;
    Vector3 checkpointPos;
    [SerializeField]
    int lives = 3;
    [SerializeField]
    GameObject livesText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        livesText.GetComponent<TextMeshProUGUI>().SetText("Lives:"+lives );
        if(transform.position.y < -20){
            if(lastCheckpoint!=null){
                lives--;
                checkpointPos = lastCheckpoint.transform.position;
                transform.SetPositionAndRotation(new Vector3(checkpointPos.x, checkpointPos.y+6, checkpointPos.z), transform.rotation);
            }else{
                lives--;
                transform.SetPositionAndRotation(new Vector3(0,3,0), transform.rotation);
            }
        } 
        if (lives <1){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("checkpoint")){
            lastCheckpoint = col.gameObject;
        }
    }
}