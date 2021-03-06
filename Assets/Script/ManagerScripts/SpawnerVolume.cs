using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerVolume : MonoBehaviour
{
    public BoxCollider boxCollider;
    public Bounds boxBounds;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    public Vector3 GetPositionInBounds()
    {
        boxBounds = boxCollider.bounds;
        return new Vector3(Random.Range(boxBounds.min.x, boxBounds.max.x), transform.position.y, Random.Range(boxBounds.min.z, boxBounds.max.z));
    }
}
