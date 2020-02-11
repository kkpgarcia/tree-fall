using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPostNotifier : MonoBehaviour {
    public string Notification;
    private Button m_Button;

    private void Awake() {
        m_Button = GetComponent<Button>();
        m_Button.onClick.AddListener(OnNotify);
    }

    private void OnDestroy() {
        m_Button.onClick.RemoveListener(OnNotify);
    }

    private void OnNotify() {
        this.PostNotification(Notification);
    }
}
