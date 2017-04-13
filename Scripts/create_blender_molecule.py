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

from periodic_table import *

element_str_map = {"H"  : H,
                   "He" : He,
                   "Li" : Li,
                   "Be" : Be,
                   "B"  : B}