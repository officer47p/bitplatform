﻿namespace Bit.BlazorUI.Demo.Client.Core.Pages.Components.Inputs.Rating;

public partial class BitRatingDemo
{
    private readonly List<ComponentParameter> componentParameters = new()
    {
        new()
        {
            Name = "AllowZeroStars",
            Type = "bool",
            DefaultValue = "false",
            Description = "Allow the initial rating value be 0. Note that a value of 0 still won't be selectable by mouse or keyboard.",
        },
        new()
        {
            Name = "AriaLabelFormat",
            Type = "string?",
            DefaultValue = "null",
            Description = "Optional label format for each individual rating star (not the rating control as a whole) that will be read by screen readers.",
        },
        new()
        {
            Name = "Classes",
            Type = "BitRatingClassStyles?",
            DefaultValue = "null",
            LinkType = LinkType.Link,
            Href = "#rating-class-styles",
            Description = "Custom CSS classes for different parts of the BitRating.",
        },
        new()
        {
            Name = "DefaultValue",
            Type = "double?",
            DefaultValue = "null",
            Description = "Default rating. Must be a number between min and max. Only provide this if the Rating is an uncontrolled component; otherwise, use the rating property.",
        },
        new()
        {
            Name = "GetAriaLabel",
            Type = "Func<double, double, string>?",
            DefaultValue = "null",
            Description = "Optional callback to set the aria-label for rating control in readOnly mode. Also used as a fallback aria-label if ariaLabel prop is not provided.",
        },
        new()
        {
            Name = "IsReadOnly",
            Type = "bool",
            DefaultValue = "false",
            Description = "A flag to mark rating control as readOnly.",
        },
        new()
        {
            Name = "Max",
            Type = "int",
            DefaultValue = "5",
            Description = "Maximum rating. Must be >= min (0 if AllowZeroStars is true, 1 otherwise).",
        },
        new()
        {
            Name = "OnChange",
            Type = "EventCallback<double>",
            Description = "Callback that is called when the rating has changed.",
        },
        new()
        {
            Name = "SelectedIconName",
            Type = "string",
            DefaultValue = "FavoriteStarFill",
            Description = "Custom icon name for selected rating elements.",
        },
        new()
        {
            Name = "Size",
            Type = "BitRatingSize",
            DefaultValue = "BitRatingSize.Small",
            LinkType = LinkType.Link,
            Href = "#rating-size-enum",
            Description = "Size of rating.",
        },
        new()
        {
            Name = "Styles",
            Type = "BitRatingClassStyles?",
            DefaultValue = "null",
            LinkType = LinkType.Link,
            Href = "#rating-class-styles",
            Description = "Custom CSS styles for different parts of the BitRating.",
        },
        new()
        {
            Name = "UnselectedIconName",
            Type = "string",
            DefaultValue = "FavoriteStar",
            Description = "Custom icon name for unselected rating elements.",
        }
    };

    private readonly List<ComponentSubClass> componentSubClasses = new()
    {
        new()
        {
            Id = "rating-class-styles",
            Title = "BitRatingClassStyles",
            Description = "",
            Parameters = new()
            {
                new()
                {
                    Name = "Button",
                    Type = "string?",
                    DefaultValue = "null",
                    Description = "Custom CSS classes/styles for the rating's button.",
                },
                new()
                {
                    Name = "IconContainer",
                    Type = "string?",
                    DefaultValue = "null",
                    Description = "Custom CSS classes/styles for the rating icon container.",
                },
                new()
                {
                    Name = "SelectedIcon",
                    Type = "string?",
                    DefaultValue = "null",
                    Description = "Custom CSS classes/styles for the rating selected icon.",
                },
                new()
                {
                    Name = "UnselectedIcon",
                    Type = "string?",
                    DefaultValue = "null",
                    Description = "Custom CSS classes/styles for the rating unselected icon.",
                }
            }
        }
    };

    private readonly List<ComponentSubEnum> componentSubEnums = new()
    {
        new()
        {
            Id = "rating-size-enum",
            Name = "BitRatingSize",
            Description = "",
            Items = new()
            {
                new()
                {
                    Name = "Small",
                    Description = "Display rating icon using small size.",
                    Value = "0",
                },
                new()
                {
                    Name = "Large",
                    Description = "Display rating icon using large size.",
                    Value = "1",
                }
            }
        }
    };



    private readonly string example1HtmlCode = @"
<BitRating @bind-Value=""RatingBasicValue"" />
<BitLabel>Rate: @RatingBasicValue</BitLabel>
    
<BitRating IsEnabled=""false"" @bind-Value=""RatingDisabledValue"" />
<BitLabel>Rate: @RatingDisabledValue</BitLabel>

<BitRating IsReadOnly=""true"" @bind-Value=""RatingReadonlyValue"" />
<BitLabel>Rate: @RatingReadonlyValue</BitLabel>";
    private readonly string example1CsharpCode = @"
private double RatingBasicValue;
private double RatingDisabledValue = 2;
private double RatingReadonlyValue = 3.5;";

    private readonly string example2HtmlCode = @"
<style>
    .custom-class {
        padding: 0.5rem;
        border: 1px solid red;
        max-width: max-content;
    }

    .custom-selected {
        color: blueviolet;
    }

