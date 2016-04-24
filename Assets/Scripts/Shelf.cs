using UnityEngine;
using System.Collections;

public class Shelf : MonoBehaviour {
    [SerializeField] GameObject[] ingredients;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void turnOffColliders() {
        foreach(GameObject i in ingredients) {
            i.GetComponent<Collider>().enabled = false;
        }
    }

    public void turnOnColliders() {
        foreach (GameObject i in ingredients) {
            i.GetComponent<Collider>().enabled = true;
        }
    }
}
