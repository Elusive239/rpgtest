using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : UIPanelBase
{
    public Button[] nextButton;

    public void Awake(){
        for (int i = 0; i < panels.Length; i++){
            UIPanelBase panel = panels[i];
            Debug.Log($"{i}th button \'{nextButton[i].name}\' goes to panel \'{panel.name}\'");
            nextButton[i].onClick.AddListener( delegate {UIManager.Instance.Show(panel);});
        }
    }
}
