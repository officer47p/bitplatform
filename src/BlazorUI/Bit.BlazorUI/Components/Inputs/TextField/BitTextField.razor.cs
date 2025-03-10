﻿using System.Diagnostics.CodeAnalysis;

namespace Bit.BlazorUI;

public partial class BitTextField
{
    private bool hasBorder = true;
    private bool isMultiline;
    private bool isReadonly;
    private bool isRequired;
    private bool isUnderlined;
    private bool isResizable = true;
    private BitTextFieldType type = BitTextFieldType.Text;
    private string focusClass = string.Empty;

    private ElementReference _inputRef = default!;
    private string _inputId = string.Empty;
    private string _inputType = string.Empty;
    private string _labelId = string.Empty;
    private string _descriptionId = string.Empty;
    private bool _isPasswordRevealed;
    private BitTextFieldType _elementType;

    private string _focusClass
    {
        get => focusClass;
        set
        {
            if (focusClass == value) return;

            focusClass = value;
            ClassBuilder.Reset();
        }
    }

    /// <summary>
    /// AutoComplete is a string that maps to the autocomplete attribute of the HTML input element.
    /// </summary>
    [Parameter] public string? AutoComplete { get; set; }

    /// <summary>
    /// Determines if the text field is auto focused on first render.
    /// </summary>
    [Parameter] public bool AutoFocus { get; set; }

    /// <summary>
    /// Whether to show the reveal password button for input type 'password'.
    /// </summary>
    [Parameter] public bool CanRevealPassword { get; set; }

    /// <summary>
    /// Default value of the text field. Only provide this if the text field is an uncontrolled component; otherwise, use the value property.
    /// </summary>
    [Parameter] public string? DefaultValue { get; set; }

    /// <summary>
    /// Description displayed below the text field to provide additional details about what text to enter.
    /// </summary>
    [Parameter] public string? Description { get; set; }

    /// <summary>
    /// Shows the custom description for text field.
    /// </summary>
    [Parameter] public RenderFragment? DescriptionTemplate { get; set; }

    /// <summary>
    /// Whether or not the text field is borderless.
    /// </summary>
    [Parameter]
    public bool HasBorder
    {
        get => hasBorder;
        set
        {
            if (hasBorder == value) return;

            hasBorder = value;
            ClassBuilder.Reset();
        }
    }

    /// <summary>
    /// Whether or not the text field is a Multiline text field.
    /// </summary>
    [Parameter]
    public bool IsMultiline
    {
        get => isMultiline;
        set
        {
            if (isMultiline == value) return;

            isMultiline = value;
            ClassBuilder.Reset();
        }
    }

    /// <summary>
    /// If true, the text field is readonly.
    /// </summary>
    [Parameter]
    public bool IsReadonly
    {
        get => isReadonly;
        set
        {
            if (isReadonly == value) return;

            isReadonly = value;
            ClassBuilder.Reset();
        }
    }

    /// <summary>
    /// Whether the associated input is required or not, add an asterisk "*" to its label.
    /// </summary>
    [Parameter]
    public bool IsRequired
    {
        get => isRequired;
        set
        {
            if (isRequired == value) return;

            isRequired = value;
            ClassBuilder.Reset();
        }
    }

    /// <summary>
    /// Whether or not the text field is underlined.
    /// </summary>
    [Parameter]
    public bool IsUnderlined
    {
        get => isUnderlined;
        set
        {
            if (isUnderlined == value) return;

            isUnderlined = value;
            ClassBuilder.Reset();
        }
    }

    /// <summary>
    /// For multiline text fields, whether or not the field is resizable.
    /// </summary>
    [Parameter]
    public bool IsResizable
    {
        get => isResizable;
        set
        {
            if (isResizable == value) return;

            isResizable = value;
            ClassBuilder.Reset();
        }
    }

    /// <summary>
    /// The icon name for the icon shown in the far right end of the text field.
    /// </summary>
    [Parameter] public string? IconName { get; set; }

    /// <summary>
    /// Specifies whether to remove any leading or trailing whitespace from the value.
    /// </summary>
    [Parameter] public bool IsTrimmed { get; set; }

    /// <summary>
    /// Label displayed above the text field and read by screen readers.
    /// </summary>
    [Parameter] public string? Label { get; set; }

