#! /usr/bin/python

# File to test function that reads cml files

#=============================================================================#

import structure_defines

#try:
#  from lxml import etree
#except ImportError:
#  try:
#    import xml.etree.cElementTree as etree 
#  except ImportError:
#    try:
#      import xml.etree.ElementTree as etree
#    except ImportError:
#      try:
#        import cElementTree as etree
#      except ImportError:
#        try:
#          import elementtree.ElementTree as etree
#        except ImportError:
#          print("Failed to import ElementTree")

#from lxml import etree

cml_file = "../Molecules/D-Glucose.cml"

#bond_orders = {"1": structure_defines.single_bond,
#			   "2": structure_defines.double_bond, 
#			   "3": structure_defines.triple_bond, 
#			   "A": structure_defines.aromatic_bond, # ?? 
#			   "S": structure_defines.stink_bond, # ???
#			  }

def decode_cml_file(filename):

	'''
	This is a hacky function to read strictly formatted .cml files

	I am not entirely familiar with the possible variations 
	in .cml files, so apologies if it breaks

	The function takes the path to the .cml file

	The function returns two lists:
		- a list of 3-tuples for each atom: (atom id, element, 3D location)
		- a list of 3-tuples for each bond: (atom id 1, atom id 2, type)
	'''

	atom_line = "<atom "

	bond_line = "<bond "

	atoms = [] # (str_id, str_element, float_(x,y,z))

	bonds = [] # (str_id1, str_id2, str_type)

	f = open(filename, 'r')

	for line in f:

		line = line.strip()

		if line.startswith(atom_line): 

			a, a_id, el, x, y, z = line.split()

			atoms.append((a_id[4:-1],
				          el[13:-1],
				         (float(x[4:-1]),
                          float(y[4:-1]),
                          float(z[4:-3]))))

		elif line.startswith(bond_line):

			b, a_id_1, a_id_2, order = line.split()

			bonds.append((a_id_1[11:],
                          a_id_2[:-1],
                          order[7:-3]))

	return atoms, bonds

#tree = etree.parse(cml_file).getroot()

#print(tree.tag)

#for element in tree:
#	print(element.tag)

#for element in tree.iter("atom"):
#	print("%s - %s" % (element.tag, element.text))



#tree = etree.parse(cml_file)
#etree.tostring(tree)




decode_cml_file(cml_file)