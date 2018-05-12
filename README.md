# XMap
A Windows XInput Manager for binding controller keys to custom macros. I created this because I couldn't find anything out there
that fit what I wanted and was free. So I wrote my own! To those interested in helping please make a [pull request](https://github.com/lzinga/XMap/pulls), I
am sure there is some improvements that could be made and I welcome them!

If you can't contribute directly in programming but have a problem just open an [issue](https://github.com/lzinga/XMap/issues) and hopefully I or someone
else can get to it!

# XML Macro Config file
XMap loads an xml file from the `\Configs\` folder, right now it only supports a predefined one but will probably make it support more later. Here is an example of a fully working config file that I created for myself. Past it, you will find a list of all actions/conditions currently available.

```xml
<?xml version="1.0" encoding="utf-16"?>
<Mapping xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Macro Name="Stop Project64">
    <Conditions>
      <Condition xsi:type="ButtonsPressed" Key="Start, Back" />
      <Condition xsi:type="Hold" Key="5" />
    </Conditions>
    <Actions>
      <Action xsi:type="Key" Modifier="Shift" Key="F8" />
      <Action xsi:type="Vibrate" Amount="25" Duration="1" />
    </Actions>
  </Macro>
</Mapping>
```


### Conditions
A Macro requires conditions, XMap will check these conditions on button presses to see if any of them match.
If one matches it will execute the `Actions` (see the actions area below).

The following XML conditions are all currently available and working (as far as I know). Each macro is checked based on the amount of conditions
they have. So ones with the most are checked first, and the ones with the least are checked last.
```xml
<Conditions>
    <!-- Checks if the current active process being interacted with is the `Key` -->
    <Condition xsi:type="ActiveProcess" Key="Discord.exe" />

    <!-- Checks if the left trigger is greater or equal to the `Key` value. (0-100) -->
    <Condition xsi:type="LeftTrigger" Key="100" />

    <!-- Checks if the right trigger is greater or equal to the `Key` value. (0-100) -->
    <Condition xsi:type="RighTrigger" Key="50" />

    <!-- Checks if the current combination of buttons is equal to `Key` value. (Buttons must be entered as they appear below) -->
    <!-- For example, if you wanted DpadLeft, Start, and A it would be written as 'DpadLeft, Start, A', case doesn't matter but spaces do (for now)-->
    <!-- DPadUp, DpadDown, DpadLeft, DpadRight, Start, Back, LeftThumb, RightThumb, LeftShoulder, RightShoulder, A, B, X, Y -->
    <Condition xsi:type="ButtonsPressed" Key="A, B" />

    <!-- Checks if the buttons have been held for a certain amount of seconds using `Key` value. (In seconds) -->
    <Condition xsi:type="Hold" Key="5" />
</Conditions>
```

### Actions
When the specified conditions are met using the aforementioned structure the actions will be executed.
To also note, all actions will be executed in what ever application is currently the active window.
```xml
<Actions>
    <!-- Presses the keys with the included modifiers, each new letter/modifier should be separated with a comma. -->
    <Action xsi:type="Key" Modifier="Control, Shift" Key="A" />

    <!-- Will output text. -->
    <Action xsi:type="Text" Key="This text will appear where ever the cursor is located!" />

    <!-- Will make the controller vibrate. (Duration can be a double value) -->
    <Action xsi:type="Vibrate" Amount="(1-100)"  Duration="1" />
</Actions>
```

### Creation of Actions and Conditions
To create an action or condition all you have to do is create a new class and inherit the `BaseAction` or `BaseCondition` object. Here are two examples showing what an action and a condition look like -

#### Action
```csharp
[XmlType(TypeName = "Text")]
public class TextAction : BaseAction
{
    [XmlAttribute]
    public string Key { get; set; }

    public override void Execute()
    {
        this.input.Text(this.Key);
    }

    public override string ToString()
    {
        return $"Writing \"{this.Key}\".";
    }
}
```

#### Condition
```csharp
[XmlType(TypeName = "Hold")]
public class HoldCondition : BaseCondition
{
    [XmlAttribute]
    public int Key { get; set; }

    public override bool Validate(XInputControllerState controller, WindowManager window)
    {
        if (controller.CurrentHoldTime.TotalSeconds >= this.Key && controller.HoldingButtons)
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: has it been held for {this.Key} seconds?";
    }
}
```
