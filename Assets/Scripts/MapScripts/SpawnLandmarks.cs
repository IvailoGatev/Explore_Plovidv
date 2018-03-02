using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLandmarks : MonoBehaviour
{
    private static Queue<string> landmarkNames;
    private static bool isInitialized;

    void AddLandmarkNames()
    {
        landmarkNames.Enqueue("Architectual and Historical Reserve \"Ancient Plovdiv\"");
        landmarkNames.Enqueue("Archeological Complex \"Nebet tepe\" and Thracian Settlement");
        landmarkNames.Enqueue("Ancient Theatre of Philippopolis");
        landmarkNames.Enqueue("House of Nedkovich");
        landmarkNames.Enqueue("House of Argir Kuyumdjioglu");
        landmarkNames.Enqueue("House of Georgiadi");
        landmarkNames.Enqueue("Balabonov's house");
        landmarkNames.Enqueue("House of Hindliyan");
        landmarkNames.Enqueue("House of Mavridi");
        landmarkNames.Enqueue("House of Hristo G. Danov");
        landmarkNames.Enqueue("Museum House \"Zlatyu Boyadzhiev\"");
        landmarkNames.Enqueue("\"St. st. Konstantin and Elena\" Church");
        landmarkNames.Enqueue("\"St. Nedelya\" Church");
        landmarkNames.Enqueue("\"St. Marina\" Metropolitan Church");
        landmarkNames.Enqueue("Regional Archeological Museum of Plovidv");
        landmarkNames.Enqueue("Historical Museum");
        landmarkNames.Enqueue("Regional Museum of Natural History");
        landmarkNames.Enqueue("City Art Gallery of Plovdiv");
        landmarkNames.Enqueue("Ancient stadium of Philippopolis");
        landmarkNames.Enqueue("Ancient Forum");
        landmarkNames.Enqueue("Ancient Odeon");
        landmarkNames.Enqueue("Monument of the Unification");
        landmarkNames.Enqueue("Clock Tower");
        landmarkNames.Enqueue("Monument of the Soviet Warrior(Alyosha)");
        landmarkNames.Enqueue("The Brotherhood Mound");
        landmarkNames.Enqueue("Djumaya Mosque");
    }
    void Start()
    {
        GameObject landmarsk = GameObject.Find("Landmarks");
        this.transform.parent = landmarsk.transform;
        if (!isInitialized)
        {
            isInitialized = true;
            landmarkNames = new Queue<string>();
            AddLandmarkNames();
        }
        this.name = landmarkNames.Dequeue();
    }
}
