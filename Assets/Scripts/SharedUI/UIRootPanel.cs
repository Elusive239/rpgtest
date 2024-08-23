using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRootPanel : UIPanelBase
{
    public override void Hide(){
        for(int i = 0; i < this.panels.Length; i++){
            this.panels[i].Hide();
        }
        this.gameObject.SetActive(false);
    }

    public override void Show(){
        for(int i = 0; i < this.panels.Length; i++){
            this.panels[i].Show();
        }
        this.gameObject.SetActive(true);
    }
}
