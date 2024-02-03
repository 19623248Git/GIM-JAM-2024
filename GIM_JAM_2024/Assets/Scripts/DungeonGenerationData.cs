using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "DungeonGenerationData.asset", menuName = "DungeonGenerationData/Dungeon Data")]
public class DungeonGenerationData : ScriptableObject
{
    public List<SceneAsset> scenesToLoad; // List of scenes to choose from
    public int numberOfCrawlers;
    public int iterationMin;
    public int iterationMax;
}
