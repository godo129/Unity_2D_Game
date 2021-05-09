using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    private bool _grabbing;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            _grabbing = true;
        }
        if (Input.GetMouseButton(0))
        {
            GameObject closest = FindNearest();
            if (_grabbing)
            {
                closest.GetComponentInChildren<HingeJoint2D>().connectedBody = gameObject.GetComponentInChildren<Rigidbody2D>();
                _grabbing = false; 
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            GameObject[] hinges;
            hinges = GameObject.FindGameObjectsWithTag("hinge");

            foreach(GameObject go in hinges)
            {
                go.GetComponentInChildren<HingeJoint2D>().connectedBody = null;
            }

        }
		
	}
    GameObject FindNearest()
    {
        GameObject[] hinges;
        hinges = GameObject.FindGameObjectsWithTag("hinges");
        GameObject closest = null;

        float distance = Mathf.Infinity;

        Vector2 position = transform.position;

        foreach(GameObject go in hinges)
        {
            Vector2 diff = go.transform.position - go.transform.position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance< distance)
            {
                closest = go;
                distance = curDistance;
            }

        }

        return closest;
    }
}
