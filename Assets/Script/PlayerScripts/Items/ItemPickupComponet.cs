using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupComponet : MonoBehaviour
{
    [SerializeField]
    ItemScript pickupItem;

    [Tooltip("Manual Override for drop amount, if left at -1 it will use the amount from the scriptable object")]
    [SerializeField]
    int amount = -1;
    [SerializeField] MeshRenderer propMeshRenderer;
    [SerializeField] MeshFilter propMeshFilter;

    ItemScript itemInstance;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateItem();       
    }


    private void InstantiateItem()
    {
        itemInstance = Instantiate(pickupItem);
        if(amount > 0)
        {
            itemInstance.SetAmount(amount);
        }
        ApplyMesh();
    }

    void ApplyMesh()
    {
        if (propMeshFilter) propMeshFilter.mesh = pickupItem.itemPrefab.GetComponentInChildren<MeshFilter>().sharedMesh;
        if (propMeshRenderer) propMeshRenderer.material = pickupItem.itemPrefab.GetComponentInChildren<MeshRenderer>().sharedMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) return;

        Destroy(gameObject);
    }

}
