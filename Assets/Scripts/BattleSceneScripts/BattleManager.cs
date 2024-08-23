using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public Entity player;
    public Entity enemy;
    public EntityInfo playerHealthUI;
    public EntityInfo enemyHealthUI;
    public UIPanelBase enemyUI;
    public UIPanelBase victory;
    public UIPanelBase defeat;
    public Button openItemMenu;

    // float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        //TODO: This is placeholder. Ideally player currentHealth will be constant,
        //enemy currentHealth will be set based on the encounter. For testing purposes, this is fine.
        player.priority = true;
        player.currentHealth = player.maxHealth;
        enemy.currentHealth = enemy.maxHealth;
        playerHealthUI.SetEntity(player);
        enemyHealthUI.SetEntity(enemy);
        CheckEmptyInventory();
    }

    // Update is called once per frame
    void Update()
    {

        //If player has no remaining currentHealth, end the game.
        if(player.currentHealth <= 0){
            EndCombat(false);
            // UIManager.Instance.Clear();
            // UIManager.Instance.Show(defeat);
            // StartCoroutine("TransitionToMainMenu", 3.5f);
        }

        //If the fightMenu is gone and the player no longer has priority, the enemy takes their turn.
        //If the enemy has no currentHealth remaining, end the encounter.
        if(UIManager.Instance.IsStart()){  
            if(enemy.currentHealth > 0){
                if(player.priority == false){
                    EnemyTurn();
                    player.priority=true;
                }   
            }
            //TODO: Should change scene Back to the overworld.
            else{
                EndCombat(true);
            }
        }
        //If the player has moved, set the enemy's health bar and disable the fightMenu or itemMenu
        if(player.priority == false){
            //Debug.Log(itemMenu.activeInHierarchy);
            UIManager.Instance.Hide();
            CheckEmptyInventory();
            enemyHealthUI.UpdateSlider();
        }
        
    }
    void EndCombat(bool won){
        UIManager.Instance.Clear();
        enemyUI.Hide();
        if(won){
            UIManager.Instance.Show(victory);
            StartCoroutine("TransitionToOverworld", 3.5f);
        }else{
            UIManager.Instance.Show(defeat);
            StartCoroutine("TransitionToMainMenu", 3.5f);
        }
    }

    void EnemyTurn(){
        UIManager.Instance.Hide();
        player.TakeDamage(enemy.attacks[0].attackDamage);
        playerHealthUI.UpdateSlider();
    }

    public void Run(){
        float escape = Random.Range(1, 100);
        if(escape < 51){
            StartCoroutine("TransitionToOverworld", 1);
        }
        else{
            Debug.Log("Escape failed");
            player.priority = false;
            UIManager.Instance.Hide();
        }
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
