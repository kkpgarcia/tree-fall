using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class ButtonPostNotifier : MonoBehaviour {
    
    public string Notification;
    private Button m_Button;

    private void Awake() {
        m_Button = GetComponent<Button>();
        #if UNITY_IOS
        m_Button.enabled = false;
        GetComponent<Image>().enabled = false;
        #else
        m_Button.onClick.AddListener(OnNotify);
        #endif
    }

    private void OnDestroy() {
        m_Button.onClick.RemoveListener(OnNotify);
    }

    public void OnNotify() {
        this.PostNotification(Notification);
    }
}
