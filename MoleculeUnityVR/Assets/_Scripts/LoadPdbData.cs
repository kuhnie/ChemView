/// @file    LoadPDBData.cs
/// @author	 Michael Kuhn (kuhnmic5@msu.edu)
/// @date    Fri Apr 21 12:51 EST 2017
/// @brief   Implimenting LoadPDBData class
///
/// This class should be able to load any PDB formatted file in .txt file into
/// Unity, and generate a 3D moluecule GameObject.
/// Code modified from LoadCmlData.cs, Thomas Bolden (boldenth@msu.edu)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Xml;
using System.IO;
using System;

public class loadPDBdata : MonoBehaviour {

    //public GameObject HUD; // to display info about hovered over molecule
    //public string PDBFile = @"c:\Users\kuhnie\Downloads\text.pdb"; // file to read from

    static string ElementText; // eventually to be used for popup dialog

    // atomArray is a list of atoms in the molecule mapping the abbreviated
    // ptable name to its position
    // the order of atomArray is same as order in PDB file, so index in the
    // list will reference the atom (eg. atom a2 is second in list)
    // { "Ag" : (1.0, 2.0, 1.0) }
    List<Dictionary<string, Vector3>> atomArray
        = new List<Dictionary<string, Vector3>>(); // or <Element, Vector3> ?

    // bondArray is a list of all the bonds where each entry looks like
    // { "bond order" : "atom1 atom2" }
    List<Dictionary<string, string>> bondArray
        = new List<Dictionary<string, string>>();

    // temporary dictionaries for atoms and bonds, respectively
    Dictionary<string, Vector3> tempDictA;
    Dictionary<string, string> tempDictB;
    private List<string[]> row = new List<string[]>();
    private string[] line_array = new string[1];

    void Start()
    {
        string path = @"C:\Users\kuhnie\Desktop\moleculeViewer\Assets\test_pdb.txt";
        print("Start: " + path);
        Read(path);
        //print(PDBFile);

        //Generate();

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

    }

    public void Read(string path)
    {
        using (StreamReader sr = File.OpenText(path))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                if ((line.Contains("ATOM")))
                {
                    int i = 0;
                    line_array = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                    row.Add(line_array);
                    i++;
                }
                }
            }
        for (int i = 0; i < line_array.Length; i++)
            Debug.Log(line_array[i]);
    }


    // atoms should now be everything tagged "atom"


    /*tempDictA = new Dictionary<string, Vector3>();

    tempDictA.Add(atom.Attributes["elementType"].Value,
                  new Vector3(float.Parse(atom.Attributes["x3"].Value),
                              float.Parse(atom.Attributes["y3"].Value),
                              float.Parse(atom.Attributes["z3"].Value)));

    atomArray.Add(tempDictA);

}

// bonds is a list of everything tagged "bond"
foreach (XmlNode bond in bonds)
{

    tempDictB = new Dictionary<string, string>();

    tempDictB.Add(bond.Attributes["order"].Value,
                  bond.Attributes["atomRefs2"].Value);

    bondArray.Add(tempDictB);

}

}

public void Generate()
{

// tempDictA - atoms { string : Vector3 }
// tempDictB - bonds { string : string }

}

*/
}
