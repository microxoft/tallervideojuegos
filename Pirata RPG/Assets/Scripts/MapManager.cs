using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    XmlDocument level1;
    public GameObject DirtA, FlowerK, FlowerL, FlowerM, GrassE, PathJ, PathK, PathL, PathM, PathN, PathO, PathP, PathQ, PathR, PathS, PathT, PathU, PathV, PathW, PathX, PathY, PathZ, RockN, RockO, RockP, RockQ, TreeA, TreeB, TreeC, TreeD, TreeE, WallR, WallS, WallT, WallU, WaterW, WaterX, WaterY, WaterZ;
    public GameObject PiraGuchi, Enemy3F, Enemy3M;
    Dictionary<char, GameObject> prefabs;
    GameObject newCell;

    // Start is called before the first frame update
    void Start()
    {
        prefabs = new Dictionary<char, GameObject> {
            { 'A', TreeA },
            { 'B', TreeB },
            { 'C', TreeC },
            { 'D', TreeD },
            { 'E', TreeE },
            { 'j', PathJ },
            { 'k', PathK },
            { 'l', PathL },
            { 'm', PathM },
            { 'n', PathN },
            { 'o', PathO },
            { 'p', PathP },
            { 'q', PathQ },
            { 'r', PathR },
            { 's', PathS },
            { 't', PathT },
            { 'u', PathU },
            { 'v', PathV },
            { 'w', PathW },
            { 'x', PathX },
            { 'y', PathY },
            { 'z', PathZ },
            { 'K', FlowerK },
            { 'L', FlowerL },
            { 'M', FlowerM },
            { 'N', RockN },
            { 'O', RockO },
            { 'P', RockP },
            { 'Q', RockQ },
            { 'R', WallR },
            { 'S', WallS },
            { 'T', WallT },
            { 'U', WallU },
            { 'W', WaterW },
            { 'X', WaterX },
            { 'Y', WaterY },
            { 'Z', WaterZ },
            { 'a', DirtA },
            { 'e', GrassE }
        };
        int i=0, j;
        level1 = new XmlDocument();
        level1.LoadXml(Resources.Load<TextAsset>("Level1").text);

        // Map's rows:
        foreach(XmlNode xmlNode in level1.SelectNodes("//Level/Map/Row"))
        {
            j = 0;
            foreach(char currentCell in xmlNode.InnerText)
            {
                newCell = Instantiate(prefabs[currentCell], new Vector3(j, i), Quaternion.identity);
                j++;
            }
            i--;
        }

        // Special cells:
        foreach (XmlNode xmlNode in level1.SelectNodes("//Level/SpecialCells/Cell"))
        {
            switch(xmlNode.Attributes["name"].InnerText)
            {
                case "PiraGuchi":
                    newCell = Instantiate(PiraGuchi, new Vector3(Convert.ToInt32(xmlNode.Attributes["posX"].Value), -Convert.ToInt32(xmlNode.Attributes["posY"].Value), -1), Quaternion.identity);
                    break;
                case "Enemy3F":
                    newCell = Instantiate(Enemy3F, new Vector3(Convert.ToInt32(xmlNode.Attributes["posX"].Value), -Convert.ToInt32(xmlNode.Attributes["posY"].Value), -1), Quaternion.identity);
                    break;
                case "Enemy3M":
                    newCell = Instantiate(Enemy3M, new Vector3(Convert.ToInt32(xmlNode.Attributes["posX"].Value), -Convert.ToInt32(xmlNode.Attributes["posY"].Value), -1), Quaternion.identity);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
