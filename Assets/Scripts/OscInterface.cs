using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscInterface : MonoBehaviour
{
    public OscJack.OscEventReceiver oscRecever;
    [SerializeField] int _data;
    public int touchThreshold = 1000;
    [SerializeField] bool _isCapacitiveTouched;

    public int Data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value;
            _isCapacitiveTouched = _data >= touchThreshold;
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Data = oscRecever.intData;
    }

    public bool IsCapacitiveTouched() {
        return _isCapacitiveTouched;
    }
}
