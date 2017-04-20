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

    // TODO: add support to read properties -> assign to molecule parent obj

    //public GameObject HUD; // TODO: display info about hovered over molecule
    public TextAsset  CmlFile; // file to read from

    static string ElementText; // eventually to be used for popup dialog

    public string moleculeName = "Molecule"; // TODO: change to customizable!
                                             // or read from cml

    // atomPosDict is a dict of all atoms in the molecule
    // the keys are the atom id, values are Vector3 position
    // eg. { "a1" : (1.1, 1.2, 1.3) }
    Dictionary<string,Vector3> atomPosDict 
        = new Dictionary<string,Vector3>();

    // atomTypeDict is a dict of all atoms in the molecule
    // keys are same id as above, but value is now the element
    // eg. { "a2" : "Ag" } if the second element was gold
    Dictionary<string,string> atomTypeDict 
        = new Dictionary<string,string>();
    
    // bondArray is a list of all the bonds where each entry looks like
    // { ["atom_id1","atom_id2"] : "bond_order" }
    List<Dictionary<List<string>,string>> bondArray 
        = new List<Dictionary<List<string>,string>>();

    // temporary containers for bonds
    Dictionary<List<string>,string> tempDictB;
    List<string>                    tempListB;

    public void Read() {

        XmlDocument CMLfile = new XmlDocument();
        CMLfile.LoadXml(CmlFile.text);

        XmlNodeList atoms = CMLfile.GetElementsByTagName("atom");
        XmlNodeList bonds = CMLfile.GetElementsByTagName("bond");

        // atoms should now be everything tagged "atom"
        foreach(XmlNode atom in atoms){

            atomTypeDict.Add(atom.Attributes["id"].Value,
                             atom.Attributes["elementType"].Value);

            atomPosDict.Add(atom.Attributes["id"].Value,
                            new Vector3(float.Parse(atom.Attributes["x3"].Value),
                                        float.Parse(atom.Attributes["y3"].Value),
                                        float.Parse(atom.Attributes["z3"].Value)));
    
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

    // TODO: move this to separate class so generation 
    //       works with other data files
    public void Generate(){

        GameObject molecule = new GameObject();

        molecule.transform.localScale = new Vector3(1f,1f,1f);

        molecule.name = moleculeName;

        //molecule.AddComponent<BoxCollider>();

        // TODO: fix this!
        molecule.AddComponent<Rotator>();

        // generate atoms in unity
        for(int i = 0; i < atomPosDict.Count; i++){

            string key = "a" + (i+1).ToString();

            // TODO: replace with spawning a prefab
            // TODO: add support for non-single bonds
            GameObject current = 
                GameObject.CreatePrimitive(PrimitiveType.Sphere);

            // TODO: add hoverablility support
            // current.AddComponent<BoxCollider>(); potentially?

            // set GameObject to be child of the larger molecule
            current.transform.parent = molecule.transform;

            // set position of the atom    
            current.transform.position = atomPosDict[key];

            // TODO: make this better!
            // HINT: create an element class with radius and color attributes 
            //       and use it to set current.transform{scale,material.color}
            if(atomTypeDict[key] == "C"){
                current.GetComponent<Renderer>().material.color = Color.black;
                current.transform.localScale = new Vector3(.8f,.8f,.8f);
            }
            
            else if(atomTypeDict[key] == "O"){
                current.GetComponent<Renderer>().material.color = Color.cyan;
                current.transform.localScale = new Vector3(1f,1f,1f);
            }

            else if(atomTypeDict[key] == "H"){
                current.GetComponent<Renderer>().material.color = Color.white;
                current.transform.localScale = new Vector3(.5f,.5f,.5f);
            }

        }

        // generate bonds
        for(int j = 0; j < bondArray.Count; j++){

            string atom1 = bondArray[j].First().Key[0];
            string atom2 = bondArray[j].First().Key[1];
            
            float length = (atomPosDict[atom1] - atomPosDict[atom2]).magnitude;

            GameObject current = 
                GameObject.CreatePrimitive(PrimitiveType.Capsule);

            // again, set bond as child of molecule
            current.transform.parent = molecule.transform;

            // setting bond position to halfway between the atoms
            // using Lerp (linear interpolation)
            current.transform.position = Vector3.Lerp(atomPosDict[atom1],
                                                      atomPosDict[atom2],
                                                      0.5f);
            current.transform.localScale = new Vector3(.1f,.1f, length);

            // angling bonds
            current.transform.LookAt(atomPosDict[atom2]);
            current.GetComponent<Renderer>().material.color = Color.gray;

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