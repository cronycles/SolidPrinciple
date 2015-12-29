/*!
 * Single Responsibility Sample
 * Frank Torres (@fcnatra)
 */

var SingleResponsibilityUiController = function() {
	this.runSample = function(heightUiControl, widthUiControl, areaUiControl, descriptionUiControl) {
        var pol = new Square();
		pol.height = heightUiControl.val();
		pol.width = widthUiControl.val();
		var area = pol.getArea();
		
		areaUiControl.val('Area: ' + area);
		descriptionUiControl.val(pol.getDescription());
	}
}

// Basic sample - no Single Responsibility on it
var Rectangle = function() {
	this.height = 0;
	this.width = 0;
	
	this.getArea = function() {
		if (isNaN(this.height) || isNaN(this.width)) return 0;
		
		return this.height * this.width;
	}
	
	this.getDescription = function() {
		if (isNaN(this.height) || isNaN(this.width))
			return "Measurements are not correct, so area can not be calculated";
		
		var description = "Height: " + this.height + "  Width: " + this.width + "  Area: " + this.height * this.width;
		
		return description;
	}
}


// Defining Responsibilities
var Square = function() {
	this.height = 0;
	this.width = 0;
	
	this.getArea = function() {
		if (!this.areValidMeasurements())
			return 0;
			
		return this.calculateArea()
	}
	
	this.getDescription = function() {
		if (!this.areValidMeasurements())
			return "Measurements are not correct, so area can not be calculated";

		return this.formatDescription();
	}
	
	this.areValidMeasurements = function() {	
		if (isNaN(this.height)) return false;
		if (isNaN(this.width)) return false;
		
		return true;
	}
	
	this.calculateArea = function() {
		return this.height * this.width;
	}
	
	this.formatDescription = function() {
		var description = "Height: " + this.height;
		description += "  Width: " + this.width;
		description += "  Area: " + this.calculateArea();
		
		return description;
	}
}