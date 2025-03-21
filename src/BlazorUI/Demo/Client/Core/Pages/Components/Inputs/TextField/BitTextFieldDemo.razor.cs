﻿namespace Bit.BlazorUI.Demo.Client.Core.Pages.Components.Inputs.TextField;

public partial class BitTextFieldDemo
{
    private readonly List<ComponentParameter> componentParameters = new()
    {
        new()
        {
            Name = "AutoComplete",
            Type = "string?",
            DefaultValue = "null",
            Description = "AutoComplete is a string that maps to the autocomplete attribute of the HTML input element.",
        },
        new()
        {
            Name = "AutoFocus",
            Type = "bool",
            DefaultValue = "false",
            Description = "Determines if the text field is auto focused on first render.",
        },
        new()
        {
            Name = "CanRevealPassword",
            Type = "bool",
            DefaultValue = "false",
            Description = "Whether to show the reveal password button for input type 'password'.",
        },
        new()
        {
            Name = "DefaultValue",
            Type = "string?",
            DefaultValue = "null",
            Description = "Default value of the text field. Only provide this if the text field is an uncontrolled component; otherwise, use the value property.",
        },
        new()
        {
            Name = "Description",
            Type = "string?",
            DefaultValue = "null",
            Description = "Description displayed below the text field to provide additional details about what text to enter.",
        },
        new()
        {
            Name = "DescriptionTemplate",
            Type = "RenderFragment?",
            DefaultValue = "null",
            Description = "Shows the custom description for text field.",
        },
        new()
        {
            Name = "HasBorder",
            Type = "bool",
            DefaultValue = "true",
            Description = "Whether or not the text field is borderless.",
        },
        new()
        {
            Name = "IsMultiline",
            Type = "bool",
            DefaultValue = "false",
            Description = "Whether or not the text field is a Multiline text field.",
        },
        new()
        {
            Name = "IsReadonly",
            Type = "bool",
            DefaultValue = "false",
            Description = "If true, the text field is readonly.",
        },
        new()
        {
            Name = "IsRequired",
            Type = "bool",
            DefaultValue = "false",
            Description = "Whether the associated input is required or not, add an asterisk \"*\" to its label.",
        },
        new()
        {
            Name = "IsUnderlined",
            Type = "bool",
            DefaultValue = "false",
            Description = "Whether or not the text field is underlined.",
        },
        new()
        {
            Name = "IsResizable",
            Type = "bool",
            DefaultValue = "true",
            Description = "For multiline text fields, whether or not the field is resizable.",
        },
        new()
        {
            Name = "IconName",
            Type = "string?",
            DefaultValue = "null",
            Description = "The icon name for the icon shown in the far right end of the text field.",
        },
        new()
        {
            Name = "IsTrimmed",
            Type = "bool",
            DefaultValue = "false",
            Description = "Specifies whether to remove any leading or trailing whitespace from the value.",
        },
        new()
        {
            Name = "Label",
            Type = "string?",
            DefaultValue = "null",
            Description = "Label displayed above the text field and read by screen readers.",
        },
        new()
        {
            Name = "LabelTemplate",
            Type = "RenderFragment?",
            DefaultValue = "null",
            Description = "Shows the custom label for text field.",
        },
        new()
        {
            Name = "MaxLength",
            Type = "int",
            DefaultValue = "-1",
            Description = "Specifies the maximum number of characters allowed in the input.",
        },
        new()
        {
            Name = "OnFocus",
            Type = "EventCallback<FocusEventArgs>",
            Description = "Callback for when focus moves into the input.",
        },
        new()
        {
            Name = "OnFocusIn",
            Type = "EventCallback<FocusEventArgs>",
            Description = "Callback for when focus moves into the input.",
        },
        new()
        {
            Name = "OnFocusOut",
            Type = "EventCallback<FocusEventArgs>",
            Description = "Callback for when focus moves out of the input.",
        },
        new()
        {
            Name = "OnKeyDown",
            Type = "EventCallback<KeyboardEventArgs>",
            Description = "Callback for when a keyboard key is pressed.",
        },
        new()
        {
            Name = "OnKeyUp",
            Type = "EventCallback<KeyboardEventArgs>",
            Description = "Callback for When a keyboard key is released.",
        },
        new()
        {
            Name = "OnChange",
            Type = "EventCallback<string?>",
            Description = "Callback for when the input value changes. This is called on both input and change events.",
        },
        new()
        {
            Name = "OnClick",
            Type = "EventCallback<MouseEventArgs>",
            Description = "Callback for when the input clicked.",
        },
        new()
        {
            Name = "Placeholder",
            Type = "string?",
            DefaultValue = "null",
            Description = "Input placeholder text.",
        },
        new()
        {
            Name = "Prefix",
            Type = "string?",
            DefaultValue = "null",
            Description = "Prefix displayed before the text field contents. This is not included in the value. \r\n Ensure a descriptive label is present to assist screen readers, as the value does not include the prefix.",
        },
        new()
        {
            Name = "PrefixTemplate",
            Type = "RenderFragment?",
            DefaultValue = "null",
            Description = "Shows the custom prefix for text field.",
        },
        new()
        {
            Name = "Rows",
            Type = "int",
            DefaultValue = "3",
            Description = "For multiline text, Number of rows.",
        },
        new()
        {
            Name = "RevealPasswordAriaLabel",
            Type = "string?",
            DefaultValue = "null",
            Description = "Suffix displayed after the text field contents. This is not included in the value. \r\n Ensure a descriptive label is present to assist screen readers, as the value does not include the suffix.",
        },
        new()
        {
            Name = "Suffix",
            Type = "string?",
            DefaultValue = "null",
            Description = "Suffix displayed after the text field contents. This is not included in the value. \r\n Ensure a descriptive label is present to assist screen readers, as the value does not include the suffix.",
        },
        new()
        {
            Name = "SuffixTemplate",
            Type = "RenderFragment?",
            DefaultValue = "null",
            Description = "Shows the custom suffix for text field.",
        },
        new()
        {
            Name = "Type",
            Type = "BitTextFieldType",
            DefaultValue = "BitTextFieldType.Text",
            Description = "Input type.",
            LinkType = LinkType.Link,
            Href = "#text-field-type-enum"
        },
        new()
        {
            Name = "LabelStyle",
            Type = "string?",
            DefaultValue = "null",
            Description = "Style of the BitTextField's Label.",
        },
        new()
        {
            Name = "LabelClass",
            Type = "string?",
            DefaultValue = "null",
            Description = "CSS class of the BitTextField's Label.",
        },
        new()
        {
            Name = "InputStyle",
            Type = "string?",
            DefaultValue = "null",
            Description = "Style of the BitTextField's Input.",
        },
        new()
        {
            Name = "InputClass",
            Type = "string?",
            DefaultValue = "null",
            Description = "CSS class of the BitTextField's Input.",
        },
        new()
        {
            Name = "PrefixStyle",
            Type = "string?",
            DefaultValue = "null",
            Description = "Style of the BitTextField's Prefix.",
        },
        new()
        {
            Name = "PrefixClass",
            Type = "string?",
            DefaultValue = "null",
            Description = "CSS class of the BitTextField's Prefix.",
        },
        new()
        {
            Name = "SuffixStyle",
            Type = "string?",
            DefaultValue = "null",
            Description = "Style of the BitTextField's Suffix.",
        },
        new()
        {
            Name = "SuffixClass",
            Type = "string?",
            DefaultValue = "null",
            Description = "CSS class of the BitTextField's Suffix.",
        },
        new()
        {
            Name = "RevealPasswordStyle",
            Type = "string?",
            DefaultValue = "null",
            Description = "Style of the BitTextField's RevealPassword button.",
        },
        new()
        {
            Name = "RevealPasswordClass",
            Type = "string?",
            DefaultValue = "null",
            Description = "CSS class of the BitTextField's RevealPassword button.",
        },
        new()
        {
            Name = "DescriptionStyle",
            Type = "string?",
            DefaultValue = "null",
            Description = "Style of the BitTextField's Description.",
        },
        new()
        {
            Name = "DescriptionClass",
            Type = "string?",
            DefaultValue = "null",
            Description = "CSS class of the BitTextField's Description.",
        },
    };
    private readonly List<ComponentSubEnum> componentSubEnums = new()
    {
        new()
        {
            Id = "text-field-type-enum",
            Name = "BitTextFieldType",
            Description = "",
            Items = new()
            {
                new()
                {
                    Name= "Text",
                    Description="The TextField characters are shown as text.",
                    Value="0",
                },
                new()
                {
                    Name= "Password",
                    Description="The TextField characters are masked.",
                    Value="1",
                },
                new()
                {
                    Name= "Number",
                    Description="The TextField characters are number.",
                    Value="2",
                },
                new()
                {
                    Name= "Email",
                    Description="The TextField act as an email input.",
                    Value="3",
                },
                new()
                {
                    Name= "Tel",
                    Description="The TextField act as a tel input.",
                    Value="4",
                },
                new()
                {
                    Name= "Url",
                    Description="The TextField act as a url input.",
                    Value="5",
                }
            }
        }
    };



