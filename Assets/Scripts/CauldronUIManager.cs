using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CauldronUIManager : MonoBehaviour {
    [SerializeField] Text cauldronProperties;
    Cauldron cauldron;
    // Use this for initialization
    void Start() {
        cauldron = FindObjectOfType<Cauldron>();
    }

    // Update is called once per frame
    void Update () {
        cauldronProperties.text = cauldron.ToString();
	}
}
