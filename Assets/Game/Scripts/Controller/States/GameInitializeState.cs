using UnityEngine;
using UnityEngine.Events;

public class GameInitializeState : GameState {
    public override void Enter() {
        /**
        * All other initializations for the game is placed here.
        */
        InitializeLevel();
    }

    private void InitializeLevel() {
        /**
        * Model class to be passed around without changing the level
        * in this line.
        */
        RoundModel round = new RoundModel();
        round.Height = Random.Range(1,6);
        

        /**
        * Creates the level and a lambda function that moves the camera
        * using observer pattern
        */
        this.TrunkController.CreateLevel(round, (trunkPos) => {
            this.PostNotification(CameraRig.OnMoveNotification, new InfoEventArgs<Vector3, UnityAction>(trunkPos,
                () => {
                    TrunkController.ShowLevel();
                    this.Owner.ChangeState<InteractionState>();
                }));
        });
    }
}
