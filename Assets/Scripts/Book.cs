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
        foreach(Collider c in GetComponentsInChildren<Collider>()) {
            c.enabled = false;
        }
        GetComponent<Collider>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //toggle the book, open or closed
    public void toggle() {
        if (isOpen) {
            hidePage();
        }else {
            currentPage = 0;
            showPage();
        }
        isOpen = !isOpen;
    }

    //turn the page
    public void nextPage() {
        hidePage();
        currentPage++;
        showPage();
    }

    //turn the page
    public void previousPage() {
        hidePage();
        currentPage--;
        showPage();
    }

    //getter to find if the book is open
    public bool bookOpen() {
        return isOpen;
    }

    //show the current page and enable colliders
    private void showPage() {
        GameObject page = pages[currentPage];
        page.GetComponent<Renderer>().enabled = true;
        foreach(Collider c in page.GetComponentsInChildren<Collider>()) {
            c.enabled = true;
        }
    }

    //hide the current page and disable colliders
    private void hidePage() {
        GameObject page = pages[currentPage];
        page.GetComponent<Renderer>().enabled = false;
        foreach (Collider c in page.GetComponentsInChildren<Collider>()) {
            c.enabled = false;
        }
    }
}
