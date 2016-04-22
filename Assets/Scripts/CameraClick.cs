using UnityEngine;
using System.Collections;

public class CameraClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("X");
            RaycastHit hit;

            if(Physics.Raycast(GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit, 50)) { 
            
                Debug.Log("Gonna");
                Ingredient i = hit.transform.GetComponent<Ingredient>();

                if(i != null) {
                    Debug.Log("Give it to ya");
                    Cauldron c = GameObject.FindObjectOfType<Cauldron>();
                    foreach (Ingredient.effect effect in i.effects) {
                        c.addProperty(effect.symptom, effect.value);
                    }
                    Debug.Log(GameObject.FindObjectOfType<Cauldron>().ToString());
                }
            }
        }
	}
}