    private readonly string example1HtmlCode = @"
<BitTextField Placeholder=""Enter a text..."" Label=""Basic"" />

<BitTextField Placeholder=""Enter a text..."" Label=""Disabled"" IsEnabled=""false"" />

<BitTextField Placeholder=""Enter a text..."" Label=""Description"" Description=""This is Description"" />

<BitTextField Placeholder=""Enter a text..."" Label=""IsRequired"" IsRequired=""true"" />

<BitTextField Placeholder=""Enter a text..."" Label=""MaxLength: 5"" MaxLength=""5"" />";
    private readonly string example2HtmlCode = @"
<BitTextField Placeholder=""Enter a text..."" AutoFocus=""true"" Label=""Auto focused"" />";

    private readonly string example3HtmlCode = @"
<BitTextField Placeholder=""Enter a text..."" Label=""Basic"" IsUnderlined=""true"" />

<BitTextField Placeholder=""Enter a text..."" Label=""Required"" IsUnderlined=""true"" IsRequired=""true"" />

<BitTextField Placeholder=""Enter a text..."" Label=""Disabled"" IsUnderlined=""true"" IsEnabled=""false"" />";

    private readonly string example4HtmlCode = @"
<BitTextField Placeholder=""Enter a text..."" Label=""Basic No Border"" HasBorder=""false"" />

<BitTextField Placeholder=""Enter a text..."" Label=""Required No Border"" HasBorder=""false"" IsRequired=""true"" />

<BitTextField Placeholder=""Enter a text..."" Label=""Disabled No Border"" HasBorder=""false"" IsEnabled=""false"" />";

