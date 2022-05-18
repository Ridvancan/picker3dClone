using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Transform ObjectSpawnTransform;
    public GameObject Propeller;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isSpawnerBegin)
            PropellerRotate();

    }

    public void PropellerRotate()
    {
        Propeller.transform.Rotate(0, -300 * Time.deltaTime, 0);
    }
    public void BeginSpawner()
    {
        StartCoroutine(SpawnObject());
        GameManager.Instance.isSpawnerBegin = true;
        LeanTween.moveX(gameObject, -2, 0.5f).setEaseLinear().setLoopPingPong();
        LeanTween.moveLocalZ(gameObject, gameObject.transform.localPosition.z + 40, 5f).setEaseLinear().setOnComplete(() => { LeanTween.cancel(gameObject); GameManager.Instance.isSpawnerBegin = false; LeanTween.scale(gameObject, Vector3.zero, 1f).setEase(LeanTweenType.easeInBounce).setOnComplete(()=>gameObject.SetActive(false)); });
    }
    public IEnumerator SpawnObject()
    {

        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.2f);
            GameObject spawnedObject = Instantiate(GameManager.Instance.SpawnObjects, gameObject.GetComponent<ObjectSpawner>().ObjectSpawnTransform);//Object pool kullanýlmalý.
            spawnedObject.transform.localPosition = Vector3.zero;
            spawnedObject.transform.parent = null;
            GameManager.Instance.collectedObjectList.Add(spawnedObject);
        }

    }
}
