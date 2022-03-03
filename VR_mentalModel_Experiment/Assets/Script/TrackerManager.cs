using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Valve.VR;
public enum TRACKER
{
    Origin = 0,
    Laptop = 1,
    //Tracker1 = 1,
    //Tracker2 = 2,
    //HC_Origin = 0,
    //Player1 = 1,
    //Player2 = 2,
    //Player3 = 3,
    //Shifty = 40,
    //Shifty_Cartridge = 41,
    //Panel = 50,
    //Vive_Controller_Left = 60,
    //Vive_Controller_Right = 61,
    //Controller_Cartridge = 62,
    //Gun = 70,
    //Gun_Cartridge = 71,
    //Shield = 80,
    //Shield_Cartridge = 81,
};
public class TrackerManager : MonoBehaviour
{
    #region Singleton
    private static TrackerManager _Instance;
    public static TrackerManager Instance
    {
        get
        {
            if (_Instance != null)
            {
                return _Instance;      // 已經註冊的Singleton物件
            }
            _Instance = FindObjectOfType<TrackerManager>();
            //尋找已經在Scene的Singleton物件:
            if (_Instance != null)
            {
                return _Instance;
            }
            CreateDefault();     // 實時創建Singleton物件
            return _Instance;
        }
    }
    static void CreateDefault()
    {
        TrackerManager prefab = Resources.Load<TrackerManager>("HGR_Prefab/Singleton/TrackerManager");
        _Instance = Instantiate(prefab);       // No need to care about the position, rotation, ...
        _Instance.gameObject.name = "TrackerManager";
    }
    #endregion Region
    //public GameObject trackers;
    //public static Dictionary<TRACKER, GameObject> trackerGameObjects = new Dictionary<TRACKER, GameObject>();

    /// <summary>
    /// Tracker action set
    /// </summary>
   // [SerializeField]
    //SteamVR_ActionSet HC_Tracker_ActionSet;
    /// <summary>
    /// Device: Gun
    /// Tracker Role: Right foot
    /// </summary>
    //[SerializeField]
    //SteamVR_Action_Boolean GunTriggerPress;
    //[SerializeField]
    //SteamVR_Action_Boolean GunIsHold;
    //[SerializeField]
    //SteamVR_Input_Sources InputGunTriggerPressed;
    //[SerializeField]
    //SteamVR_Input_Sources InputGunIsHold;

    //[SerializeField]
    //SteamVR_Action_Boolean ControllerTriggerPress;
    //[SerializeField]
    //SteamVR_Input_Sources ControllerTriggerPressed;
    public bool TrackerReMap;
    

    void Awake()
    {
        TrackerMapping();
        
        // HC_Tracker_ActionSet.Activate(SteamVR_Input_Sources.Any, 0, true);
        // ControllerTriggerPress.AddOnStateUpListener(ControllerFire, ControllerTriggerPressed);

        // GunTriggerPress.AddOnStateDownListener(GunFire, InputGunTriggerPressed);
        // GunIsHold.AddOnStateDownListener(GunHold, InputGunIsHold);
        // GunIsHold.AddOnStateUpListener(GunRelease, InputGunIsHold);
    }

    // Update is called once per frame
    void Update()
    {
        if (TrackerReMap)
        {
            TrackerMapping();
            TrackerReMap = false;
        }
    }
    /// <summary>
    /// from https://gist.github.com/jeffcrouse/6419e84d7060c08c17cf97b9c41ddd14
    /// </summary>
    private void ResetTrackerRecursive(GameObject obj)
    {
        if (null == obj)
            return;
        foreach (Transform child in obj.transform)
        {
            if (null == child)
                continue;
            //child.gameobject contains the current child you can do whatever you want like add it to an array
            if (child.GetComponent<SteamVR_TrackedObject>() != null)
            {
                child.gameObject.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex(-1);
            }
            ResetTrackerRecursive(child.gameObject);
        }
    }
    private void ResetTracker()
    {
        SteamVR_TrackedObject[] trackers = (SteamVR_TrackedObject[] )Object.FindObjectsOfType<SteamVR_TrackedObject>();
        if (trackers == null)
            return;
        foreach(SteamVR_TrackedObject t in trackers)
        {
            t.gameObject.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex(-1);
            //Debug.Log($"{t.gameObject.name}");
        }
    }
    void TrackerMapping()
    {
        //trackerGameObjects.Clear();
        ResetTracker();
        for (int i = 1; i < SteamVR.connected.Length; ++i)
        {
            ETrackedPropertyError error = new ETrackedPropertyError();
            StringBuilder sb = new StringBuilder();
            OpenVR.System.GetStringTrackedDeviceProperty((uint)i, ETrackedDeviceProperty.Prop_SerialNumber_String, sb, OpenVR.k_unMaxPropertyStringSize, ref error);
            var SerialNumber = sb.ToString();

            OpenVR.System.GetStringTrackedDeviceProperty((uint)i, ETrackedDeviceProperty.Prop_ModelNumber_String, sb, OpenVR.k_unMaxPropertyStringSize, ref error);
            var ModelNumber = sb.ToString();
            //Debug.Log("Device " + i.ToString() + " = " + SerialNumber + " | " + ModelNumber);
            if (SerialNumber.Length > 0 && (ModelNumber.Contains("Tracker") || ModelNumber.Contains("Controller")) && SerialNumberToProp.ContainsKey(SerialNumber))
            {
                Debug.Log("Device " + i.ToString() + " = " + SerialNumber + " | " + ModelNumber);
                string _propName = SerialNumberToProp[SerialNumber];
                Debug.Log(_propName);
                GameObject prop = GameObject.Find("Tracker_" + _propName);
                if (prop == null) continue;
                Debug.Log($"{prop.gameObject.name}");
                //TRACKER tracker = (TRACKER)System.Enum.Parse(typeof(TRACKER), _propName);
                //trackerGameObjects.Add(tracker, prop);
                prop.GetComponent<SteamVR_TrackedObject>().SetDeviceIndex(i);
                //prop.GetComponent<SteamVR_RenderModel>().SetDeviceIndex(i);
            }
        }

    }
    public Dictionary<string, string> SerialNumberToProp = new Dictionary<string, string>()
    {
        { "LHR-BE971ED9", "Origin" },
        {"LHR-40A69F50", "Laptop"},
        //{ "LHR-1999943C", "Player1" },
        //{ "LHR-BF0A6A36", "1" },
        
        
    };
}
