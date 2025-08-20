using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField] PlateKitchenObject plateKitchenObject;
    [SerializeField] Transform iconTemplate;

    void Awake()
    {
        iconTemplate.gameObject.SetActive(false);
    }
    void Start()
    {
        plateKitchenObject.onIngredientAdded += PlateKitchenObject_onIngredientAdded;
    }

    void PlateKitchenObject_onIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        Updatevisual();
    }

    void Updatevisual()
    {
        foreach (Transform child in transform)
        {
            if (child == iconTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (KitchenObjectSO kitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
        {
            Transform iconTransform = Instantiate(iconTemplate, transform);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<PlateIconsSingleUI>().SetKitchenObjectSO(kitchenObjectSO);
        }
    }
}
