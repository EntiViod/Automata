using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Assertions;

public class CameraMixer : MonoBehaviour
{
   

    [System.Serializable]
    public class MixedCamera
    {
        public Camera cam;
        [SerializeField]
        public float blendTime;
        [SerializeField]
        public float elapsedTime;
        [SerializeField]
        [Range(0,1)]
        public float weight;
        [SerializeField]
        public float effectiveWeight;
        [SerializeField]
        public bool abandoned;
        public Interpolators.interpolatorFunc interpolatorFunc;
    }

    private void lerpCameras(GameObject target, GameObject source,float ratio)
    {
        if (target == null || source == null) { Debug.LogError("Invalid GameObject"); return; }

        Transform trSource = source.transform;
        Transform trTarget = target.transform;
        Camera camSource = source.GetComponent<Camera>();
        Camera camTarget = target.GetComponent<Camera>();

        if(!camSource || !camTarget) { Debug.LogError("Invalid Camera Component"); return; }

        Debug.Log(ratio);
        Vector3 newPosition = Vector3.Lerp(trTarget.position,trSource.position , ratio);
        Vector3 newForward = Vector3.Lerp(trTarget.forward, trSource.forward, ratio);

        trTarget.position = newPosition;
        trTarget.forward = newForward;
     
    }

    [SerializeField]
    List<MixedCamera> mixedCameras;

    [SerializeField]
    Camera outputCamera;
    [SerializeField]
    Camera defaultCamera;

    /*
     No está hecho un singletone por si se quieren interpolar varias camaras en el mismo momento.

     */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float remainingWeight = 1.0f;
        bool hasFallback = false;

        for(int i = 0; i<mixedCameras.Count;i++)
        {
           
            if (mixedCameras[i].elapsedTime < mixedCameras[i].blendTime)
            {
                mixedCameras[i].elapsedTime += Mathf.Min(Time.deltaTime, mixedCameras[i].blendTime - mixedCameras[i].elapsedTime);
                mixedCameras[i].weight = mixedCameras[i].elapsedTime / mixedCameras[i].blendTime;
            }

            mixedCameras[i].effectiveWeight = Mathf.Min(remainingWeight, mixedCameras[i].weight);

            remainingWeight -= mixedCameras[i].effectiveWeight;

            
            mixedCameras[i].abandoned = mixedCameras[i].weight >= 1.0f & hasFallback;

            hasFallback = mixedCameras[i].effectiveWeight >= 1.0f;
        }


        

        mixedCameras.RemoveAll(x => x.effectiveWeight >= 1.0f);
        foreach(MixedCamera mc in mixedCameras)
        {
           
          
            float interpolatedWeight = mc.interpolatorFunc != null ? mc.interpolatorFunc(0.0f, 1.0f, mc.weight) : mc.weight;
            lerpCameras(outputCamera.gameObject, mc.cam.gameObject, interpolatedWeight);
        }

        Camera.SetupCurrent(outputCamera);
        
    }

    public void blendCamera(Camera camera,float blendTime, Interpolators.interpolatorFunc interpolatorFunc)
    {
        MixedCamera mc = new MixedCamera();
        mc.blendTime = blendTime;
        mc.cam = camera;
        mc.elapsedTime = 0.0f;
        mc.weight = blendTime <= 0.0f ? 1.0f : 0.0f;
        mc.interpolatorFunc = interpolatorFunc;

        mixedCameras.Add(mc);
    }
}
