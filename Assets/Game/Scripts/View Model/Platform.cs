using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Platform : MonoBehaviour {

    [SerializeField] private GameObject m_TrunkPrefab;
    [SerializeField] private Transform Parent;
    [SerializeField] private int YIncrement = 2;
    [SerializeField] private AnimationCurve PopupAnimation;
    [SerializeField] private AnimationCurve ScaleAnimation;
    private List<Trunk> m_Children;
    
    
    private void Awake() {
        m_Children = new List<Trunk>();
    }

    public void CreateTrunks(RoundModel round, Vector3 referencePoint, UnityAction<Vector3> onLevelGenreated) {

        Parent.MoveTo(new Vector3(referencePoint.x, round.Height * -YIncrement, referencePoint.z), 0)
            .CompletedEvent += (s, a) => {
            
            for (int i = 0; i < round.Height; i++) {
                CreateTrunk(i, referencePoint);
            }

            Parent.localScale = Vector3.zero;
            onLevelGenreated(referencePoint);
        };
    }

    public void ShowTrunks(Vector3 referencePoint) {
        Parent.MoveToUsingCurve(referencePoint, 0.5f, PopupAnimation);
        Parent.transform.ScaleToUsingCurve(Vector3.one, 0.5f, ScaleAnimation);
    }
    
    private void CreateTrunk(int posIncrement, Vector3 refPoint) {
        Trunk obj = Instantiate(
            m_TrunkPrefab, 
            new Vector3(refPoint.x, Parent.transform.position.y + (posIncrement * YIncrement), refPoint.z), 
            m_TrunkPrefab.transform.rotation).GetComponent<Trunk>();
        AddTrunk(obj);
    }

    public void AddTrunk(Trunk trunk) {
        m_Children.Add(trunk);
        trunk.transform.SetParent(Parent);
    }

    public void RemoveBottomTrunk() {
        if (m_Children.Count == 0)
            return;
        
        for (int i = 1; i < m_Children.Count; i++) {
            Trunk curr = m_Children[i];
            curr.Move(m_Children[i - 1].transform.position);
        }


        Trunk bottom = m_Children[0];
        m_Children.Remove(bottom);
        Destroy(bottom.gameObject);
    }

    public bool IsEmpty() {
        return m_Children.Count == 0;
    }
}
