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

        // TODO: fix this -- see Cholesterol molecule example, off scale
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

            // instantiates an Element
            PeriodicTable.Element el 
                = GetComponent<PeriodicTable>().elementMap[ATD[key]];

            // for the radius of the sphere
            float scale = (float)el.radius_ / 100f;

            if     (el.group_ == 0){ // Hydrogen - WHITE
                current.GetComponent<Renderer>().material.color 
                    = new Color32(255, 255, 255, 255);
                current.transform.localScale = new Vector3(scale,scale,scale);
            }

            else if(el.group_ == 1){ // Alkali Metals - VIOLET
                current.GetComponent<Renderer>().material.color 
                    = new Color32(138, 43, 226, 255);
                current.transform.localScale = new Vector3(scale,scale,scale);
            }

            else if(el.group_ == 2){ // Alkaline Earth Metals - DARK GREEN
                current.GetComponent<Renderer>().material.color 
                    = new Color32(0, 119, 13, 255);
                current.transform.localScale = new Vector3(scale,scale,scale);
            }

            else if(el.group_ == 3){ // Metalloids - PEACH
                current.GetComponent<Renderer>().material.color 
                    = new Color32(255, 218, 185, 255);
                current.transform.localScale = new Vector3(scale,scale,scale);
            }

            else if(el.group_ == 4){ // Misc. nonmetals - Varying
                if     (el.name_ == "Carbon"){
                    current.GetComponent<Renderer>().material.color 
                        = new Color32(0, 0, 0, 255); // BLACK
                    current.transform.localScale 
                        = new Vector3(scale,scale,scale);
                }
                else if(el.name_ == "Oxygen"){
                    current.GetComponent<Renderer>().material.color 
                        = new Color32(0, 191, 255, 255); // SKY BLUE
                    current.transform.localScale 
                        = new Vector3(scale,scale,scale);
                }
                else if(el.name_ == "Nitrogen"){
                    current.GetComponent<Renderer>().material.color 
                        = new Color32(255, 0, 0, 255); // RED
                    current.transform.localScale 
                        = new Vector3(scale,scale,scale);
                }
                else if(el.name_ == "Phosphorus"){
                    current.GetComponent<Renderer>().material.color 
                        = new Color32(255, 127, 0, 255); // ORANGE
                    current.transform.localScale 
                        = new Vector3(scale,scale,scale);
                }
                else if(el.name_ == "Sulfur"){
                    current.GetComponent<Renderer>().material.color 
                        = new Color32(255, 255, 0, 255); // YELLOW
                    current.transform.localScale 
                        = new Vector3(scale,scale,scale);
                }
                else if(el.name_ == "Selenium"){
                    current.GetComponent<Renderer>().material.color 
                        = new Color32(255, 215, 0, 255); // GOLD
                    current.transform.localScale 
                        = new Vector3(scale,scale,scale);
                }
            }

            else if(el.group_ == 5){ // Transition Metals - SALMON
                current.GetComponent<Renderer>().material.color 
                    = new Color32(250, 128, 114, 255);
                current.transform.localScale = new Vector3(scale,scale,scale);
            }

            else if(el.group_ == 6){ // Post-Transition Metals - GRAY
                current.GetComponent<Renderer>().material.color 
                    = new Color32(112, 128, 144, 255);
                current.transform.localScale = new Vector3(scale,scale,scale);
            }

            else if(el.group_ == 7){ // Halogens - LIME GREEN 
                current.GetComponent<Renderer>().material.color 
                    = new Color32(0, 255, 0, 255);
                current.transform.localScale = new Vector3(scale,scale,scale);
            }

            else if(el.group_ == 8){ // Noble Gases - CYAN
                current.GetComponent<Renderer>().material.color 
                    = new Color32(0, 255, 255, 255);
                current.transform.localScale = new Vector3(scale,scale,scale);
            }

            else if(el.group_ == 9 || el.group_ == 10){ // *noids - PINK
                current.GetComponent<Renderer>().material.color 
                    = new Color32(255, 20, 147, 255);
                current.transform.localScale = new Vector3(scale,scale,scale);
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

}
