#=============================================================================#
#
#
#
#=============================================================================#

from elements import element

# sorted by group for coloring reasons
# radii are calculated unless unknown, then emperical, then made up

# Hydrogen
H  = element("Hydrogen",     1.008000, 53,  1)

pt_hydrogen = [H]

# Alkali Metals
Li = element("Lithium",      6.940000, 167, 1)
Na = element("Sodium",       22.98976, 190, 1)
K  = element("Potassium",    39.09830, 243, 1)
Rb = element("Rubidium",     85.46780, 265, 1)
Cs = element("Caesium",      132.9054, 298, 1)
Fr = element("Francium",     223.0000, 320, 1) # made up radius

pt_alkali_metals = [Li, Na, K, Rb, Cs, Fr]

# Alkaline Earth Metals
Be = element("Beryllium",    9.012182, 112, 2)
Mg = element("Magnesium",    24.30500, 145, 2)
Ca = element("Calcium",      40.07800, 194, 2)
Sr = element("Strontium",    87.62000, 219, 2)
Ba = element("Barium",       137.3270, 253, 2)
Ra = element("Radium",       226.0000, 275, 2) # made up radius

pt_alkaline_earth_metals = [Be, Mg, Ca, Sr, Ba, Ra]

# Metalloids
B  = element("Boron",        10.81000, 87,  3)
Si = element("Silicon",      28.08500, 111, 4)
Ge = element("Germanium",    72.63000, 125, 4)
As = element("Arsenic",      74.92160, 114, 5)
Sb = element("Antimony",     121.7600, 133, 5)
Te = element("Tellurium",    127.6000, 123, 6)
Po = element("Polonium",     209.0000, 135, 6)

pt_metalloids = [B, Si, Ge, As, Sb, Te, Po]

# Misc. Nonmetals
C  = element("Carbon",       12.01100, 67,  4)
N  = element("Nitrogen",     14.00700, 56,  5)
O  = element("Oxygen",       15.99900, 48,  6)
P  = element("Phosphorus",   30.97376, 98,  5)
S  = element("Sulfur",       32.06000, 88,  6)
Se = element("Selenium",     78.96000, 103, 6)

pt_nonmetals = [C, N, O, P, S, Se]

# Halogens
F  = element("Fluorine",     18.99840, 42,  7)
Cl = element("Chlorine",     35.45000, 79,  7)
Br = element("Bromine",      79.90400, 94,  7)
I  = element("Iodine",       126.9044, 115, 7)
At = element("Astatine",     210.0000, 127, 7)

pt_halogens = [F, Cl, Br, I, At]

# Noble Gases
He = element("Helium",       4.002602, 31,  8) 
Ne = element("Neon",         20.17970, 38,  8)
Ar = element("Argon",        39.94800, 71,  8)
Kr = element("Krypton",      83.79800, 88,  8)
Xe = element("Xenon",        131.2930, 108, 8)
Rn = element("Radon",        222.0000, 120, 8)

pt_noble_gases = [He, Ne, Ar, Kr, Xe, Rn]

# Transition Metals
Sc = element("Scandium",     44.95591, 184, 3)
Ti = element("Titanium",     47.86700, 176, 4)
V  = element("Vanadium",     50.94150, 171, 5)
Cr = element("Chromium",     51.99610, 166, 6)
Mn = element("Manganese",    54.93804, 161, 7)
Fe = element("Iron",         55.84500, 156, 8)
Co = element("Cobalt",       58.93319, 152, 1)
Ni = element("Nickel",       58.69340, 149, 2)
Cu = element("Copper",       63.54600, 145, 3)
Zn = element("Zinc",         65.38000, 142, 4)
Y  = element("Yttrium",      88.90585, 212, 3)
Zr = element("Zirconium",    91.22400, 206, 4)
Nb = element("Niobium",      92.90638, 198, 5)
Mo = element("Molybdenum",   95.96000, 190, 6)
Tc = element("Technetium",   98.00000, 183, 7)
Ru = element("Ruthenium",    101.0700, 178, 8)
Rh = element("Rhodium",      102.9055, 173, 1)
Pd = element("Palladium",    106.4200, 169, 2)
Ag = element("Silver",       107.8682, 165, 3)
Cd = element("Cadmium",      112.4110, 161, 4)
Hf = element("Hafnium",      178.4900, 208, 2)
Ta = element("Tantalum",     180.9478, 200, 3)
W  = element("Tungsten",     183.8400, 193, 4)
Re = element("Rhenium",      186.2070, 188, 5)
Os = element("Osmium",       190.2300, 185, 6)
Ir = element("Iridium",      192.2170, 180, 7)
Pt = element("Platinum",     195.0840, 177, 8)
Au = element("Gold",         196.9665, 174, 1)
Hg = element("Mercury",      200.5900, 171, 2)

