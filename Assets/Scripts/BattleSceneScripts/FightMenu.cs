using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMenu : MonoBehaviour
{
    public Entity player;
    public GameObject fightOptionPrefab;
    public GameObject fightPanel;

    // Start is called before the first frame update
    void Start()
    {
        populateAttacks();
    }

    public void populateAttacks(){
        foreach(Attack i in player.attacks){
            GameObject option;
            option = Instantiate(fightOptionPrefab, fightPanel.transform, true);
            option.name= i.name;
        }
    }
}
