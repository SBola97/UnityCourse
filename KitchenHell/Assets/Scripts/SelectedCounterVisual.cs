using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;
    private void Start(){
        //Listens the event to the single one player instance
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;  
    }
     
    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e){
        if (e.selectedCounter == clearCounter){
            Show();
        }
        else{
            Hide();
        }
    }

    private void Show(){
        visualGameObject.SetActive(true);
    }

    private void Hide(){
        visualGameObject.SetActive(false);
    }
}
