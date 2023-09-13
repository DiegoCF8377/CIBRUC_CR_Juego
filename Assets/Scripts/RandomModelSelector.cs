using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomModelSelector : MonoBehaviour
{
    public GameObject currentActiveModel;
    public Model[] organicPreFabs = {
                                    new Model {modelName = "appleHalf",
                                                            // new Quaternion(Y, X, Z, W)
                                               modelRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f),
                                               modelScale = new Vector3(1.0f, 1.0f, 1.0f)},
                                    new Model {modelName = "bacon",
                                               modelRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f),
                                               modelScale = new Vector3(3.0f, 3.0f, 3.0f)},
                                    new Model {modelName = "burger",
                                               modelRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f),
                                               modelScale = new Vector3(2.0f, 2.0f, 2.0f)},
                                    new Model {modelName = "avocadoHalf",
                                               modelRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f),
                                               modelScale = new Vector3(1.0f, 1.0f, 1.0f)},
                                    new Model {modelName = "bowlCereal",
                                               modelRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f),
                                               modelScale = new Vector3(1.0f, 1.0f, 1.0f)}
                                    };
    public Model[] nonOrganicPreFabs = {
                                        new Model {modelName = "bag",
                                                   modelRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f),
                                                   modelScale = new Vector3(1.0f, 1.0f, 1.0f)},
                                        new Model {modelName = "chopstickFancy",
                                                   modelRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f),
                                                   modelScale = new Vector3(3.0f, 3.0f, 3.0f)},
                                        new Model {modelName = "cup", 
                                                   modelRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), 
                                                   modelScale = new Vector3(2.5f, 2.5f, 2.5f)},
                                        new Model {modelName = "styrofoam", 
                                                   modelRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), 
                                                   modelScale = new Vector3(-1.0f, 1.0f, 1.0f)},
                                        new Model {modelName = "fryingPan", 
                                                   modelRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), 
                                                   modelScale = new Vector3(1.0f, 1.0f, 1.0f)}
                                        };
    public Model[] electronicPreFabs = {
                                        new Model {modelName = "radio", 
                                                   modelRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), // Currently rotated to the right
                                                   modelScale = new Vector3(1.0f, 1.0f, 1.0f)},
                                        new Model {modelName = "laptop", 
                                                   modelRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), 
                                                   modelScale = new Vector3(0.1f, 0.1f, -0.1f)},
                                        new Model {modelName = "speakerSmall", 
                                                   modelRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), 
                                                   modelScale = new Vector3(0.3f, 0.3f, 0.3f)},
                                        new Model {modelName = "computerScreen", 
                                                   modelRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), // Currently rotated to the right
                                                   modelScale = new Vector3(0.3f, 0.3f, -0.3f)},
                                        new Model {modelName = "dryer", 
                                                   modelRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), 
                                                   modelScale = new Vector3(0.2f, 0.2f, -0.2f)}
                                        };

    public void selectRandomModel(string modelType)
    {
        deactivateAllTrashModels();
        Model model = new Model();
        switch (modelType)
        {
            case "OrganicTrash":
                model = organicPreFabs[Random.Range(1, 5)];
                break;
            case "NonOrganicTrash":
                model = nonOrganicPreFabs[Random.Range(1, 5)];
                break;
            case "ElectronicTrash":
                model = electronicPreFabs[Random.Range(1, 5)];
                break;
        }
        GameObject myPrefab = Resources.Load<GameObject>(model.modelName);
        currentActiveModel = Instantiate(myPrefab);
        currentActiveModel.transform.position = this.transform.position;
        currentActiveModel.transform.rotation = model.modelRotation;
        currentActiveModel.transform.localScale = model.modelScale;
    }

    public class Model
    {
        public string modelName { get; set; }
        public Quaternion modelRotation { get; set; }
        public Vector3 modelScale { get; set; }

    }

    public void deactivateAllTrashModels()
    {
        if (currentActiveModel == null)
        {
            return;
        }
        currentActiveModel.SetActive(false);
        Destroy(currentActiveModel);
    }

    private void OnTriggerEnter(Collider coll)
    {
        deactivateAllTrashModels();
    }
}