    private readonly string example5HtmlCode = @"
<BitTextField Placeholder=""Enter a text..."" Label=""Resizable (By default)"" IsMultiline=""true"" />

<BitTextField Placeholder=""Enter a text..."" Label=""Unresizable (Fixed)"" IsMultiline=""true"" IsResizable=""false"" />

<BitTextField Placeholder=""Enter a text..."" Label=""Row count (10)"" IsMultiline=""true"" Rows=""10"" />";

    private readonly string example6HtmlCode = @"
<BitTextField Placeholder=""Enter an email..."" Label=""Email Icon"" IconName=""@BitIconName.EditMail"" />

<BitTextField Placeholder=""Enter a date..."" Label=""Calendar Icon"" IconName=""@BitIconName.Calendar"" />";

    private readonly string example7HtmlCode = @"
<BitTextField Label=""With Prefix"" Prefix=""https://"" />

<BitTextField Label=""With Suffix"" Suffix="".com"" />

<BitTextField Label=""With Prefix and Suffix"" Prefix=""https://"" Suffix="".com"" />

<BitTextField Label=""Disabled"" Prefix=""https://"" Suffix="".com"" IsEnabled=""false"" />";

    private readonly string example8HtmlCode = @"
<BitTextField Placeholder=""Enter a text..."">
    <LabelTemplate>
        <BitLabel Style=""color: coral;"">This is custom Label</BitLabel>
    </LabelTemplate>
</BitTextField>

<BitTextField Placeholder=""Enter a text..."" Label=""This is custom Description"">
    <DescriptionTemplate>
        <BitLabel Style=""color: coral;"">Description</BitLabel>
    </DescriptionTemplate>
</BitTextField>

<BitTextField Placeholder=""Enter a text..."" Label=""This is custom Prefix"">
    <PrefixTemplate>
        <BitLabel Style=""color: coral; margin: 0 5px;"">Prefix</BitLabel>
    </PrefixTemplate>
</BitTextField>

<BitTextField Placeholder=""Enter a text..."" Label=""This is custom Suffix"">
    <SuffixTemplate>
        <BitLabel Style=""color: coral; margin: 0 5px;"">Suffix</BitLabel>
    </SuffixTemplate>
</BitTextField>";

