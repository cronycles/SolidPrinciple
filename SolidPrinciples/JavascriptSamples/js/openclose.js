/*!
 * Open/Close Sample
 * Frank Torres (@fcnatra)
 */

var OpenCloseUiController = function() {

	this.runMeasurementSampleNotOpenClose = function (fileSizeUiControl, sentBytesUiControl, progressUiControl)
	{
		var myFile = new File();
		myFile.size = fileSizeUiControl.val();
		myFile.sent = sentBytesUiControl.val();
		
        var progressCalculator = new Progress();
		progressCalculator.initialize(myFile);
		var progress = progressCalculator.getAsPercent();
		
		progressUiControl.val('Progress: ' + progress + '%');
	}
	
	this.runMeasurementSampleOpenClose = function(messageUiControl)
	{
		var message1 = this.showProgress("TextFile", new TextFile());
		var message2 = this.showProgress("AudioFile", new AudioFile());
		
		messageUiControl.val(message1 + " AND " + message2);
	}
	
	this.showProgress = function(objectName, object)
	{
		var result = "";
		var objToMeasure = new Measurable(object);
		if (!objToMeasure.isMeasurable) result += objectName + " is NOT measurable.";
		
		try
		{
			var progressCalculatorOcp = new ProgressOCP(objToMeasure);
			progress = progressCalculatorOcp.getAsPercent();
			result += objectName + " is measurable: " + progress + '%';
		}	
		catch (e)
		{
			console.log("Exception: " + e);
		}
		return result;
	} 
}


// Basic sample - not Open/Close
var File = function() {
	this.size = 0;
	this.sent = 0;
}

// code not open for its extension
var Progress = function() {
	this.fileTarget = null;
	
	this.initialize = function(file){
		this.fileTarget = file;
	}
	
	this.getAsPercent = function() {
		return this.fileTarget.sent * 100 / this.fileTarget.size
	}
}




// Code closed for modification, but open for extendion - using Strategy Design Pattern
function TextFile() {	
	this.size = 10;
	this.sent = 5;
		
	this.getSize = function() { return this.size; }
	this.getSent = function() { return this.sent; }
}

function AudioFile() {	
	this.duration = 10;
	this.played = 7;
	this.artist = "Some artist";
	this.album = "Some album";

	this.getSize = function() { return this.duration; }
	this.getSent = function() { return this.played; }
}

// this acts as interface (in c# we don't need to implement getSize not getSent - they would be members of the interface)
function Measurable(obj) {
	var that = obj || {};
	that.isMeasurable = checkThatIsMeasurable();
	
	function checkThatIsMeasurable() {
		return typeof(that["getSize"]) == "function" && typeof(that["getSent"]) == "function";
	}
	
	return that;
}

var ProgressOCP = function(measurableTarget) {
	var target = measurableTarget || new Measurable(null);
	if (typeof(target["isMeasurable"]) != "boolean" || !target.isMeasurable) throw "Object is not measurable";
	
	this.getAsPercent = function() {		
		return target.getSent() * 100 / target.getSize();
	}
}

