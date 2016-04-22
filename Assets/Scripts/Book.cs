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
        GameObject[] lefts = GameObject.FindGameObjectsWithTag("Left-arrow");
        GameObject[] rights = GameObject.FindGameObjectsWithTag("Right-arrow");
        foreach(GameObject left in lefts) {
            left.GetComponent<Collider>().enabled = false;
        }
        foreach(GameObject right in rights) {
            right.GetComponent<Collider>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void toggle() {
        if (isOpen) {
            hidePage();
        }else {
            currentPage = 0;
            showPage();
        }
        isOpen = !isOpen;
    }

    public void nextPage() {
        hidePage();
        currentPage++;
        showPage();
    }

    public void previousPage() {
        hidePage();
        currentPage--;
        showPage();
    }

    private void showPage() {
        GameObject page = pages[currentPage];
        page.GetComponent<Renderer>().enabled = true;
        foreach(Collider c in page.GetComponentsInChildren<Collider>()) {
            c.enabled = true;
        }
    }

    private void hidePage() {
        GameObject page = pages[currentPage];
        page.GetComponent<Renderer>().enabled = false;
        foreach (Collider c in page.GetComponentsInChildren<Collider>()) {
            c.enabled = false;
        }
    }
}
