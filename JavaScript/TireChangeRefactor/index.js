(function () {
    'use strict';
    
	// dict of the manufactures name mapped to the tire change requirement value. This allows
	// for quick lookup and for me to make the if structure in the getAircraftsDueForTireChange
	// function more simple.
    var manufatcurerTireChangeRequirenment = {'FooPlane':120, 'BarPlane':75, 'BazPlane':200};
	
    // There are 3 aircraft manufactures, each with different requirements 
    //  for when the tires need to be changed
    //      FooPlane: 120 landings
    //      BarPlane: 75 landings
    //      BazPlane: 200 landings

    // Based on the above information and the data available in the data.js file,
    //  this function is supposed to return an array of aircrafts due for a tire change.
    function getAircraftsDueForTireChange(allAircraftData) {
        var aircraftDueForTireChanges = [];
        for (var i = 0; i < allAircraftData.length; i++) {
			// changed this to an int because it makes more sense if all we want is a 
			// count to use an int then find the length of an array.
            var landingsSinceLastTireChange = 0;
            for (var j = 0; j < allAircraftData[i].landings.length; j++) {
                if (allAircraftData[i].landings[j] >= allAircraftData[i].lastTireChange)
                    landingsSinceLastTireChange++;
            }
			// if else structure improved because only one evaluation is needed thanks to the lookup 
			// done with the dict
            if(landingsSinceLastTireChange >= manufatcurerTireChangeRequirenment[allAircraftData[i].manufacturer])
				aircraftDueForTireChanges.push(allAircraftData[i]);
        }
        return aircraftDueForTireChanges;
    }

    // Test the function 
    //  To keep things simple, we are just going to check the ids and display a pass/fail.
    //  Feel free to use Jasmine or any other test framework if you're more comfortable with that,
    //  but it is NOT required.  This should be a quick exercise.
    var expected = [1, 3, 5];
    var actual = getAircraftsDueForTireChange(window.CAMP.aircraftData).map(function (aircraft) { return aircraft.id; }).sort();
    var passed = (JSON.stringify(expected) === JSON.stringify(actual));

    document.body.innerHTML += passed ? 'PASS' : 'FAIL';
    document.body.innerHTML += '<br />';
    document.body.innerHTML += 'Expected: ' + expected;
    document.body.innerHTML += '<br />';
    document.body.innerHTML += 'Actual: ' + actual;
})();