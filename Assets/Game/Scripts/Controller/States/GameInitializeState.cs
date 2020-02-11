using UnityEngine;
using UnityEngine.Events;

public class GameInitializeState : GameState {
    public override void Enter() {
        InitializeLevel();
        
        this.AddObserver(OnTestInteraction, "TestInteraction");
    }

    public void OnDestroy() {
        this.RemoveObserver(OnTestInteraction, "TestInteraction");
    }
    

    private void OnTestInteraction(object sender, object args) {
        this.TrunkController.RemoveNextTrunk(InitializeLevel);
    }

    private void InitializeLevel() {
        RoundModel round = new RoundModel();
        round.Height = 5;
        
        this.TrunkController.CreateLevel(round, (trunkPos) => {
            this.PostNotification(CameraRig.OnMoveNotification, new InfoEventArgs<Vector3, UnityAction>(trunkPos,
                () => {
                    TrunkController.ShowLevel();
                }));
        });
    }
}
