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
using System.Linq;

//---------------------------------------------------------------------------\\

public class LoadCmlData : MonoBehaviour {

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
    // TODO: consider changing this to dict like so:
    // { "ref number" : ("type", (x,y,z) ) }
    
    // bondArray is a list of all the bonds where each entry looks like
    // { "bond order" : "atom1 atom2" }
    List<Dictionary<string,string>> bondArray 
        = new List<Dictionary<string,string>>();

    // temporary dictionaries for atoms and bonds, respectively
    Dictionary<string,Vector3> tempDictA;
    Dictionary<string,string> tempDictB;

    public void Read() {

        XmlDocument CMLfile = new XmlDocument();
        CMLfile.LoadXml(CmlFile.text);

        XmlNodeList atoms = CMLfile.GetElementsByTagName("atom");
        XmlNodeList bonds = CMLfile.GetElementsByTagName("bond");


        // atoms should now be everything tagged "atom"
        foreach(XmlNode atom in atoms){

            tempDictA = new Dictionary<string,Vector3>();

            tempDictA.Add(atom.Attributes["elementType"].Value
                          + atom.Attributes["id"].Value,
                          new Vector3(float.Parse(atom.Attributes["x3"].Value),
                                      float.Parse(atom.Attributes["y3"].Value),
                                      float.Parse(atom.Attributes["z3"].Value)));

            atomArray.Add(tempDictA);
    
        }

        // bonds is a list of everything tagged "bond"
        foreach(XmlNode bond in bonds){

            tempDictB = new Dictionary<string,string>();

            tempDictB.Add(bond.Attributes["order"].Value,
                          bond.Attributes["atomRefs2"].Value);

            bondArray.Add(tempDictB);

        }

    }

    // MOVE THIS LATER !!
    public void Generate(){

        // tempDictA - atoms { string : Vector3 }
        // tempDictB - bonds { string : string }

        for(int i = 0; i < atomArray.Count; i++){

            GameObject current = 
                GameObject.CreatePrimitive(PrimitiveType.Sphere);

            // set position of the atom    
            current.transform.position = atomArray[i].First().Value;

            if(atomArray[i].First().Key.StartsWith("C"))
                current.GetComponent<Renderer>().material.color = Color.black;
            
            else if(atomArray[i].First().Key.StartsWith("O"))
                current.GetComponent<Renderer>().material.color = Color.cyan;
            

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