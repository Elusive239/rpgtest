using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIBackButton : MonoBehaviour
{
    public void Awake(){
        Button button = GetComponent<Button>();
        button.onClick.AddListener(UIManager.Instance.Hide);
    }
}