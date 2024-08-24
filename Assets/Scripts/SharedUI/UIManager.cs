using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set;}
    public bool closeLast = false;
    public bool showOnStart = false;
    public UIPanelBase startingPanel = null;
    [SerializeField]
    Stack<UIPanelBase> ui = null;

    public void Start(){
        Instance = this;
        Init();
        if(showOnStart)
            Show();
    }

    public void Init(){
        if(ui == null){
            ui = new Stack<UIPanelBase>(new UIPanelBase[]{startingPanel});
        }else{
            ui.Push(startingPanel);
        }
    }

    public void Show(UIPanelBase panel = null){
        if(panel == null){
            panel = startingPanel;
        }

        if(ui.Count > 0)
            ui.Peek().Hide();
        ui.Push(panel);
        ui.Peek().Show();
    }

    public void Hide(){
        if(ui.Count < 2 && !closeLast){
            return;
        }

        ui.Peek().Hide();
        ui.Pop();
        if(ui.Count > 0 )
        ui.Peek().Show();
    }

    public void ForceHide(){
        if(ui.Count < 1){
            return;
        }
        ui.Peek().Hide();
        ui.Pop();
        if(ui.Count > 0 ){
            ui.Peek().Show();
        }
    }

    public void Clear(){
        while(ui.Count > 0) {
            ForceHide();
        }
    }

    public bool IsStart(){return ui.Count == 1;}

    public static int Count {get{return Instance.ui.Count;}}
}
