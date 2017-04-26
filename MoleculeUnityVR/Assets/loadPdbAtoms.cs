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
using System.Linq;
using System;

public class LoadPdbData : MonoBehaviour
{

    //public GameObject HUD; // to display info about hovered over molecule

    static string ElementText; // eventually to be used for popup dialog

    public string path;

    // temporary dictionaries for atoms and bonds, respectively
    Dictionary<string, Vector3> tempDictA;
    Dictionary<List<string>, string> tempDictB;
    //private List<string> row = new List< string> ();
    private string[] atom_array = new string[16];
    private string[] bond_array = new string[6];
    private List<string> line_ls = new List<string>();
    private string[][] row_array;
    
    private Vector3 atom_pos;
    private int a_count = 1;
    private int b_count = 0;
    private string id;
    List<string> tempListB;

    public Dictionary<string, Vector3> atomPosDict 
        = new Dictionary<string, Vector3>();
    public Dictionary<string, string> atomTypeDict 
        = new Dictionary<string, string>();
    public List<Dictionary<List<string>, string>> bondArray
        = new List<Dictionary<List<string>, string>>();
    string moleculeName;

    void Start()
    {
        
        print("Start: " + path);
        GetComponent<PeriodicTable>().CreateTable();
        Read(path);
        GetComponent<GenerateMolecule>().
            Generate(atomPosDict, atomTypeDict, bondArray, moleculeName);

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
            //Reads the txt file
            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                //if ((line.StartsWith("CONECT")))
                //{
                //    int v = 0;
                //    //Record name "CONECT"
                //    line_ls.Add(line.Substring(v, 6).Trim());
                //    v += 6;
                //    //Atom 1
                //    line_ls.Add(line.Substring(v, 5).Trim());
                //    v += 5;
                //    if (line.Length > v)
                //    {
                //        //Atom 2
                //        line_ls.Add(line.Substring(v, 5).Trim());
                //        v += 5;
                //        if (line.Length > v)
                //        {
                //            //Atom 3
                //            line_ls.Add(line.Substring(v, 5).Trim());
                //            v += 5;
                //            if (line.Length > v)
                //            {
                //                //Atom 4
                //                line_ls.Add(line.Substring(v, 5).Trim());
                //                v += 5;
                //                //Atom 5
                //                if (line.Length > v)
                //                    line_ls.Add(line.Substring(v, 5).Trim());
                //                //v += 5;
                //            }
                //        }
                //    }
                //    bond_array = line_ls.ToArray();

                //    int bond_int = 1;

                //    foreach (string bond in bond_array)
                //    {

                //        tempListB = new List<string>();
                //        tempDictB = new Dictionary<List<string>, string>();
                //        //int bond_int = 0;
                //        //Debug.Log(bond_array[bond_int]);
                //        if (bond_int <= bond.Length && bond_array[bond_int] != "0") {

                //            tempListB.Add("a"+bond_array[1]);
                //            tempListB.Add("a"+bond_array[bond_int]);

                //            tempDictB.Add(tempListB, "Order");
                //            bondArray.Add(tempDictB);
                //            bond_int++;

                //        }
                        
                        
                //    }


                //    b_count++;
                //    /*for (int item =0;item < bond_array.Length; item++)
                //    {
                //        Debug.Log(bond_array[item]);
                //    }*/

                //    line_ls.Clear();
                //}
                //else 
                if (line.StartsWith("ATOM"))
                {
                    int v = 0;
                    //0: Record Name "ATOM"
                    line_ls.Add(line.Substring(v, 6).Trim());
                    v += 6;
                    //1: Serial Number
                    line_ls.Add(line.Substring(v, 5).Trim());
                    v += 5;
                    //2: Atom Name
                    line_ls.Add(line.Substring(v, 5).Trim());
                    v += 5;
                    //3: Alternate Location Indicator
                    line_ls.Add(line.Substring(v, 1).Trim());
                    v += 1;
                    //4: Residue name
                    line_ls.Add(line.Substring(v, 3).Trim());
                    v += 3;
                    //5: Chain Identifier
                    line_ls.Add(line.Substring(v, 1).Trim());
                    v += 1;
                    //6: Residue Sequence Number
                    line_ls.Add(line.Substring(v, 4).Trim());
                    v += 4;
                    //7: Code for insertion of residues
                    line_ls.Add(line.Substring(v, 1).Trim());
                    v += 1;
                    //8: X coord
                    line_ls.Add(line.Substring(v, 12).Trim());
                    v += 12;
                    //9: Y coord
                    line_ls.Add(line.Substring(v, 8).Trim());
                    v += 8;
                    //10: Z coord
                    line_ls.Add(line.Substring(v, 8).Trim());
                    v += 8;
                    //11: Occupancy
                    line_ls.Add(line.Substring(v, 7).Trim());
                    v += 7;
                    //12: Tempature factor
                    line_ls.Add(line.Substring(v, 6).Trim());
                    v += 6;
                    //13: Element Symbol
                    line_ls.Add(line.Substring(v, 11).Trim());
                    v += 11;
                    //14: Charge
                    line_ls.Add(line.Substring(v, 2).Trim());

                    //Make array
                    atom_array = line_ls.ToArray();
                    //Debug.Log(atom_array[8] + " " + atom_array[9] + " " + atom_array[10]);
                    atom_pos = new Vector3(float.Parse(atom_array[8]), 
                                           float.Parse(atom_array[9]), 
                                           float.Parse(atom_array[10]));
                    id = "a" + a_count.ToString();
                    atomTypeDict.Add(id, atom_array[13]);
                    atomPosDict.Add(id, atom_pos);
                    line_ls.Clear();
                    a_count++;
                }
                else if (line.Contains("HEADER"))
                {
                    moleculeName = line.Substring(6, line.Length-7).Trim();
                }
            }

            /* Debug for above outputs
            Debug.Log("Molecule Name: " + moleculeName);
            foreach (var atom in atomPosDict)
                Debug.Log("Key: " + atom.Key + "\nValue: "+ atom.Value);
            bondArray.ForEach(x => 
            {
                foreach (var bond in x.Keys)
                {
                    Debug.Log("foreach(var bond in x)");
                    bond.ForEach(y => 
                    {
                        Debug.Log("bond.Key.ForEach(y");
                        Debug.Log(y);
                    });
                }
            });*/
            
            //row_array = row.ToArray();
        }
    }
}
