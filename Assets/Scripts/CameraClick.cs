using UnityEngine;
using System.Collections;

public class CameraClick : MonoBehaviour {
    [SerializeField] Book book;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;

            if(Physics.Raycast(GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit, 50)) { 
                Ingredient i = hit.transform.GetComponent<Ingredient>();
                Book b = hit.transform.GetComponent<Book>();

                if (i != null) {
                    Cauldron c = GameObject.FindObjectOfType<Cauldron>();
                    foreach (Ingredient.effect effect in i.effects) {
                        c.addProperty(effect.symptom, effect.value);
                    }
                    Debug.Log(GameObject.FindObjectOfType<Cauldron>().ToString());
                } else if (b != null) {
                    b.toggle();
                }else if(hit.transform.tag == "Right-arrow") {
                    book.nextPage();
                }else if(hit.transform.tag == "Left-arrow") {
                    book.previousPage();
                }
            }
        }
	}
}
