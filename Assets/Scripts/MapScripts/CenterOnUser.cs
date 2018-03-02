using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Examples;

public class CenterOnUser : MonoBehaviour
{
    public AbstractMap map;
    public void Center()
    {
        Vector2d currentLocation = new Vector2d(Input.location.lastData.latitude, Input.location.lastData.longitude);
        map.SetCenterLatitudeLongitude(currentLocation);
    }
}
