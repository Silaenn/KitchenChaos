using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    public override void Interact(Player player)
    {
        Transform kitchenObjectTranfom = Instantiate(kitchenObjectSO.prefab);
        kitchenObjectTranfom.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
    }
}
