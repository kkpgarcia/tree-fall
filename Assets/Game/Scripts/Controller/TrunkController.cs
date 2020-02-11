using UnityEngine;
using UnityEngine.Events;

public class TrunkController : MonoBehaviour {
    
    [SerializeField] private GameObject m_TrunkPlatform;
    [SerializeField] private Ground m_Ground;
    [SerializeField] private Platform m_CurrentPlatform;

    private Vector3 m_CurrentReferencePoint;
    
    public void CreateLevel(RoundModel level, UnityAction<Vector3> onLevelGenerated) {
        m_CurrentReferencePoint = m_Ground.GetRandomPoint();
        m_CurrentPlatform = Instantiate(m_TrunkPlatform, m_CurrentReferencePoint, new Quaternion()).GetComponent<Platform>();
        m_CurrentPlatform.CreateTrunks(level, m_CurrentReferencePoint, onLevelGenerated);
    }

    public void ShowLevel() {
        m_CurrentPlatform.ShowTrunks(m_CurrentReferencePoint);
    }

    public void RemoveNextTrunk(UnityAction<bool> onCleared) {
        if (!m_CurrentPlatform.IsEmpty()) {
            m_CurrentPlatform.RemoveBottomTrunk();
        }
        else {
            Destroy(m_CurrentPlatform.gameObject);
        }
        
        onCleared(!m_CurrentPlatform.IsEmpty());
    }
}