    private readonly string example9HtmlCode = @"
<BitTextField Placeholder=""Enter a password..."" Label=""Password"" Type=""BitTextFieldType.Password"" />

<BitTextField Placeholder=""Enter a password..."" Label=""Can Reveal Password"" Type=""BitTextFieldType.Password"" CanRevealPassword=""true"" />";

    private readonly string example10HtmlCode = @"
<BitTextField Placeholder=""Enter a text..."" Label=""One-way"" Value=""@OneWayValue"" />
<BitOtpInput Length=""4"" Style=""margin-top: 5px;"" @bind-Value=""OneWayValue"" />

<BitTextField Placeholder=""Enter a text..."" Label=""Two-way"" @bind-Value=""TwoWayValue"" />
<BitOtpInput Length=""4"" Style=""margin-top: 5px;"" @bind-Value=""TwoWayValue"" />

<BitTextField Placeholder=""Enter a text..."" Label=""OnChange"" OnChange=""(v) => OnChangeValue = v"" />
<BitLabel>Value: @OnChangeValue</BitLabel>

<BitTextField Placeholder=""Enter a text..."" Label=""Readonly"" @bind-Value=""ReadOnlyValue"" IsReadonly=""true"" />";
    private readonly string example10CsharpCode = @"
private string OneWayValue;
private string TwoWayValue;
private string OnChangeValue;
private string ReadOnlyValue = ""this is readonly value"";";

    private readonly string example11HtmlCode = @"
<BitTextField Placeholder=""Enter a text..."" Label=""Trimmed"" IsTrimmed=""true"" @bind-Value=""TrimmedValue"" />
<pre class=""trimmed-box"">[@TrimmedValue]</pre>

<BitTextField Placeholder=""Enter a text..."" Label=""Not Trimmed"" @bind-Value=""NotTrimmedValue"" />
<pre class=""trimmed-box"">[@NotTrimmedValue]</pre>";
    private readonly string example11CsharpCode = @"
private string TrimmedValue;
private string NotTrimmedValue;";

    private readonly string example12HtmlCode = @"
<style>
    .custom-label {
        color: blue;
        font-weight: 900;
        font-size: 18px;
    }

