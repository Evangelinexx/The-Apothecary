using UnityEngine;
using System.Collections;

public class CameraClick : MonoBehaviour {
    private Book book;
    private Shelf shelf;
    private Cauldron cauldron;
	// Use this for initialization
	void Start () {
        book = FindObjectOfType<Book>();
        shelf = FindObjectOfType<Shelf>();
        cauldron = FindObjectOfType<Cauldron>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;

            if(Physics.Raycast(GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit, 50)) { 
                Ingredient i = hit.transform.GetComponent<Ingredient>();
                Book b = hit.transform.GetComponent<Book>();

                if (i != null) {//Clicked on an ingredient
                    foreach (Ingredient.effect effect in i.effects) {
                        cauldron.addProperty(effect.symptom, effect.value);
                    }
                    Debug.Log(cauldron.ToString());//DEBUG STRING OUTPUT
                } else if (b != null) {//clicked the book
                    book.toggle();
                    if (book.bookOpen()) {
                        shelf.turnOffColliders();
                    } else {
                        shelf.turnOnColliders();
                    }
                }else if(hit.transform.tag == "Right-arrow") {//clicked a right arrow
                    book.nextPage();
                }else if(hit.transform.tag == "Left-arrow") {//clocked a left arrow
                    book.previousPage();
                }
            }
        }
	}
}
