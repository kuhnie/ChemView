#=============================================================================#
#
#        @author: Thomas Bolden
#        @date:   April 13, 2017
#        @class:  ?
#
#=============================================================================#

#=============================================================================#
#
#    Takes a 3d molecule object and turns it into a blender file
#
#    First converts molecule objects to the blender objects 
#    (eg. convert single bond to cylinder of length x, etc.)
#
#    So this file should also include conversions from the structure to the 
#    3d object in blender 
#    OR
#    that can also be its own file
#
#    Needs to (create? and) add new materials to objects.
#
#    Make an invisible parent object?
#
#    Atoms should be UV spheres
#
#    EVENTUALLY want to be able to save blender file in unity scene or
#    at least in the folder where assets are stored
#
#=============================================================================#

#import bpy

import math

from periodic_table import *

# scipy or numpy?

#=============================================================================#

# can download some samples from here: 
# https://github.com/cryos/avogadro/tree/master/fragments
molecule_file = "path/to/molecule/file"

#=============================================================================#

# Mapping the first 103 elements from string to corresponding element object.
# To access object attributes of say, helium, something like this shoud work:
#              >> element_str_map["He"].mass()
#              >> 4.002602
element_str_map = {"H"  : H,
                   "He" : He,
                   "Li" : Li,
                   "Be" : Be,
                   "B"  : B,
                   "C"  : C,
                   "N"  : N,
                   "O"  : O,
                   "F"  : F,
                   "Ne" : Ne,
                   "Na" : Na,
                   "Mg" : Mg,
                   "Al" : Al,
                   "Si" : Si,
                   "P"  : P,
                   "S"  : S,
                   "Cl" : Cl,
                   "Ar" : Ar,
                   "K"  : K,
                   "Ca" : Ca,
                   "Sc" : Sc,
                   "Ti" : Ti,
                   "V"  : V,
                   "Cr" : Cr,
                   "Mn" : Mn,
                   "Fe" : Fe,
                   "Co" : Co,
                   "Ni" : Ni,
                   "Cu" : Cu,
                   "Zn" : Zn,
                   "Ga" : Ga,
                   "Ge" : Ge,
                   "As" : As,
                   "Se" : Se,
                   "Br" : Br,
                   "Kr" : Kr,
                   "Rb" : Rb,
                   "Sr" : Sr,
                   "Y"  : Y,
                   "Zr" : Zr,
                   "Nb" : Nb,
                   "Mo" : Mo,
                   "Tc" : Tc,
                   "Ru" : Ru,
                   "Rh" : Rh,
                   "Pd" : Pd,
                   "Ag" : Ag,
                   "Cd" : Cd,
                   "In" : In,
                   "Sn" : Sn,
                   "Sb" : Sb,
                   "Te" : Te,
                   "I"  : I,
                   "Xe" : Xe,
                   "Cs" : Cs,
                   "Ba" : Ba,
                   "La" : La,
                   "Ce" : Ce,
                   "Pr" : Pr,
                   "Nd" : Nd,
                   "Pm" : Pm,
                   "Sm" : Sm,
                   "Eu" : Eu,
                   "Gd" : Gd,
                   "Tb" : Tb,
                   "Dy" : Dy,
                   "Ho" : Ho,
                   "Er" : Er,
                   "Tm" : Tm,
                   "Yb" : Yb,
                   "Lu" : Lu,
                   "Hf" : Hf,
                   "Ta" : Ta,
                   "W"  : W,
                   "Re" : Re,
                   "Os" : Os,
                   "Is" : Ir,
                   "Pt" : Pt,
                   "Au" : Au,
                   "Hg" : Hg,
                   "Tl" : Tl,
                   "Pb" : Pb,
                   "Bi" : Bi,
                   "Po" : Po,
                   "At" : At,
                   "Rn" : Rn,
                   "Fr" : Fr,
                   "Ra" : Ra,
                   "Ac" : Ac,
                   "Th" : Th,
                   "Pa" : Pa,
                   "U"  : U,
                   "Np" : Np,
                   "Pu" : Pu,
                   "Am" : Am,
                   "Cm" : Cm,
                   "Bk" : Bk,
                   "Cf" : Cf,
                   "Es" : Es,
                   "Fm" : Fm,
                   "Md" : Md,
                   "No" : No,
                   "Lr" : Lr,
                  }

#=============================================================================#

in_el = "Ag" #input("Enter an element: ")

x = element_str_map[in_el]

print(x.name(), "molar mass: ", x.mass())

#=============================================================================#
#
#    https://en.wikipedia.org/wiki/CPK_coloring
#
#    pt_hydrogen - WHITE
#    pt_alkali_metals - VIOLET
#    pt_alkaline_earth_metals - DARK GREEN
#    pt_metalloids - PEACH
#    pt_nonmetals - BLACK (C), SKY BLUE (O), RED (N), ORANGE (P), YELLOW (S, Se)
#    pt_halogens - LIME GREEN
#    pt_noble_gases - CYAN
#    pt_transition_metals - SALMON 
#    pt_post_transition_metals - GRAY
#    pt_lanthanoids - PINK
#    pt_actinoids - PINK
#
#=============================================================================#

def decode_cml_file(filename):
	'''
	A typical CML file is of the following format:
	<molecule titel="name" ...>
	  <atomArray>
	    <atom id="a1" elementType="C" x3="-1.3961" y3="0.0013" z3="-0.0504"/>
	    ...
	    ...
	  </atomArray>
	</molecule>
	'''

	return "broken"















































