/// @file    PeriodicTable.cs
/// @author  Thomas Bolden (boldenth@msu.edu)
/// @date    Thu Apr 20 19:03:00 EST 2017
/// @brief   Implimenting Element class
///
/// Should create a bunch of Element instances

//---------------------------------------------------------------------------\\

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine.UI;

public class PeriodicTable : MonoBehaviour {

    public class Element {

        public string name_;
        public double atomic_mass_;
        public int    radius_;
        public int    group_;
        public int    atomic_number_;

        // Default Constructor
        public Element(){
            
            name_ =          "Unknown";
            group_ =         1;
            atomic_mass_ =   0.0;
            atomic_number_ = 0;
            radius_ =        1;

        }

        // Explicit Constructor
        public Element(string name, double mass, int rad, int grp, int num){

            name_ =          name;
            group_ =         grp;
            atomic_mass_ =   mass;
            atomic_number_ = num;
            radius_ =        rad;

        }

    }

    public Element H, Li, Na, K, Rb, Cs, Fr,
                   Be, Mg, Ca, Sr, Ba, Ra,
                   B, Si, Ge, As, Sb, Te, Po,
                   C, N, O, P, S, Se,
                   F, Cl, Br, I, At,
                   He, Ne, Ar, Kr, Xe, Rn,
                   Sc, Ti, V, Cr, Mn, Fe, Co, Ni, Cu, Zn, 
                        Y, Zr, Nb, Mo, Tc, Ru, Rh, Pd, Ag, Cd, 
                        Hf, Ta, W, Re, Os, Ir, Pt, Au, Hg,
                   Al, Ga, In, Sn, Tl, Pb, Bi,
                   La, Ce, Pr, Nd, Pm, Sm, Eu, Gd, Tb, Dy, Ho, Er, Tm, Yb, Lu,
                   Ac, Th, Pa, U, Np, Pu, Am, Cm, Bk, Cf, Es, Fm, Md, No, Lr;

    public Dictionary<string,Element> elementMap;

