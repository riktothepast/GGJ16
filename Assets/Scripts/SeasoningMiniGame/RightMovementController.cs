using UnityEngine;
using System.Collections;
using InControl;

public class RightMovementController : PlayerActionSet
{
    public PlayerAction Left;
    public PlayerAction Right;
    public PlayerAction Up;
    public PlayerAction Down;
    public PlayerTwoAxisAction Move;

    public RightMovementController()
    {
        Left = CreatePlayerAction("Move Left");
        Right = CreatePlayerAction("Move Right");
        Up = CreatePlayerAction("Move Up");
        Down = CreatePlayerAction("Move Down");
        Move = CreateTwoAxisPlayerAction(Left, Right, Down, Up);
    }

    public static RightMovementController CreateWithDefaultBindings()
    {
        var playerController = new RightMovementController();
        playerController.Up.AddDefaultBinding(Key.W);
        playerController.Down.AddDefaultBinding(Key.S);
        playerController.Left.AddDefaultBinding(Key.A);
        playerController.Right.AddDefaultBinding(Key.D);

        playerController.Left.AddDefaultBinding(InputControlType.RightStickLeft);
        playerController.Right.AddDefaultBinding(InputControlType.RightStickRight);
        playerController.Up.AddDefaultBinding(InputControlType.RightStickUp);
        playerController.Down.AddDefaultBinding(InputControlType.RightStickDown);

        playerController.ListenOptions.IncludeUnknownControllers = true;
        playerController.ListenOptions.MaxAllowedBindings = 3;

        playerController.ListenOptions.OnBindingFound = (action, binding) =>
        {
            if (binding == new KeyBindingSource(Key.Escape))
            {
                action.StopListeningForBinding();
                return false;
            }
            return true;
        };

        playerController.ListenOptions.OnBindingAdded += (action, binding) =>
        {
            Debug.Log("Binding added... " + binding.DeviceName + ": " + binding.Name);
        };

        playerController.ListenOptions.OnBindingRejected += (action, binding, reason) =>
        {
            Debug.Log("Binding rejected... " + reason);
        };

        return playerController;
    }
}