    /// <summary>
    /// Shows the custom label for text field.
    /// </summary>
    [Parameter] public RenderFragment? LabelTemplate { get; set; }

    /// <summary>
    /// Specifies the maximum number of characters allowed in the input.
    /// </summary>
    [Parameter] public int MaxLength { get; set; } = -1;

    /// <summary>
    /// Callback for when the input value changes. This is called on both input and change events. 
    /// </summary>
    [Parameter] public EventCallback<string?> OnChange { get; set; }

    /// <summary>
    /// Callback for when focus moves into the input
    /// </summary>
    [Parameter] public EventCallback<FocusEventArgs> OnFocusIn { get; set; }

    /// <summary>
    /// Callback for when focus moves out of the input
    /// </summary>
    [Parameter] public EventCallback<FocusEventArgs> OnFocusOut { get; set; }

    /// <summary>
    /// Callback for when focus moves into the input
    /// </summary>
    [Parameter] public EventCallback<FocusEventArgs> OnFocus { get; set; }

    /// <summary>
    /// Callback for when a keyboard key is pressed
    /// </summary>
    [Parameter] public EventCallback<KeyboardEventArgs> OnKeyDown { get; set; }

    /// <summary>
    /// Callback for When a keyboard key is released
    /// </summary>
    [Parameter] public EventCallback<KeyboardEventArgs> OnKeyUp { get; set; }

    /// <summary>
    /// Callback for when the input clicked.
    /// </summary>
    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    /// <summary>
    /// Input placeholder text.
    /// </summary>
    [Parameter] public string? Placeholder { get; set; }

    /// <summary>
    /// Prefix displayed before the text field contents. This is not included in the value.
    /// Ensure a descriptive label is present to assist screen readers, as the value does not include the prefix.
    /// </summary>
    [Parameter] public string? Prefix { get; set; }

    /// <summary>
    /// Shows the custom prefix for text field.
    /// </summary>
    [Parameter] public RenderFragment? PrefixTemplate { get; set; }

    /// <summary>
    /// For multiline text, Number of rows.
    /// </summary>
    [Parameter] public int Rows { get; set; } = 3;

    /// <summary>
    /// Aria label for the reveal password button.
    /// </summary>
    [Parameter] public string? RevealPasswordAriaLabel { get; set; }

    /// <summary>
    /// Suffix displayed after the text field contents. This is not included in the value. 
    /// Ensure a descriptive label is present to assist screen readers, as the value does not include the suffix.
    /// </summary>
    [Parameter] public string? Suffix { get; set; }

    /// <summary>
    /// Shows the custom suffix for text field.
    /// </summary>
    [Parameter] public RenderFragment? SuffixTemplate { get; set; }

    /// <summary>
    /// Input type.
    /// </summary>
    [Parameter]
    public BitTextFieldType Type
    {
        get => type;
        set
        {
            if (type == value) return;

            type = value;
            SetElementType();
            ClassBuilder.Reset();
        }
    }

    /// <summary>
    /// Style of the BitTextField's Label
    /// </summary>
    [Parameter] public string? LabelStyle { get; set; }

    /// <summary>
    /// CSS class of the BitTextField's Label
    /// </summary>
    [Parameter] public string? LabelClass { get; set; }

    /// <summary>
    /// Style of the BitTextField's Input
    /// </summary>
    [Parameter] public string? InputStyle { get; set; }

    /// <summary>
    /// CSS class of the BitTextField's Input
    /// </summary>
    [Parameter] public string? InputClass { get; set; }

    /// <summary>
    /// Style of the BitTextField's Prefix
    /// </summary>
    [Parameter] public string? PrefixStyle { get; set; }

    /// <summary>
    /// CSS class of the BitTextField's Prefix
    /// </summary>
    [Parameter] public string? PrefixClass { get; set; }

    /// <summary>
    /// Style of the BitTextField's Suffix
    /// </summary>
    [Parameter] public string? SuffixStyle { get; set; }

    /// <summary>
    /// CSS class of the BitTextField's Suffix
    /// </summary>
    [Parameter] public string? SuffixClass { get; set; }

    /// <summary>
    /// Style of the BitTextField's RevealPassword button
    /// </summary>
    [Parameter] public string? RevealPasswordStyle { get; set; }

