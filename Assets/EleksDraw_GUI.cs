using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class EleksDraw_GUI : MonoBehaviour {

    SerialPort sp = null;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnGUI() {
        // GUI box
        //GUI.Box(new Rect(10, 10, 100, 90), "Menu");

        if (GUILayout.Button("Connect")) {
            InitSerialComm();
        }
        if (GUILayout.Button("Move")) {
            sp.WriteLine("F1000");
            sp.WriteLine("G91");
            sp.WriteLine("G01Y10");// + nJogAmount.Value.ToString());
            sp.WriteLine("G90");
        }
        if (GUILayout.Button("Disconnect")) {
            sp.Close();
        }
    }

    public List<string> GetListOfComPorts() {
        List<string> tList = new List<string>();
        foreach (string s in SerialPort.GetPortNames()) {
            tList.Add(s);
            //print(s);
        }
        return tList;
    }
    void InitSerialComm() {
        sp = new SerialPort("COM3", 115200);
        //sp.PortName = "COM3";
        //sp.BaudRate = 115200;
        sp.Open();
        if (sp.IsOpen) {
            print("ready");
        }

    }

}
