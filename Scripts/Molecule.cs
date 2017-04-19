[System.Serializable]

using System.IO;
using UnityEngine;
using System.Collections;

public class Molecule : MonoBehaviour {

    public class Element{

        public string name_;
        public int    atomic_number_;
        public double atomic_mass_;
        public int    radius_;
        public int    valence_electrons_;

    }

}