using UnityEngine;
using UnityEngine.Events;

public class GameInitializeState : GameState {
    public override void Enter() {
        InitializeLevel();
    }

    private void InitializeLevel() {
        RoundModel round = new RoundModel();
        round.Height = Random.Range(1,6);
        
        this.TrunkController.CreateLevel(round, (trunkPos) => {
            this.PostNotification(CameraRig.OnMoveNotification, new InfoEventArgs<Vector3, UnityAction>(trunkPos,
                () => {
                    TrunkController.ShowLevel();
                    this.Owner.ChangeState<InteractionState>();
                }));
        });
    }
}
