#=============================================================================#
#
#        @author: Thomas Bolden
#        @date:   April 13, 2017
#        @class:  Molecule
#
#=============================================================================#

#=============================================================================#
#
#    NEED a dictionary in separate text file of atomic radii and masses, etc.
#    that will be mapped to once given the names of 
#
#    This file is the class for the blender molecule object, so need one to do
#    other things like read and plot it. This should not require mapping the 
#    
#
#=============================================================================#

#import bpy

#from elements import element

#from periodic_table import *

def decode_bonds(self):
	pass

def get_atoms(self):
	'''
	should return a list of atoms in the molecule with their locations?
	'''
	pass

# this function places a double bond where it should be
def add_atom(type, location):
	pass

# these functions place bonds where they should be -- toy with the parameters
def single_bond(length,location):
    pass

def double_bond(length):
	pass

def triple_bond(length):
	pass

def molecule(name, r):
	pass