    // creates most of the elements on the periodic table
    // TODO: fix some of the larger radii (>>200)
    public void CreateTable(){

        // Hydrogen
        H  = new Element("Hydrogen",     1.008000, 53,  0, 1);

        // Alkali Metals
        Li = new Element("Lithium",      6.940000, 167, 1, 3);
        Na = new Element("Sodium",       22.98976, 190, 1, 11);
        K  = new Element("Potassium",    39.09830, 243, 1, 19);
        Rb = new Element("Rubidium",     85.46780, 265, 1, 37);
        Cs = new Element("Caesium",      132.9054, 298, 1, 55);
        Fr = new Element("Francium",     223.0000, 320, 1, 87);

        // Alkaline Earth Metals
        Be = new Element("Beryllium",    9.012182, 112, 2, 4);
        Mg = new Element("Magnesium",    24.30500, 145, 2, 12);
        Ca = new Element("Calcium",      40.07800, 194, 2, 20);
        Sr = new Element("Strontium",    87.62000, 219, 2, 38);
        Ba = new Element("Barium",       137.3270, 253, 2, 56);
        Ra = new Element("Radium",       226.0000, 275, 2, 88);

        // Metalloids
        B  = new Element("Boron",        10.81000, 87,  3, 5);
        Si = new Element("Silicon",      28.08500, 111, 3, 14);
        Ge = new Element("Germanium",    72.63000, 125, 3, 32);
        As = new Element("Arsenic",      74.92160, 114, 3, 33);
        Sb = new Element("Antimony",     121.7600, 133, 3, 51);
        Te = new Element("Tellurium",    127.6000, 123, 3, 52);
        Po = new Element("Polonium",     209.0000, 135, 3, 84);

        // Misc. Nonmetals
        C  = new Element("Carbon",       12.01100, 67,  4, 6);
        N  = new Element("Nitrogen",     14.00700, 56,  4, 7);
        O  = new Element("Oxygen",       15.99900, 48,  4, 8);
        P  = new Element("Phosphorus",   30.97376, 98,  4, 15);
        S  = new Element("Sulfur",       32.06000, 88,  4, 16);
        Se = new Element("Selenium",     78.96000, 103, 4, 34);

        // Halogens
        F  = new Element("Fluorine",     18.99840, 42,  7, 9);
        Cl = new Element("Chlorine",     35.45000, 79,  7, 17);
        Br = new Element("Bromine",      79.90400, 94,  7, 35);
        I  = new Element("Iodine",       126.9044, 115, 7, 53);
        At = new Element("Astatine",     210.0000, 127, 7, 85);

        // Noble Gases
        He = new Element("Helium",       4.002602, 31,  8, 2);
        Ne = new Element("Neon",         20.17970, 38,  8, 10);
        Ar = new Element("Argon",        39.94800, 71,  8, 18);
        Kr = new Element("Krypton",      83.79800, 88,  8, 36);
        Xe = new Element("Xenon",        131.2930, 108, 8, 54);
        Rn = new Element("Radon",        222.0000, 120, 8, 86);

        // Transition Metals
        Sc = new Element("Scandium",     44.95591, 184, 5, 21);
        Ti = new Element("Titanium",     47.86700, 176, 5, 22);
        V  = new Element("Vanadium",     50.94150, 171, 5, 23);
        Cr = new Element("Chromium",     51.99610, 166, 5, 24);
        Mn = new Element("Manganese",    54.93804, 161, 5, 25);
        Fe = new Element("Iron",         55.84500, 156, 5, 26);
        Co = new Element("Cobalt",       58.93319, 152, 5, 27);
        Ni = new Element("Nickel",       58.69340, 149, 5, 28);
        Cu = new Element("Copper",       63.54600, 145, 5, 29);
        Zn = new Element("Zinc",         65.38000, 142, 5, 30);
        Y  = new Element("Yttrium",      88.90585, 212, 5, 31);
        Zr = new Element("Zirconium",    91.22400, 206, 5, 32);
        Nb = new Element("Niobium",      92.90638, 198, 5, 33);
        Mo = new Element("Molybdenum",   95.96000, 190, 5, 34);
        Tc = new Element("Technetium",   98.00000, 183, 5, 35);
        Ru = new Element("Ruthenium",    101.0700, 178, 5, 36);
        Rh = new Element("Rhodium",      102.9055, 173, 5, 37);
        Pd = new Element("Palladium",    106.4200, 169, 5, 38);
        Ag = new Element("Silver",       107.8682, 165, 5, 39);
        Cd = new Element("Cadmium",      112.4110, 161, 5, 48);
        Hf = new Element("Hafnium",      178.4900, 208, 5, 72);
        Ta = new Element("Tantalum",     180.9478, 200, 5, 73);
        W  = new Element("Tungsten",     183.8400, 193, 5, 74);
        Re = new Element("Rhenium",      186.2070, 188, 5, 75);
        Os = new Element("Osmium",       190.2300, 185, 5, 76);
        Ir = new Element("Iridium",      192.2170, 180, 5, 77);
        Pt = new Element("Platinum",     195.0840, 177, 5, 78);
        Au = new Element("Gold",         196.9665, 174, 5, 79);
        Hg = new Element("Mercury",      200.5900, 171, 5, 80);

        // Post-Transition Metals
        Al = new Element("Aluminum",     26.98153, 118, 6, 13);
        Ga = new Element("Gallium",      69.72300, 136, 6, 31);
        In = new Element("Indium",       114.8180, 156, 6, 49);
        Sn = new Element("Tin",          118.7100, 145, 6, 50);
        Tl = new Element("Thallium",     204.3800, 156, 6, 81);
        Pb = new Element("Lead",         207.2000, 154, 6, 82);
        Bi = new Element("Bismuth",      208.9804, 143, 6, 83);

        // Lanthanoids
        La = new Element("Lanthanum",    138.9054, 1,   9, 57);
        Ce = new Element("Cerium",       140.1160, 1,   9, 58);
        Pr = new Element("Praseodymium", 140.9076, 247, 9, 59);
        Nd = new Element("Neodymium",    144.2420, 206, 9, 60);
        Pm = new Element("Promethium",   145.0000, 205, 9, 61);
        Sm = new Element("Samarium",     150.3600, 238, 9, 62);
        Eu = new Element("Europium",     151.9640, 231, 9, 63);
        Gd = new Element("Gadolinium",   157.2500, 233, 9, 64);
        Tb = new Element("Terbium",      158.9253, 225, 9, 65);
        Dy = new Element("Dysprosium",   162.5000, 228, 9, 66);
        Ho = new Element("Holmium",      164.9303, 226, 9, 67);
        Er = new Element("Erbium",       167.2590, 226, 9, 68);
        Tm = new Element("Thulium",      168.9342, 222, 9, 69);
        Yb = new Element("Ytterbium",    173.0540, 222, 9, 70);
        Lu = new Element("Lutetium",     174.9668, 217, 9, 71);

        // Actinoids
        Ac = new Element("Actinium",     227.0000, 195, 10, 89);
        Th = new Element("Thorium",      232.0380, 180, 10, 90);
        Pa = new Element("Protactinium", 231.0358, 180, 10, 91);
        U  = new Element("Uranium",      238.0289, 175, 10, 92);
        Np = new Element("Neptunium",    237.0000, 175, 10, 93);
        Pu = new Element("Plutonium",    244.0000, 175, 10, 94);
        Am = new Element("Americium",    243.0000, 175, 10, 95);
        Cm = new Element("Curium",       247.0000, 172, 10, 96);
        Bk = new Element("Berkelium",    247.0000, 172, 10, 97);
        Cf = new Element("Californium",  251.0000, 170, 10, 98);
        Es = new Element("Einsteinium",  252.0000, 169, 10, 99);
        Fm = new Element("Fermium",      257.0000, 165, 10, 100);
        Md = new Element("Mendelevium",  258.0000, 164, 10, 101);
        No = new Element("Nobelium",     259.0000, 163, 10, 102);
        Lr = new Element("Lawrencium",   262.0000, 170, 10, 103);

        elementMap = new Dictionary<string,Element>{{"H"  , H },
                                                    {"He" , He},
                                                    {"Li" , Li},
                                                    {"Be" , Be},
                                                    {"B"  , B },
                                                    {"C"  , C },
                                                    {"N"  , N },
                                                    {"O"  , O },
                                                    {"F"  , F },
                                                    {"Ne" , Ne},
                                                    {"Na" , Na},
                                                    {"Mg" , Mg},
                                                    {"Al" , Al},
                                                    {"Si" , Si},
                                                    {"P"  , P },
                                                    {"S"  , S },
                                                    {"Cl" , Cl},
                                                    {"Ar" , Ar},
                                                    {"K"  , K },
                                                    {"Ca" , Ca},
                                                    {"Sc" , Sc},
                                                    {"Ti" , Ti},
                                                    {"V"  , V },
                                                    {"Cr" , Cr},
                                                    {"Mn" , Mn},
                                                    {"Fe" , Fe},
                                                    {"Co" , Co},
                                                    {"Ni" , Ni},
                                                    {"Cu" , Cu},
                                                    {"Zn" , Zn},
                                                    {"Ga" , Ga},
                                                    {"Ge" , Ge},
                                                    {"As" , As},
                                                    {"Se" , Se},
                                                    {"Br" , Br},
                                                    {"Kr" , Kr},
                                                    {"Rb" , Rb},
                                                    {"Sr" , Sr},
                                                    {"Y"  , Y },
                                                    {"Zr" , Zr},
                                                    {"Nb" , Nb},
                                                    {"Mo" , Mo},
                                                    {"Tc" , Tc},
                                                    {"Ru" , Ru},
                                                    {"Rh" , Rh},
                                                    {"Pd" , Pd},
                                                    {"Ag" , Ag},
                                                    {"Cd" , Cd},
                                                    {"In" , In},
                                                    {"Sn" , Sn},
                                                    {"Sb" , Sb},
                                                    {"Te" , Te},
                                                    {"I"  , I },
                                                    {"Xe" , Xe},
                                                    {"Cs" , Cs},
                                                    {"Ba" , Ba},
                                                    {"La" , La},
                                                    {"Ce" , Ce},
                                                    {"Pr" , Pr},
                                                    {"Nd" , Nd},
                                                    {"Pm" , Pm},
                                                    {"Sm" , Sm},
                                                    {"Eu" , Eu},
                                                    {"Gd" , Gd},
                                                    {"Tb" , Tb},
                                                    {"Dy" , Dy},
                                                    {"Ho" , Ho},
                                                    {"Er" , Er},
                                                    {"Tm" , Tm},
                                                    {"Yb" , Yb},
                                                    {"Lu" , Lu},
                                                    {"Hf" , Hf},
                                                    {"Ta" , Ta},
                                                    {"W"  , W },
                                                    {"Re" , Re},
                                                    {"Os" , Os},
                                                    {"Is" , Ir},
                                                    {"Pt" , Pt},
                                                    {"Au" , Au},
                                                    {"Hg" , Hg},
                                                    {"Tl" , Tl},
                                                    {"Pb" , Pb},
                                                    {"Bi" , Bi},
                                                    {"Po" , Po},
                                                    {"At" , At},
                                                    {"Rn" , Rn},
                                                    {"Fr" , Fr},
                                                    {"Ra" , Ra},
                                                    {"Ac" , Ac},
                                                    {"Th" , Th},
                                                    {"Pa" , Pa},
                                                    {"U"  , U },
                                                    {"Np" , Np},
                                                    {"Pu" , Pu},
                                                    {"Am" , Am},
                                                    {"Cm" , Cm},
                                                    {"Bk" , Bk},
                                                    {"Cf" , Cf},
                                                    {"Es" , Es},
                                                    {"Fm" , Fm},
                                                    {"Md" , Md},
                                                    {"No" , No},
                                                    {"Lr" , Lr}};

    }

}