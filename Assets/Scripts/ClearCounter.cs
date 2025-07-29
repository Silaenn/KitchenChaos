using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    [SerializeField] Transform counterTopPoint;
    public void Interact()
    {
        Debug.Log("Interact");
        Transform kitchenObjectTranfom = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
        kitchenObjectTranfom.localPosition = Vector3.zero;

        Debug.Log(kitchenObjectTranfom.GetComponent<KitchenObject>().GetKitchenObjectSO().objectName);
    }
}
