#=============================================================================#
#
#
#
#=============================================================================#

class element(object):

	def __init__(self, name="", mass=0.0, radius=0, vse=0):
		''' Initialize elements with their properties '''
		self.__name   = name
		self.__mass   = mass
		self.__radius = radius # radii are in picometers
        self.__vse    = vse # valence shell electrons

	def name(self):
		''' . '''
		return self.__name

	def mass(self):
		''' . '''
		return self.__mass

	def radius(self):
		''' . '''
		return self.__radius

    def vse(self):
        ''' . '''
        return self.__vse

	# the comparisons are with mass and not the name 

    def __eq__(self, other):
        ''' Return True if elements are same. '''
        return self.__mass == other.__mass

    def __ne__(self, other):
        ''' Return True if elements are different. '''
        return self.__mass != other.__mass

    def __le__(self, other):
        ''' Return True if mass of self is <= mass of other. '''
        return self.mass() <= other.mass()

    def __lt__(self, other):
        ''' Return True if mass of self is < mass of other. '''
        return self.mass() < other.mass()

    def __ge__(self, other):
        ''' Return if mass of self is >= mass of other. '''
        return self.mass() >= other.mass()

    def __gt__(self, other):
        ''' Return whether mass of self is > mass of other. '''
        return self.mass() > other.mass()
