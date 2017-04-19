/// @file    LoadCmlData.cs
/// @author  Thomas Bolden (boldenth@msu.edu)
/// @date    Sat Apr 15 17:08:00 EST 2017
/// @brief   Implimenting LoadCmlData class
///
/// This class should be able to load any chemical markup (.cml) file into
/// Unity, and generate a 3D moluecule GameObject.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

//---------------------------------------------------------------------------\\

public class LoadCmlData : MonoBehaviour {

	public GameObject HUD; // to display info about hovered over molecule
	public TextAsset  CmlFile; // file to read from

    static string ElementText; // eventually to be used for popup dialog

    // atomArray is a list of atoms in the molecule mapping the abbreviated
    // ptable name to its position
    // the order of atomArray is same as order in cml file, so index in the list
    // will reference the atom (eg. atom a2 is second in list)
    // { "Ag" : (1.0, 2.0, 1.0) }
    List<Dictionary<string,Vector3>> atomArray
        = new List<Dictionary<string,Vector3>>(); // or <Element, Vector3> ?
	
    // bondArray is a list of all the bonds where each entry looks like
    // { "bond type" : { "atom 1" : "atom 2" } }
    List<Dictionary<string,Dictionary<string,string>>> bondArray 
        = new List<Dictionary<string,string>>();

    // temporary dictionaries for atoms and bonds, respectively
	Dictionary<string,Vector3> tempDictA;
    Dictionary<string,Dictionary<string,string>> tempDictB;

    public void Read() {

        XmlDocument CMLfile = new XmlDocument();
        CMLfile.LoadXml(CmlFile.text);

        XmlNodeList atoms = CMLfile.GetElementsByTagName("atomArray");
        XmlNodeList bonds = CMLfile.GetElementsByTagName("bondArray");

        // should loop and get attributes for every "atom" under atomArray
        foreach (XmlNode atom in atoms){

            tempDictA = new Dictionary<string,string>();

            atomArray.Add(tempDictA);

        }

        // loops through each item with "bond" tag under bondArray
        foreach (XmlNode bond in bonds){
            
        }

    }

    void Start() {

        Read();
    
    }
	
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

    }

}