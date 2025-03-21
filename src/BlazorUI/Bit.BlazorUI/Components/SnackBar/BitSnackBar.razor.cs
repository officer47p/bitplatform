﻿using System.Timers;

namespace Bit.BlazorUI;

public partial class BitSnackBar
{
    private BitSnackBarPosition position = BitSnackBarPosition.BottomRight;

    private List<BitSnackBarItem> _items = new();

    /// <summary>
    /// Whether or not to dismiss itself automatically.
    /// </summary>
    [Parameter] public bool AutoDismiss { get; set; } = true;

    /// <summary>
    /// How long the SnackBar will automatically dismiss (default is 3 seconds).
    /// </summary>
    [Parameter] public TimeSpan AutoDismissTime { get; set; } = TimeSpan.FromSeconds(3);

    /// <summary>
    /// Used to customize how content inside the Body is rendered. 
    /// </summary>
    [Parameter] public RenderFragment<string>? BodyTemplate { get; set; }

    /// <summary>
    /// Dismiss Icon in SnackBar.
    /// </summary>
    [Parameter] public string DismissIconName { get; set; } = "Cancel";

    /// <summary>
    /// Callback for when the Dismissed.
    /// </summary>
    [Parameter] public EventCallback OnDismiss { get; set; }

    /// <summary>
    /// The position of SnackBar to show.
    /// </summary>
    [Parameter]
    public BitSnackBarPosition Position
    {
        get => position;
        set
        {
            position = value;
            ClassBuilder.Reset();
        }
    }

    /// <summary>
    /// Used to customize how content inside the Title is rendered. 
    /// </summary>
    [Parameter] public RenderFragment<string>? TitleTemplate { get; set; }


    public async Task Show(string title, string? body = "", BitSnackBarType? type = BitSnackBarType.Info)
    {
        var item = new BitSnackBarItem
        {
            Title = title,
            Body = body,
            Type = type
        };

        if (AutoDismiss)
        {
            var timer = new System.Timers.Timer(AutoDismissTime.TotalMilliseconds);
            timer.Elapsed += (_, _) =>
            {
                timer.Close();
                Dismiss(item);
            };
            timer.Start();
        }

        _items.Add(item);

        await InvokeAsync(StateHasChanged);
    }

    public Task Info(string title, string? body = "") => Show(title, body, BitSnackBarType.Info);

    public Task Success(string title, string? body = "") => Show(title, body, BitSnackBarType.Success);

    public Task Warning(string title, string? body = "") => Show(title, body, BitSnackBarType.Warning);

    public Task Error(string title, string? body = "") => Show(title, body, BitSnackBarType.Error);



    protected override string RootElementClass => "bit-snb";

    protected override void RegisterCssClasses()
    {
        ClassBuilder.Register(() => Position switch
        {
            BitSnackBarPosition.TopLeft => $"{RootElementClass}-tlf",
            BitSnackBarPosition.TopCenter => $"{RootElementClass}-tcn",
            BitSnackBarPosition.TopRight => $"{RootElementClass}-trt",
            BitSnackBarPosition.BottomLeft => $"{RootElementClass}-blf",
            BitSnackBarPosition.BottomCenter => $"{RootElementClass}-bcn",
            BitSnackBarPosition.BottomRight => $"{RootElementClass}-brt",
            _ => string.Empty
        });
    }



    private void Dismiss(BitSnackBarItem item)
    {
        _items.Remove(item);

        OnDismiss.InvokeAsync();

        InvokeAsync(StateHasChanged);
    }

    private string GetItemClasses(BitSnackBarItem item) => item.Type switch
    {
        BitSnackBarType.Info => $"{RootElementClass}-info",
        BitSnackBarType.Warning => $"{RootElementClass}-warning",
        BitSnackBarType.Success => $"{RootElementClass}-success",
        BitSnackBarType.Error => $"{RootElementClass}-error",
        BitSnackBarType.SevereWarning => $"{RootElementClass}-severe-warning",
        _ => string.Empty
    };
}
