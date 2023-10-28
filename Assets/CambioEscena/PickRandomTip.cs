using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class TipsData
{
    public List<string> tips;
}

public class PickRandomTip : MonoBehaviour
{
    public Text text;
    private TipsData tipsData;

    void Start()
    {
        // Debug.Log("test");
        // Load and parse the JSON file.
        TextAsset jsonAsset = Resources.Load<TextAsset>("tips");
        if (jsonAsset != null)
        {
            string json = jsonAsset.text;
            tipsData = JsonUtility.FromJson<TipsData>(json);

            if (tipsData != null && tipsData.tips.Count > 0)
            {
                int randomIndex = Random.Range(0, tipsData.tips.Count);
                string randomTip = tipsData.tips[randomIndex];
                text.text = randomTip; // Corrected this line

                // Print the random tip to the console.
                Debug.Log("Random Tip: " + randomTip);
            }
            else
            {
                Debug.LogWarning("No tips found in the JSON file.");
            }
        }
        else
        {
            Debug.LogWarning("No 'tips.json' file found in the Resources folder.");
        }
    }
}
