using UnityEngine;
using System.Collections;

public class Shelf : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //turn off all ingredient colliders on the shelf
    public void turnOffColliders() {
        foreach(Collider c in GetComponentsInChildren<Collider>()) {
            c.enabled = false;
        }
    }

    //turn on all ingredient colliders on the shelf
    public void turnOnColliders() {
        foreach (Collider c in GetComponentsInChildren<Collider>()) {
            c.enabled = true;
        }
    }
}