    /// <summary>
    /// CSS class of the BitTextField's RevealPassword button
    /// </summary>
    [Parameter] public string? RevealPasswordClass { get; set; }

    /// <summary>
    /// Style of the BitTextField's Description
    /// </summary>
    [Parameter] public string? DescriptionStyle { get; set; }

    /// <summary>
    /// CSS class of the BitTextField's Description
    /// </summary>
    [Parameter] public string? DescriptionClass { get; set; }



    protected override string RootElementClass => "bit-txt";

    protected override void RegisterCssClasses()
    {
        ClassBuilder.Register(() => IsMultiline && Type == BitTextFieldType.Text
                                    ? $"{RootElementClass}-{(IsResizable ? "mln" : "mlf")}"
                                    : string.Empty);

        ClassBuilder.Register(() => IsEnabled && IsRequired ? $"{RootElementClass}-req" : string.Empty);

        ClassBuilder.Register(() => IsUnderlined ? $"{RootElementClass}-und" : string.Empty);

        ClassBuilder.Register(() => HasBorder is false ? $"{RootElementClass}-nbd" : string.Empty);

        ClassBuilder.Register(() => _focusClass);

        ClassBuilder.Register(() => IsRequired && Label is null ? $"{RootElementClass}-rnl" : string.Empty);
    }

    protected override Task OnInitializedAsync()
    {
        _inputId = $"BitTextField-{UniqueId}-input";
        _labelId = $"BitTextField-{UniqueId}-label";
        _descriptionId = $"BitTextField-{UniqueId}-description";

        if (CurrentValueAsString.HasNoValue() && DefaultValue.HasValue())
        {
            CurrentValueAsString = DefaultValue;
        }

        return base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender is false || IsEnabled is false) return;

        if (AutoFocus)
        {
            await _inputRef.FocusAsync();
        }
    }



    private void SetElementType()
    {
        _elementType = type is BitTextFieldType.Password && CanRevealPassword && _isPasswordRevealed
                         ? BitTextFieldType.Text
                         : type;

        _inputType = _elementType switch
        {
            BitTextFieldType.Text => "text",
            BitTextFieldType.Password => "password",
            BitTextFieldType.Number => "number",
            BitTextFieldType.Email => "email",
            BitTextFieldType.Tel => "tel",
            BitTextFieldType.Url => "url",
            _ => string.Empty,
        };
    }

    private async Task HandleOnFocusIn(FocusEventArgs e)
    {
        if (IsEnabled is false) return;

        _focusClass = $"{RootElementClass}-fcs";
        ClassBuilder.Reset();
        await OnFocusIn.InvokeAsync(e);
    }

    private async Task HandleOnFocusOut(FocusEventArgs e)
    {
        if (IsEnabled is false) return;

        _focusClass = string.Empty;
        ClassBuilder.Reset();
        await OnFocusOut.InvokeAsync(e);
    }

    private async Task HandleOnFocus(FocusEventArgs e)
    {
        if (IsEnabled is false) return;

        _focusClass = $"{RootElementClass}-fcs";
        ClassBuilder.Reset();
        await OnFocus.InvokeAsync(e);
    }

    private async Task HandleOnChange(ChangeEventArgs e)
    {
        if (IsEnabled is false) return;
        if (ValueHasBeenSet && ValueChanged.HasDelegate is false) return;

        CurrentValueAsString = e.Value?.ToString();
        await OnChange.InvokeAsync(CurrentValue);
    }

    private async Task HandleOnKeyDown(KeyboardEventArgs e)
    {
        if (IsEnabled is false) return;

        await OnKeyDown.InvokeAsync(e);
    }

    private async Task HandleOnKeyUp(KeyboardEventArgs e)
    {
        if (IsEnabled is false) return;

        await OnKeyUp.InvokeAsync(e);
    }

    private async Task HandleOnClick(MouseEventArgs e)
    {
        if (IsEnabled is false) return;

        await OnClick.InvokeAsync(e);
    }

    public void ToggleRevealPassword()
    {
        _isPasswordRevealed = !_isPasswordRevealed;
        SetElementType();
    }

    protected override bool TryParseValueFromString(string? value, out string? result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
        result = IsTrimmed ? value?.Trim() : value;
        validationErrorMessage = null;
        return true;
    }
}