    .custom-input {
        color: darkgreen;
        font-weight: 900;
        font-size: 18px;
        padding: 1rem;
        height: 50px;
    }
</style>

<BitTextField Placeholder=""Enter a text..."" Label=""Custom LabelStyle"" LabelStyle=""color:green"" />
<BitTextField Placeholder=""Enter a text..."" Label=""Custom LabelClass"" LabelClass=""custom-label"" />

<BitTextField Placeholder=""Enter a text..."" Label=""Custom InputStyle"" InputStyle=""color:red"" />
<BitTextField Placeholder=""Enter a text..."" Label=""Custom InputClass"" InputClass=""custom-input"" />";

    private readonly string example13HtmlCode = @"
<style>
    .validation-summary {
        overflow: hidden;
        margin-bottom: 10px;
        background-color: #FDE7E9;
        border-left: 5px solid #d13438;
    }

    ::deep {
        .validation-message {
            color: #A4262C;
            font-size: 12px;
            margin-top: 5px;
            line-height: normal;
        }

        .validation-errors {
            margin: 5px;
        }
    }
</style>

@if (formIsValidSubmit is false)
{
    <EditForm Model=""validationTextFieldModel"" OnValidSubmit=""HandleValidSubmit"" OnInvalidSubmit=""HandleInvalidSubmit"">
        <DataAnnotationsValidator />
        <div class=""validation-summary"">
            <ValidationSummary />
        </div>
        <div class=""form-item"">
            <BitTextField Label=""Required"" IsRequired=""true"" @bind-Value=""validationTextFieldModel.Text"" />
            <ValidationMessage For=""() => validationTextFieldModel.Text"" />
        </div>
        <div class=""form-item"">
            <BitTextField Label=""Numeric validation"" @bind-Value=""validationTextFieldModel.NumericText"" />
            <ValidationMessage For=""() => validationTextFieldModel.NumericText"" />
        </div>
        <div class=""form-item"">
            <BitTextField Label=""Character validation"" @bind-Value=""validationTextFieldModel.CharacterText"" />
            <ValidationMessage For=""() => validationTextFieldModel.CharacterText"" />
        </div>
        <div class=""form-item"">
            <BitTextField Label=""Email format validation"" @bind-Value=""validationTextFieldModel.EmailText"" />
            <ValidationMessage For=""() => validationTextFieldModel.EmailText"" />
        </div>
        <div class=""form-item"">
            <BitTextField Label=""Length character validation (Min: 3, Max: 5)"" MaxLength=""5"" @bind-Value=""validationTextFieldModel.RangeText"" />
            <ValidationMessage For=""() => validationTextFieldModel.RangeText"" />
        </div>

        <BitButton ButtonType=""BitButtonType.Submit"" Style=""margin-top: 10px;"">
            Submit
        </BitButton>
    </EditForm>
}
else
{
    <BitMessageBar MessageBarType=""BitMessageBarType.Success"" IsMultiline=""false"">
        The form is valid to submit successfully.
    </BitMessageBar>
}";
    private readonly string example13CsharpCode = @"
public class ValidationTextFieldModel
{
    [Required]
    public string Text { get; set; }

    [RegularExpression(""0*[1-9][0-9]*"", ErrorMessage = ""Only numeric values are allow in field."")]
    public string NumericText { get; set; }

    [RegularExpression(""^[a-zA-Z0-9.]*$"", ErrorMessage = ""Sorry, only letters(a-z), numbers(0-9), and periods(.) are allowed."")]
    public string CharacterText { get; set; }

    [EmailAddress(ErrorMessage = ""Invalid e-mail address."")]
    public string EmailText { get; set; }

    [StringLength(maximumLength: 5, MinimumLength = 3, ErrorMessage = ""The text length much be between 3 and 5 characters in length."")]
    public string RangeText { get; set; }
}

private ValidationTextFieldModel validationTextFieldModel = new();
public bool formIsValidSubmit;
private async Task HandleValidSubmit()
{
    formIsValidSubmit = true;

    await Task.Delay(2000);

    validationTextFieldModel = new();

    formIsValidSubmit = false;

    StateHasChanged();
}

private void HandleInvalidSubmit()
{
    formIsValidSubmit = false;
}";
}
