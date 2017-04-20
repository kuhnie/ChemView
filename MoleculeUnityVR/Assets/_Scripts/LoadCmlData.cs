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

    // atomPosAry is a list of positions of each atom in the molecule
    // mapping the position of the atom based 
    List<Vector3> atomPosAry 
        = new List<Vector3>();

    List<Dictionary<string,string>> atomTypeDict 
        = new List<Dictionary<string,string>>();
    
    // bondArray is a list of all the bonds where each entry looks like
    // { ["atom_id1","atom_id2"] : "bond_order" }
    List<Dictionary<List<string>,string>> bondArray 
        = new List<Dictionary<List<string>,string>>();

    // temporary dictionaries for atoms and bonds, respectively
    Dictionary<string,string> tempDictA;

    Dictionary<List<string>,string> tempDictB;
    List<string> tempListB;

    public void Read() {

        XmlDocument CMLfile = new XmlDocument();
        CMLfile.LoadXml(CmlFile.text);

        XmlNodeList atoms = CMLfile.GetElementsByTagName("atom");
        XmlNodeList bonds = CMLfile.GetElementsByTagName("bond");


        // atoms should now be everything tagged "atom"
        foreach(XmlNode atom in atoms){

            tempDictA = new Dictionary<string,string>();
            tempDictA.Add(atom.Attributes["id"].Value,
                          atom.Attributes["elementType"].Value);

            atomPosAry.Add(new Vector3(float.Parse(atom.Attributes["x3"].Value),
                                       float.Parse(atom.Attributes["y3"].Value),
                                       float.Parse(atom.Attributes["z3"].Value)));

            atomTypeDict.Add(tempDictA);
    
        }

        // bonds is a list of everything tagged "bond"
        foreach(XmlNode bond in bonds){

            tempDictB = new Dictionary<List<string>,string>();

            tempListB = new List<string>();

            string[] atomRefs = bond.Attributes["atomRefs2"].Value.Split(null);

            tempListB.Add(atomRefs[0]);
            tempListB.Add(atomRefs[1]);

            tempDictB.Add(tempListB, bond.Attributes["order"].Value);

            bondArray.Add(tempDictB);

        }

    }

    // MOVE THIS LATER !!
    public void Generate(){

        // tempDictA - atoms { string : Vector3 }
        // tempDictB - bonds { string : string }

        // generate atoms
        for(int i = 0; i < atomPosAry.Count; i++){

            // TODO: replace with spawning a prefab
            // TODO: make these children of an empty 
            //       so it can all rotate together!
            GameObject current = 
                GameObject.CreatePrimitive(PrimitiveType.Sphere);

            // set position of the atom    
            current.transform.position = atomPosAry[i];

            if(atomTypeDict[i].First().Value == "C")
                current.GetComponent<Renderer>().material.color = Color.black;
            
            else if(atomTypeDict[i].First().Value == "O")
                current.GetComponent<Renderer>().material.color = Color.cyan;

            else if(atomTypeDict[i].First().Value == "H")
                current.GetComponent<Renderer>().material.color = Color.white;
            

            // add more to change shape and color, etc.

        }

        // generate bonds
        for(int j = 0; j < bondArray.Count; j++){

            //
            string atom1 = bondArray[j].First().Key[0];
            string atom2 = bondArray[j].First().Key[1];

            //Vector3 atom1loc =

            //Debug.Log(atom1);
            
            //float length = (atomArray)

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