    .custom-unselected {
        color: darkorange;
    }
</style>


<BitRating @bind-Value=""@RatingStyleValue"" Style=""background-color: #888; border-radius: 1rem; margin: 1rem 0"" />
<BitRating @bind-Value=""@RatingClassValue"" Class=""custom-class"" />

<BitRating @bind-Value=""@RatingStylesValue""
           Styles=""@(new() {IconContainer = ""background-color: tomato; border-radius: 0.5rem"",
                            Button = ""padding: 0.5rem; background-color: goldenrod""})"" />
<BitRating @bind-Value=""@RatingClassesValue""
           Classes=""@(new() {SelectedIcon = ""custom-selected"",
                             UnselectedIcon = ""custom-unselected""})"" />";
    private readonly string example2CsharpCode = @"
private double RatingStyleValue = 1;
private double RatingClassValue = 2;
private double RatingStylesValue = 5;
private double RatingClassesValue = 3.5;";

    private readonly string example3HtmlCode = @"
Visible: [ <BitRating Visibility=""""BitVisibility.Visible"""">Visible Rating</BitRating> ]
Hidden: [ <BitRating Visibility=""""BitVisibility.Hidden"""">Hidden Rating</BitRating> ]
Collapsed: [ <BitRating Visibility=""""BitVisibility.Collapsed"""">Collapsed Rating</BitRating> ]";

    private readonly string example4HtmlCode = @"
<BitRating Max=""6"" @bind-Value=""RatingMaxValue1"" />
<BitLabel>Rate: @RatingMaxValue1</BitLabel>
    
<BitRating Max=""10"" @bind-Value=""RatingMaxValue2"" />
<BitLabel>Rate: @RatingMaxValue2</BitLabel>

<BitRating Max=""100"" @bind-Value=""RatingMaxValue3"" />
<BitLabel>Rate: @RatingMaxValue3</BitLabel>";
    private readonly string example4CsharpCode = @"
private double RatingMaxValue1 = 2.5;
private double RatingMaxValue2 = 5;
private double RatingMaxValue3 = 15;";

    private readonly string example5HtmlCode = @"
<BitRating Icon=""@BitIconName.HeartFill"" UnselectedIcon=""@BitIconName.Heart"" @bind-Value=""RatingCustomIconValue1"" />
<BitLabel>Rate: @RatingCustomIconValue1</BitLabel>
    
<BitRating Icon=""@BitIconName.CheckboxCompositeReversed"" UnselectedIcon=""@BitIconName.Checkbox"" @bind-Value=""RatingCustomIconValue2"" />
<BitLabel>Rate: @RatingCustomIconValue2</BitLabel>

<BitRating Icon=""@BitIconName.LikeSolid"" UnselectedIcon=""@BitIconName.Dislike"" @bind-Value=""RatingCustomIconValue3"" />
<BitLabel>Rate: @RatingCustomIconValue3</BitLabel>";
    private readonly string example5CsharpCode = @"
private double RatingCustomIconValue1 = 1.5;
private double RatingCustomIconValue2 = 2;
private double RatingCustomIconValue3 = 3;";

    private readonly string example6HtmlCode = @"
<BitRating Size=""BitRatingSize.Small"" @bind-Value=""RatingSmallValue"" />
<BitLabel>Rate: @RatingSmallValue</BitLabel>

<BitRating Size=""BitRatingSize.Large"" @bind-Value=""RatingLargeValue"" />
<BitLabel>Rate: @RatingLargeValue</BitLabel>";
    private readonly string example6CsharpCode = @"
private double RatingSmallValue = 3;
private double RatingLargeValue = 3;";

    private readonly string example7HtmlCode = @"
<BitRating AllowZeroStars=""true"" Value=""RatingControlledValue1"" />
<BitToggleButton OnChange=""(v) =>  RatingControlledValue1 = v ? 5 : 0"" Text=""@(RatingControlledValue1 == 5 ? ""Unstar All"" : ""Star All"")"" />

<BitRating Max=""6"" @bind-Value=""RatingControlledValue2"" />
<BitSpinButton Step=""0.1"" @bind-Value=""RatingControlledValue2"" />

<BitRating DefaultValue=""2"" OnChange=""(v) => RatingControlledValue3 = v"" />
<BitLabel>Rate: @RatingControlledValue3</BitLabel>";
    private readonly string example7CsharpCode = @"
private double RatingControlledValue1 = 0;
private double RatingControlledValue2 = 3;
private double RatingControlledValue3;";

    private readonly string example8HtmlCode = @"
@if (string.IsNullOrEmpty(SuccessMessage))
{
    <EditForm Model=""ValidationModel"" OnValidSubmit=""HandleValidSubmit"" OnInvalidSubmit=""HandleInvalidSubmit"">

        <DataAnnotationsValidator />

        <div class=""validation-summary"">
            <ValidationSummary />
        </div>

        <BitRating AllowZeroStars=""true"" @bind-Value=""ValidationModel.Value"" />
        <ValidationMessage For=""@(() => ValidationModel.Value)"" />

        <BitButton ButtonType=""BitButtonType.Submit"">Submit</BitButton>
    </EditForm>
}
else
{
    <BitMessageBar MessageBarType=""BitMessageBarType.Success"" IsMultiline=""false"">
        @SuccessMessage
    </BitMessageBar>
}";
    private readonly string example8CsharpCode = @"
public class BitRatingDemoFormModel
{
    [Range(typeof(double), ""1"", ""5"", ErrorMessage = ""Your rate must be between {1} and {2}"")]
    public double Value { get; set; }
}

public BitRatingDemoFormModel ValidationModel = new();
public string SuccessMessage;

private async Task HandleValidSubmit()
{
    SuccessMessage = ""Form Submitted Successfully!"";
    await Task.Delay(2000);
    SuccessMessage = string.Empty;
    ValidationModel.Value = default;
    StateHasChanged();
}

private void HandleInvalidSubmit()
{
    SuccessMessage = string.Empty;
}";
}
