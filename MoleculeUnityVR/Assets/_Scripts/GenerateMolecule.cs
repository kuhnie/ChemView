/// @file    GenerateMolecule.cs
/// @author  Thomas Bolden (boldenth@msu.edu)
/// @date    Sat Apr 15 17:08:00 EST 2017
/// @brief   Implimenting GenerateMolecule class
///
/// This class should be able to generate a 3D GameObject from a data file
/// .

/*
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Linq;

//---------------------------------------------------------------------------\\

public class LoadCmlData : MonoBehaviour {

    // public class LoadCmlData ??
    // OR
    // public gameobject(?) MoleculeSpawner

    //public GameObject HUD; // to display info about hovered over molecule
    public TextAsset  CmlFile; // file to read from

    static string ElementText; // eventually to be used for popup dialog

    // atomArray is a list of atoms in the molecule mapping the abbreviated
    // ptable name to its position
    // the order of atomArray is same as order in cml file, so index in the
    // list will reference the atom (eg. atom a2 is second in list)
    // { "Ag" : (1.0, 2.0, 1.0) }
    List<Dictionary<string,Vector3>> atomArray
        = new List<Dictionary<string,Vector3>>(); // or <Element, Vector3> ?
    
    // bondArray is a list of all the bonds where each entry looks like
    // { "bond order" : "atom1 atom2" }
    List<Dictionary<string,string>> bondArray 
        = new List<Dictionary<string,string>>();

    // MOVE THIS LATER !!
    public void Generate(){

        // tempDictA - atoms { string : Vector3 }
        // tempDictB - bonds { string : string }

        for(int i = 0; i < atomArray.Count; i++){

            GameObject current = 
                GameObject.CreatePrimitive(PrimitiveType.Sphere);

            // set position of the atom    
            current.transform.position = atomArray[i].First().Value;

            // add more to change shape and color, etc.

        }

    }

    void Start() {

        Read();
        Generate();
    
    }
    
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

    }

}
*/