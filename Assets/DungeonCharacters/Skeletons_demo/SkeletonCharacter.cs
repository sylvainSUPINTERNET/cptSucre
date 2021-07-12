using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonCharacter : MonoBehaviour
{
    SphereCollider sphereCollider;

    // Start is called before the first frame update
    void Start()
    {
        this.sphereCollider = gameObject.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col) {
        GameObject gObj = col.gameObject;
        Transform hit = gObj.transform;
        Vector3 ennemyPos = new Vector3(hit.position.x, hit.position.y, hit.position.z);
        transform.Translate(ennemyPos.x,ennemyPos.y, ennemyPos.z * Time.deltaTime);
        Debug.Log("DETECTED COLLISION");
    }
}
