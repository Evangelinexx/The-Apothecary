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

    //toggle the book, open or closed, enable/disable arrows
    public void toggle() {
        if (isOpen) {
            hidePage();
            foreach (Collider c in GetComponentsInChildren<Collider>()) {
                c.enabled = false;
            }
            GetComponent<Collider>().enabled = true;//book collider should always be enabled
        } else {
            currentPage = 0;
            showPage();
            foreach (Collider c in GetComponentsInChildren<Collider>()) {
                c.enabled = true;
            }
        }
        isOpen = !isOpen;
    }

    //turn the page if there is a next page
    public void nextPage() {
        hidePage();
        if (currentPage + 1 < pages.Length) {
            currentPage++;
        }
        showPage();
    }

    //turn the page if there is a previous page
    public void previousPage() {
        hidePage();
        if (currentPage - 1 >= 0) {
            currentPage--;
        }
        showPage();
    }

    //getter to find if the book is open
    public bool bookOpen() {
        return isOpen;
    }

    //show the current page
    private void showPage() {
        GameObject page = pages[currentPage];
        page.GetComponent<Renderer>().enabled = true;
    }

    //hide the current page
    private void hidePage() {
        GameObject page = pages[currentPage];
        page.GetComponent<Renderer>().enabled = false;
    }
}
