using UnityEngine;

public class Ground : MonoBehaviour {
    private Mesh m_GroundMesh;
    private Vector3 m_Min;
    private Vector3 m_Max;
    
    public void Awake() {
        m_GroundMesh = this.GetComponent<MeshFilter>().mesh;
        m_Min = m_GroundMesh.bounds.min * this.transform.localScale.x / 2;
        m_Max = m_GroundMesh.bounds.max * this.transform.localScale.x / 2;
    }

    public Vector3 GetRandomPoint() {
        return new Vector3(
            Random.Range(m_Min.x, m_Max.x),
            Random.Range(m_Min.y, m_Max.y),
            Random.Range(m_Min.z, m_Max.z)
        );
    }
}
