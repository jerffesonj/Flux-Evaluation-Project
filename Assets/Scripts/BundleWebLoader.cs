using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;

public class BundleWebLoader : MonoBehaviour
{
    public string bundleUrl = "";
    public string assetName = "BundledObject";

    private void Awake()
    {
        StartCoroutine(LoadAssets());
    }
    // Start is called before the first frame update
    IEnumerator LoadAssets()
    {
        if (bundleUrl == "")
        {
            Debug.LogError("Insert the asset url");
            yield break;
        }

        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(bundleUrl);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);

            //string[] objectNames = bundle.GetAllAssetNames();

            //foreach(string objectName in objectNames)
            //{
            //    print(objectName);
            //    var loadAsset = bundle.LoadAsset<GameObject>(objectName);
            //    Instantiate(loadAsset);

            //}

            var loadAsset = bundle.LoadAsset<GameObject>("assets/environment/Environment_Prefab.prefab");
                Instantiate(loadAsset);
        }
    }
}