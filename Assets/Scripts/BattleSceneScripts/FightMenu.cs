using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMenu : MonoBehaviour
{
    public Entity player;
    public GameObject fightOptionPrefab;
    public Transform fightPanel;

    // Start is called before the first frame update
    void Start()
    {
        PopulateAttacks();
    }

    public void PopulateAttacks(){
        foreach(Attack i in player.attacks){
            GameObject option;
            option = Instantiate(fightOptionPrefab, fightPanel, true);
            option.name = i.attackName;
        }
    }
}
