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

    public string moleculeName = "Molecule"; // TODO: change to customizable!

    // atomArray is a list of atoms in the molecule mapping the abbreviated
    // ptable name to its position
    // the order of atomArray is same as order in cml file, so index in the
    // list will reference the atom (eg. atom a2 is second in list)
    // { "Ag" : (1.0, 2.0, 1.0) }

    // atomPosDict is a list of positions of each atom in the molecule
    // mapping the position of the atom based 
    Dictionary<string,Vector3> atomPosDict 
        = new Dictionary<string,Vector3>();

    List<Dictionary<string,string>> atomTypeDict 
        = new List<Dictionary<string,string>>();
    
    // bondArray is a list of all the bonds where each entry looks like
    // { ["atom_id1","atom_id2"] : "bond_order" }
    List<Dictionary<List<string>,string>> bondArray 
        = new List<Dictionary<List<string>,string>>();

    // temporary dictionaries for atoms and bonds, respectively
    Dictionary<string,string> tempBondDictA;
    //Dictionary<string,Vector3> tempPosDictA;

    Dictionary<List<string>,string> tempDictB;
    List<string> tempListB;

    public void Read() {

        XmlDocument CMLfile = new XmlDocument();
        CMLfile.LoadXml(CmlFile.text);

        XmlNodeList atoms = CMLfile.GetElementsByTagName("atom");
        XmlNodeList bonds = CMLfile.GetElementsByTagName("bond");


        // atoms should now be everything tagged "atom"
        foreach(XmlNode atom in atoms){

            tempBondDictA = new Dictionary<string,string>();
            tempBondDictA.Add(atom.Attributes["id"].Value,
                              atom.Attributes["elementType"].Value);

            //tempPosDictA = new Dictionary<string,Vector3>();

            atomPosDict.Add(atom.Attributes["id"].Value,
                              new Vector3(float.Parse(atom.Attributes["x3"].Value),
                                          float.Parse(atom.Attributes["y3"].Value),
                                          float.Parse(atom.Attributes["z3"].Value)));

            atomTypeDict.Add(tempBondDictA);
            //atomPosDict.Add(tempPosDictA);
    
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

        GameObject molecule = new GameObject();
            //GameObject.CreatePrimitive(PrimitiveType.Sphere);

        molecule.transform.localScale = new Vector3(1f,1f,1f);

        molecule.name = moleculeName;

        // TODO: fix this!
        //molecule.AddComponent<Rotator>();

        // generate atoms
        for(int i = 0; i < atomPosDict.Count; i++){

            string key = "a" + (i+1).ToString();

            // TODO: replace with spawning a prefab
            GameObject current = 
                GameObject.CreatePrimitive(PrimitiveType.Sphere);

            current.transform.parent = molecule.transform;

            // set position of the atom    
            current.transform.position = atomPosDict[key];

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
            
            float length = (atomPosDict[atom1] - atomPosDict[atom2]).magnitude;

            GameObject current = 
                GameObject.CreatePrimitive(PrimitiveType.Capsule);

            current.transform.parent = molecule.transform;

            current.transform.position = Vector3.Lerp(atomPosDict[atom1],
                                                      atomPosDict[atom2],
                                                      0.5f);
            current.transform.localScale = new Vector3(.1f,.1f, length);
            current.transform.LookAt(atomPosDict[atom2]);
            current.GetComponent<Renderer>().material.color = Color.gray;

        }

    }

    void Start() {

        Read();
        Generate();
    
    }
    
    void Update() {

        // rotating the molecule
        // in VR, this should somehow work with the VR sticks/controllers

        //GameObject molecule = GameObject.Find(moleculeName);

        //molecule.transform.Rotate(0,20*Time.deltaTime,0);

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

    }

}