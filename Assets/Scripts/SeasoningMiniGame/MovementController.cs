using UnityEngine;
using System.Collections;
using InControl;

public class MovementController : PlayerActionSet
{
    public PlayerAction Left;
    public PlayerAction Right;
    public PlayerAction Up;
    public PlayerAction AButton;
    public PlayerAction Start;
    public PlayerAction Down;
    public PlayerTwoAxisAction Move;

    public MovementController()
    {
        Left = CreatePlayerAction("Move Left");
        Right = CreatePlayerAction("Move Right");
        Up = CreatePlayerAction("Move Up");
        Down = CreatePlayerAction("Move Down");
        AButton = CreatePlayerAction("A Button");
        Start = CreatePlayerAction("Start");
        Move = CreateTwoAxisPlayerAction(Left, Right, Down, Up);
    }

    public static MovementController CreateWithDefaultBindings()
    {
        var playerController = new MovementController();
        playerController.AButton.AddDefaultBinding(InputControlType.Action1);
        playerController.AButton.AddDefaultBinding(Key.A);

        playerController.Start.AddDefaultBinding(InputControlType.Start);
        playerController.Start.AddDefaultBinding(Key.Return);

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

        playerController.Left.Raw = false;
        playerController.Left.LowerDeadZone = 0.5f;
        playerController.Left.UpperDeadZone = 0.9f;
        playerController.Up.Raw = false;

        playerController.Up.LowerDeadZone = 0.5f;
        playerController.Up.UpperDeadZone = 0.9f;
        playerController.Down.Raw = false;

        playerController.Down.LowerDeadZone = 0.5f;
        playerController.Down.UpperDeadZone = 0.9f;
        playerController.Right.Raw = false;

        playerController.Right.LowerDeadZone = 0.5f;
        playerController.Right.UpperDeadZone = 0.9f;


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