pt_transition_metals = [Sc, Ti, V, Cr, Mn, Fe, Co, Ni, Cu, Zn, 
                        Y, Zr, Nb, Mo, Tc, Ru, Rh, Pd, Ag, Cd, 
                        Hf, Ta, W, Re, Os, Ir, Pt, Au, Hg]

# Post-Transition Metals
Al = element("Aluminum",     26.98153, 118, 3)
Ga = element("Gallium",      69.72300, 136, 3)
In = element("Indium",       114.8180, 156, 3)
Sn = element("Tin",          118.7100, 145, 4)
Tl = element("Thallium",     204.3800, 156, 3)
Pb = element("Lead",         207.2000, 154, 4)
Bi = element("Bismuth",      208.9804, 143, 5)

pt_post_transition_metals = [Al, Ga, In, Sn, Tl, Pb, Bi]

# Lanthanoids
La = element("Lanthanum",    138.9054, 1,   3) # emperical radius
Ce = element("Cerium",       140.1160, 1,   4) # emperical radius
Pr = element("Praseodymium", 140.9076, 247, 5)
Nd = element("Neodymium",    144.2420, 206, 6)
Pm = element("Promethium",   145.0000, 205, 7)
Sm = element("Samarium",     150.3600, 238, 8)
Eu = element("Europium",     151.9640, 231, 1)
Gd = element("Gadolinium",   157.2500, 233, 2)
Tb = element("Terbium",      158.9253, 225, 3)
Dy = element("Dysprosium",   162.5000, 228, 4)
Ho = element("Holmium",      164.9303, 226, 5)
Er = element("Erbium",       167.2590, 226, 6)
Tm = element("Thulium",      168.9342, 222, 7)
Yb = element("Ytterbium",    173.0540, 222, 8)
Lu = element("Lutetium",     174.9668, 217, 1)

pt_lanthanoids = [La, Ce, Pr, Nd, Pm, Sm, Eu, Gd, Tb, Dy, Ho, Er, Tm, Yb, Lu]

# Actinoids
Ac = element("Actinium",     227.0000, 195, 3) # emperical radius
Th = element("Thorium",      232.0380, 180, 4) # emperical radius
Pa = element("Protactinium", 231.0358, 180, 5) # emperical radius
U  = element("Uranium",      238.0289, 175, 6) # emperical radius
Np = element("Neptunium",    237.0000, 175, 7) # emperical radius
Pu = element("Plutonium",    244.0000, 175, 8) # emperical radius
Am = element("Americium",    243.0000, 175, 1) # emperical radius
Cm = element("Curium",       247.0000, 172, 2) # made up radius
Bk = element("Berkelium",    247.0000, 172, 3) # made up radius
Cf = element("Californium",  251.0000, 170, 4) # made up radius
Es = element("Einsteinium",  252.0000, 169, 5) # made up radius
Fm = element("Fermium",      257.0000, 165, 6) # made up radius
Md = element("Mendelevium",  258.0000, 164, 7) # made up radius
No = element("Nobelium",     259.0000, 163, 8) # made up radius
Lr = element("Lawrencium",   262.0000, 170, 1) # made up radius

pt_actinoids = [Ac, Th, Pa, U, Np, Pu, Am, Cm, Bk, Cf, Es, Fm, Md, No, Lr]

# TESTING
#for x in pt_halogens:
#    print(x.name(), " molar mass: ", x.mass())

