using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;//To know if there is a kitchenObject on top of it

    public void Interact(Player player){
        if(kitchenObject == null){
            //Spawns the object and puts it exactly on top of a ClearCounter
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab,counterTopPoint); 
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else{
            //Gives the object to the Player
            kitchenObject.SetKitchenObjectParent(player); 
        }   
    }

    public Transform GetKitchenObjectFollowTransform(){
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject){
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject(){
        return kitchenObject;
    }

    public void ClearKitchenObject(){
        kitchenObject = null;
    }

    public bool HasKitchenObject(){
        return kitchenObject != null;
    }
}
