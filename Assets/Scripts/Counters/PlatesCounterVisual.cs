using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] PlateCounter plateCounter;
    [SerializeField] Transform counterTopPoint;
    [SerializeField] Transform plateVisualPrefab;

    List<GameObject> plateVisualGameObjectList;
    void Awake()
    {
        plateVisualGameObjectList = new List<GameObject>();
    }
    void Start()
    {
        plateCounter.OnPlateSpawned += PlateCounter_OnPlateSpawned;
        plateCounter.OnPlateRemoved += PlateCounter_OnPlateRemove;
    }

    void PlateCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(plateVisualPrefab, counterTopPoint);

        float plateOffsetY = .1f;
        plateVisualTransform.localPosition = new Vector3(0, plateOffsetY * plateVisualGameObjectList.Count, 0);

        plateVisualGameObjectList.Add(plateVisualTransform.gameObject);
    }

    void PlateCounter_OnPlateRemove(object sender, System.EventArgs e)
    {
        GameObject plateGameObejct = plateVisualGameObjectList[plateVisualGameObjectList.Count - 1];

        plateVisualGameObjectList.Remove(plateGameObejct);
        Destroy(plateGameObejct);
    }


}
