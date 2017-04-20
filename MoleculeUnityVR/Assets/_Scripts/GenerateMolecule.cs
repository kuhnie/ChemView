/// @file    GenerateMolecule.cs
/// @author  Thomas Bolden (boldenth@msu.edu)
/// @date    Sat Apr 15 17:08:00 EST 2017
/// @brief   Implimenting GenerateMolecule class
///
/// This class should be able to generate a 3D GameObject from a data file
/// that is read by the Load[filetype]Data class


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Linq;

//---------------------------------------------------------------------------\\

public class GenerateMolecule : MonoBehaviour {

    // in order to make this more universal, could potentially
    // take last argument as filename and using try() to read based
    // on the extension
    // eg. Read(string filename, string filetype)
    public void Generate(Dictionary<string,Vector3> APD,
                         Dictionary<string,string> ATD,
                         List<Dictionary<List<string>,string>> BA,
                         string NAME){

        GameObject molecule = new GameObject();

        molecule.transform.localScale = new Vector3(1f,1f,1f);

        molecule.name = NAME;

        //molecule.AddComponent<BoxCollider>();

        // TODO: fix this!
        molecule.AddComponent<Rotator>();

        // generate atoms in unity
        for(int i = 0; i < APD.Count; i++){

            // TODO: make this better for different keys,
            //   OR: make other files use this format as key
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
            current.transform.position = APD[key];

            // TODO: make this better!
            // HINT: create an element class with radius and color attributes 
            //       and use it to set current.transform{scale,material.color}
            if(ATD[key] == "C"){
                current.GetComponent<Renderer>().material.color = Color.black;
                current.transform.localScale = new Vector3(.8f,.8f,.8f);
            }
            
            else if(ATD[key] == "O"){
                current.GetComponent<Renderer>().material.color = Color.cyan;
                current.transform.localScale = new Vector3(1f,1f,1f);
            }

            else if(ATD[key] == "H"){
                current.GetComponent<Renderer>().material.color = Color.white;
                current.transform.localScale = new Vector3(.5f,.5f,.5f);
            }

        }

        // generate bonds
        for(int j = 0; j < BA.Count; j++){

            string atom1 = BA[j].First().Key[0];
            string atom2 = BA[j].First().Key[1];
            
            float length = (APD[atom1] - APD[atom2]).magnitude;

            GameObject current = 
                GameObject.CreatePrimitive(PrimitiveType.Capsule);

            // again, set bond as child of molecule
            current.transform.parent = molecule.transform;

            // setting bond position to halfway between the atoms
            // using Lerp (linear interpolation)
            current.transform.position = Vector3.Lerp(APD[atom1],
                                                      APD[atom2],
                                                      0.5f);
            current.transform.localScale = new Vector3(.1f,.1f, length);

            // angling bonds
            current.transform.LookAt(APD[atom2]);
            current.GetComponent<Renderer>().material.color = Color.gray;

        }

    }
    
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

    }

}
