using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManagerScript : MonoBehaviour
{
    bool passTurn = false;
    public Entity player;
    public Entity enemy;
    public Slider playerHealthUI;
    public Slider enemyHealthUI;
    public Button openItemMenu;
    public GameObject battleMenu;
    public GameObject fightMenu;
    public GameObject itemMenu;
    public GameObject victory;
    public GameObject defeat;

    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        //TODO: This is placeholder. Ideally player currentHealth will be constant,
        //enemy currentHealth will be set based on the encounter. For testing purposes, this is fine.
        player.priority = true;
        player.currentHealth = player.maxHealth;
        enemy.currentHealth = enemy.maxHealth;
        playerHealthUI.maxValue = player.maxHealth;
        playerHealthUI.value = player.currentHealth;
        enemyHealthUI.maxValue = enemy.currentHealth;
        CheckEmptyInventory();
    }

    // Update is called once per frame
    void Update()
    {

        //If player has no remaining currentHealth, end the game.
        if(player.currentHealth <= 0){
            battleMenu.SetActive(false);
            defeat.SetActive(true);
            StartCoroutine("TransitionToMainMenu", 3.5f);
        }

        //If the fightMenu is gone and the player no longer has priority, the enemy takes their turn.
        //If the enemy has no currentHealth remaining, end the encounter.
        if(fightMenu.activeInHierarchy == false && itemMenu.activeInHierarchy == false){  
            if(enemy.currentHealth > 0){
                if(player.priority == false){
                    EnemyTurn();
                    player.priority=true;
                }   
            }
            //TODO: Should change scene Back to the overworld.
            else{
                victory.SetActive(true);
                battleMenu.SetActive(false);
                StartCoroutine("TransitionToOverworld", 3.5f);
            }
        }
        //If the player has moved, set the enemy's health bar and disable the fightMenu or itemMenu
        if(player.priority == false){
            Debug.Log(itemMenu.activeInHierarchy);
            fightMenu.SetActive(false);
            itemMenu.SetActive(false);
            CheckEmptyInventory();
            MoveSlider(enemyHealthUI, enemy.currentHealth);
        }
        
    }
    void EnemyTurn(){
        player.TakeDamage(enemy.attacks[0].damage);
        MoveSlider(playerHealthUI, player.currentHealth);
        passTurn = false;
        battleMenu.SetActive(true);
        Debug.Log(player.currentHealth);

    }
    public void PlayerAttacking(){
        battleMenu.SetActive(false);
        fightMenu.SetActive(true);
    }
    public void Item(){
        battleMenu.SetActive(false);
        itemMenu.SetActive(true);
    }
    public void ItemBack(){
        itemMenu.SetActive(false);
        battleMenu.SetActive(true);
    }   
    public void Back(){
        fightMenu.SetActive(false);
        battleMenu.SetActive(true);
    }
    public void Run(){
        float escape = Random.Range(1, 100);
        if(escape < 51){
            StartCoroutine("TransitionToOverworld", 1);
        }
        else{
            Debug.Log("Escape failed");
            player.priority = false;
        }
    }

    void MoveSlider(Slider slider, int currentcurrentHealth){
        slider.value = currentcurrentHealth;
    }
    IEnumerator TransitionToOverworld(float seconds){
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("OverworldScene");
    }
    IEnumerator TransitionToMainMenu(float seconds){
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("MainMenu");
    }
    void CheckEmptyInventory(){
        Debug.Log(player.items.Length);
        if(player.items.Length < 1){
            openItemMenu.interactable = false;
        }
    }
    
}
