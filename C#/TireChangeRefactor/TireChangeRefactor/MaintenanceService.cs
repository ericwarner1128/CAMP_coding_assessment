using System;
using System.Collections.Generic;
using System.Linq;
using TireChangeRefactor.Model;

namespace TireChangeRefactor
{
    /// <summary>
    /// Service responsible for determining the maintenance that is required
    /// for aircrafts
    /// </summary>
    public class MaintenanceService
    {
		// this dictionary is being used to store the tire change requirnments mapped to the name
		// of the aircraft manufactures. thanks to this we have 0(1) lookup speed of the information
		// and no longer need to have the large if else structure in the GetAllAircraftDueForTireChange
		// method.
		Dictionary<String, int> manufacturerTireChangeRequirenment = new Dictionary<String, int>(){
			{"FooPlane", 120},
			{"BarPlane", 75},
			{"BarPlane", 200}
		};
		
        /// <summary>
        /// Gets all the aircraft that are due for a tire change.
        /// </summary>
        /// <returns>An array of aircraft that require tire changes according to mfg specifications</returns>
        public AircraftModel[] GetAllAircraftDueForTireChange()
        {
            // There are 3 aircraft manufactures, each with different requirements 
            //  for when the tires need to be changed
            //      FooPlane: 120 landings
            //      BarPlane: 75 landings
            //      BazPlane: 200 landings

            var repo = new DAL.AircraftRepository();
            var allAircraft = repo.GetAll().ToArray();
            var requiresTireChange = new List<AircraftModel>();
            for (var i = 0; i < allAircraft.Count(); i ++)
            {
				// changed this var to an int because before the array was only being used to calculate a count
				// of the number of landings done after the last tier changed. It makes more sense to use an int
				// for a job like calculating a count.
                var landings = 0;
                for (var j = 0; j < allAircraft[i].Landings.Count(); j++)
                {
                    if (allAircraft[i].Landings[j] >= allAircraft[i].LastTireChange)
                        landings++;
                }
				
				// thanks to the dictionary I added to keep track of the manufactures tire change 
				// requirements only one if check is needed to see if the aircraft needs to be added
				// to the list.
                if(landings >= manufacturerTireChangeRequirenment[allAircraft[i].Manufacturer])
				{
					requiresTireChange.Add(allAircraft[i]);
				}
            }

            return requiresTireChange.ToArray();
        }
    }
}
