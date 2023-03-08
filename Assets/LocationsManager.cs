using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LocationsManager : MonoBehaviour
{
    public List<DifferentLocation> Locations;
    public DifferentLocation GetLocationByName(string name)
    {
        return Locations.FirstOrDefault(a => a.Name == name);
    }
}
