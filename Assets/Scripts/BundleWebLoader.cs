using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class BundleWebLoader : MonoBehaviour
{
    public string bundleUrl = "";
    public string assetName = "assets/environment/Environment_Prefab.prefab";

    public delegate void OnFinishLoading();
    public static event OnFinishLoading onFinishLoading;

    private void Awake()
    {
        StartCoroutine(LoadAsset());
    }

    IEnumerator LoadAsset()
    {
        if (bundleUrl == "")
        {
            Debug.LogError("Insert the bundle url");
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

            var loadAsset = bundle.LoadAsset<GameObject>(assetName);
            Instantiate(loadAsset);

            bundle.Unload(false);
        }

        onFinishLoading?.Invoke();
    }
}