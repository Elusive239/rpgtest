using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldController : MonoBehaviour
{
    public float movSpeed = 1f;
    public float encounterRate;
    private Vector3 target;
    public Transform upper, lower, left, right;
    private Transform player;
    [SerializeField]
    private bool isMoving;
    [SerializeField]
    private float timer;
    [SerializeField]
    private float gracePeriod;

    public void Awake(){
        player = this.transform;
        timer = 0;
    }

    public void Update(){
        //right click
        if(Input.GetMouseButtonDown(1)){
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = player.position.z;

            if(isMoving){
                timer += 2;
                TryEncounter();
            }

            isMoving = true;
        }
        //escape
        if(Input.GetKeyDown("escape")) {
            if(UIManager.Count == 0){
                UIManager.Instance.Show();
            }else{
                UIManager.Instance.Hide();
            }
        }

        if(isMoving){
            player.position = Vector3.MoveTowards(player.position, target, movSpeed * Time.deltaTime);
            if(Vector3.Distance(player.position, target) <= 0.01){
                isMoving = false;
                //snap character to where you wanted to go
                player.position = new Vector3(
                    target.x,
                    target.y,
                    player.position.z
                );
                TryEncounter();
            }
            timer += Time.deltaTime;   
        }
    }

    public void TryEncounter(){
        if(timer > gracePeriod && Random.Range(1, 100) > (1 - encounterRate)*100){
            //Debug.Log("An encounter would have triggered here.");
            SceneManager.LoadScene("BattleScene");
        }
    }
}
