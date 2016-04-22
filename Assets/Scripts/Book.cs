using UnityEngine;
using System.Collections;

public class Book : MonoBehaviour {
    public enum symptoms {coughing, hayfever, rash, sniffles, vomiting};
    [SerializeField] GameObject[] pages;
    int currentPage;
    bool isOpen;

    // Use this for initialization
    void Start () {
        isOpen = false;
        foreach(GameObject page in pages) {
            page.GetComponent<Renderer>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void toggle() {
        if (isOpen) {
            hideBook();
        }else {
            currentPage = 0;
            showBook();
        }
        isOpen = !isOpen;
    }

    private void showBook() {
        pages[currentPage].GetComponent<Renderer>().enabled = true;
    }

    private void hideBook() {
        pages[currentPage].GetComponent<Renderer>().enabled = false;
    }
}
