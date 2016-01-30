using UnityEngine;
using System.Collections;
using InControl;

public class MovementController : PlayerActionSet
{
    public PlayerAction Left;
    public PlayerAction Right;
    public PlayerAction Up;
    public PlayerAction Down;
    public PlayerTwoAxisAction Move;

    public MovementController()
    {
        Left = CreatePlayerAction("Move Left");
        Right = CreatePlayerAction("Move Right");
        Up = CreatePlayerAction("Move Up");
        Down = CreatePlayerAction("Move Down");
        Move = CreateTwoAxisPlayerAction(Left, Right, Down, Up);
    }

    public static MovementController CreateWithDefaultBindings()
    {
        var playerController = new MovementController();
        playerController.Up.AddDefaultBinding(Key.UpArrow);
        playerController.Down.AddDefaultBinding(Key.DownArrow);
        playerController.Left.AddDefaultBinding(Key.LeftArrow);
        playerController.Right.AddDefaultBinding(Key.RightArrow);

        playerController.Left.AddDefaultBinding(InputControlType.LeftStickLeft);
        playerController.Right.AddDefaultBinding(InputControlType.LeftStickRight);
        playerController.Up.AddDefaultBinding(InputControlType.LeftStickUp);
        playerController.Down.AddDefaultBinding(InputControlType.LeftStickDown);

        playerController.Left.AddDefaultBinding(InputControlType.DPadLeft);
        playerController.Right.AddDefaultBinding(InputControlType.DPadRight);
        playerController.Up.AddDefaultBinding(InputControlType.DPadUp);
        playerController.Down.AddDefaultBinding(InputControlType.DPadDown);
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
