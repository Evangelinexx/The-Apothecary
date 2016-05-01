using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Cauldron : MonoBehaviour {
    public const int unlikely = 25;
    public const int weak = 50;
    public const int medium = 75;
    public const int strong = 100;
    SortedDictionary<Book.symptoms, int> properties;
    
	// Use this for initialization
	void Start () {
        properties = new SortedDictionary<Book.symptoms, int>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    //remove everything from the cauldron
    public void clearProperties() {
        properties.Clear();
    }

    //add a property, or update, as needed
    public void addProperty(Book.symptoms symptom, int value) {
        if (properties.ContainsKey(symptom)) {
            updateProperty(symptom, value);
        } else {
            properties.Add(symptom, value);
        }
    }

    //private helper to update an existing property, or remove it if its effect is cancelled
    //property intensity capped at 100%
    private void updateProperty(Book.symptoms symptom, int value) {
        properties[symptom] += value;
        properties[symptom] = Math.Min(properties[symptom], strong);
        if(properties[symptom] == 0) {
            properties.Remove(symptom);
        }
    }

    //returns an array of all the symptoms in the cauldron
    public Book.symptoms[] GetSymptoms() {
        Book.symptoms[] s = new Book.symptoms[properties.Count];
        int i = 0;
        foreach(Book.symptoms symptom in properties.Keys) {
            s[i] = symptom;
            i++;
        }
        return s;//UNUSED
    }

    //returns an array of all the values associated with the symptoms in the cauldron
    public Book.symptoms[] GetValues() {
        Book.symptoms[] v = new Book.symptoms[properties.Count];
        int i = 0;
        foreach (Book.symptoms symptom in properties.Values) {
            v[i] = symptom;
            i++;
        }
        return v;//UNUSED
    }

    //returns the intesity of an int as a string
    private string getIntensity(int intensity) {
        int i = Mathf.Abs(intensity);
        if (i <= unlikely) {
            return "Unlikely";
        }else if(i <= weak) {
            return "Weak";
        }else if(i <= medium) {
            return "Medium";
        } else {
            return "Strong";
        }
    }

    //override tostring method
    public override string ToString() {
        string str = "Cauldron Properties: \n";
        foreach(Book.symptoms symptom in properties.Keys) {
            if(properties[symptom] < 0) {
                //str += Mathf.Abs(properties[symptom]).ToString() + "% chance of curing ";
                str += getIntensity(properties[symptom]) + " chance of curing ";
            } else {
                //str += Mathf.Abs(properties[symptom]).ToString() + "% chance of causing ";
                str += getIntensity(properties[symptom]) + " chance of causing ";
            }
            str += symptom.ToString()+ "\n";
        }
        return str;
    }
}
