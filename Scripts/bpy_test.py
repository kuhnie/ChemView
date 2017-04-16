#! bin/python

# File to test function that reads cml files

#=============================================================================#

import structure_defines

cml_file = "../Molecules/D-Glucose.cml"

bond_orders = {"1": structure_defines.single_bond,
			   "2": structure_defines.double_bond, 
			   "3": structure_defines.triple_bond, 
			   "A": structure_defines.aromatic_bond, # ?? 
			   "S": structure_defines.stink_bond, # ???
			  }

def decode_cml_file(filename):

	atom_line = "<atom "

	bond_line = "<bond "

	f = open(filename, 'r')

	for line in f:

		line = line.strip()

		if line.startswith(atom_line): 

			a, a_id, el, x, y, z = line.split()

			print("AOTM: ", z)

		elif line.startswith(bond_line):

			b, a_id_1, a_id_2, order = line.split()

			print("BOND: ", order)







decode_cml_file(cml_file)