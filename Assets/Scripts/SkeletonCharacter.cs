using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonCharacter : MonoBehaviour
{
    SphereCollider sphereCollider;
    bool isAggro = false;
    GameObject hitterGameObject;
    Animator animator;

    Transform transform;

    float skeletonSpeed = 4.0f;

    /**
        Make sure the skeleton don't collide with the player (hitbox)
    */
    float safeXDistanceForMove = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        this.sphereCollider = gameObject.GetComponent<SphereCollider>();
        this.animator = gameObject.GetComponent<Animator>();
        this.transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( isAggro == true ) {
            Debug.Log("SKELETON AGGROED");
            
            transform.LookAt(this.hitterGameObject.transform.position);
            this.animator.SetBool("isAggroStartRun", isAggro);
            this.animator.SetBool("isAggroStopRun", isAggro);

            float step =  this.skeletonSpeed * Time.deltaTime; // calculate distance to move
            Vector3 vecCurrentPlayerPosWithSafeSpace = new Vector3(this.hitterGameObject.gameObject.transform.position.x - this.safeXDistanceForMove, this.hitterGameObject.gameObject.transform.position.y, this.hitterGameObject.gameObject.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, vecCurrentPlayerPosWithSafeSpace, step);
        }
    }

    void OnTriggerEnter(Collider col) {

        // Global tag attribute for Player "aggroable"
        if ( col.tag == "Player" ) {
            this.isAggro = true;
            this.hitterGameObject = col.gameObject;

            Debug.Log(this.hitterGameObject.tag);
            Debug.Log(this.hitterGameObject.name);
        }
    }

    void OnTriggerExit(Collider col) {
        GameObject exiterGameObject = col.gameObject;
        Debug.Log("EXIT TRIGGER");

        // Global tag attribute for Player "aggroable"
        if ( col.tag == "Player" ) {
            Debug.Log(exiterGameObject.tag);
            Debug.Log(exiterGameObject.name);
    
            this.isAggro = false;
            this.animator.SetBool("isAggroStartRun", isAggro);
            this.animator.SetBool("isAggroStopRun", isAggro);
            this.hitterGameObject = null; // reset hitted game object
        }
    }
}
