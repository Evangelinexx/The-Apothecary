using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Cauldron : MonoBehaviour {
    SortedDictionary<Book.symptoms, int> properties;
    
	// Use this for initialization
	void Start () {
        properties = new SortedDictionary<Book.symptoms, int>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void clearProperties() {
        properties.Clear();
    }

    public void addProperty(Book.symptoms symptom, int value) {
        if (properties.ContainsKey(symptom)) {
            updateProperty(symptom, value);
        } else {
            properties.Add(symptom, value);
        }
    }

    private void updateProperty(Book.symptoms symptom, int value) {
        properties[symptom] += value;
        if(properties[symptom] == 0) {
            properties.Remove(symptom);
        }
    }

    public Book.symptoms[] GetSymptoms() {
        Book.symptoms[] s = new Book.symptoms[properties.Count];
        int i = 0;
        foreach(Book.symptoms symptom in properties.Keys) {
            s[i] = symptom;
            i++;
        }
        return s;
    }
    public Book.symptoms[] GetValues() {
        Book.symptoms[] v = new Book.symptoms[properties.Count];
        int i = 0;
        foreach (Book.symptoms symptom in properties.Values) {
            v[i] = symptom;
            i++;
        }
        return v;
    }

    public override string ToString() {
        string str = "Cauldron Properties: \n";
        foreach(Book.symptoms symptom in properties.Keys) {
            if(properties[symptom] < 0) {
                str += Mathf.Abs(properties[symptom]).ToString() + "% chance of curing ";
            } else {
                str += Mathf.Abs(properties[symptom]).ToString() + "% chance of causing ";
            }
            str += symptom.ToString()+ "\n";
        }
        return str;
    }
}
