using UnityEngine;
using System.Collections;
using System;

public class Ingredient : MonoBehaviour {

    [Serializable]
    public class effect {
        public Book.symptoms symptom;
        public int value;

    }
    public effect[] effects;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
