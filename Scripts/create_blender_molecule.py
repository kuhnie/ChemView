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
#=============================================================================#

import bpy

import math

import numpy as np

from periodic_table import *

# scipy or numpy?

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
                   "Lr" : Lr}

#=============================================================================#



#=============================================================================#



#=============================================================================#















































