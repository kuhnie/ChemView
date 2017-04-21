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

    // TODO: currently needs to be plain text file, can I make it read .cml ?
    public TextAsset  CmlFile; // file to read from

    static string ElementText; // eventually to be used for popup dialog

    public string moleculeName = "Molecule"; // TODO: change to customizable!
                                             // or read from cml

    // atomPosDict is a dict of all atoms in the molecule
    // the keys are the atom id, values are Vector3 position
    // eg. { "a1" : (1.1, 1.2, 1.3) }
    public Dictionary<string,Vector3> atomPosDict 
        = new Dictionary<string,Vector3>();

    // atomTypeDict is a dict of all atoms in the molecule
    // keys are same id as above, but value is now the element
    // eg. { "a2" : "Ag" } if the second element was gold
    public Dictionary<string,string> atomTypeDict 
        = new Dictionary<string,string>();
    
    // bondArray is a list of all the bonds where each entry looks like
    // { ["atom_id1","atom_id2"] : "bond_order" }
    public List<Dictionary<List<string>,string>> bondArray 
        = new List<Dictionary<List<string>,string>>();

    // temporary containers for bonds
    Dictionary<List<string>,string> tempDictB;
    List<string>                    tempListB;

    public void Read() {

        XmlDocument CMLfile = new XmlDocument();
        CMLfile.LoadXml(CmlFile.text);

        //moleculeName = CMLfile.GetElementsByTagName("name").InnerText;

        //XmlNodeList names = CMLfile.GetElementsByTagName("name");
        XmlNodeList atoms = CMLfile.GetElementsByTagName("atom");
        XmlNodeList bonds = CMLfile.GetElementsByTagName("bond");

        //foreach(XmlNode name in names){

        //    moleculeName = name.InnerText;

        //}

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

    // currently only suppports using one kind of file extension
    // and needs to be manually dragged onto the MoleculeSpawner
    // TODO: automatically do this based on a screen selection on
    //       game start (one option, open to suggestions)
    void Start(){

        GetComponent<PeriodicTable>().CreateTable();
        Read();
        GetComponent<GenerateMolecule>().
        Generate(atomPosDict, atomTypeDict, bondArray, moleculeName);

    }
    
    void Update(){

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

    }

}