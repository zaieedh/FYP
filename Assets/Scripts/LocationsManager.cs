using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LocationsManager : MonoBehaviour
{
    /// <summary>
    /// List of all possible location points
    /// </summary>
    public List<DifferentLocation> Locations;
    /// <summary>
    /// Returning location from Locations list by its name
    /// </summary>
    /// <param name="name">Name of location</param>
    /// <returns>Location</returns>
    public DifferentLocation GetLocationByName(string name)
    {
        return Locations.FirstOrDefault(a => a.Name == name);
    }
}
