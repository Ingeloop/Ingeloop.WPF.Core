# Ingeloop.WPF.Core
Core Library for WPF (base classes, converters)

## Quick guide:

### 1) BaseViewModel:

Create a class that inherits from BaseViewModel:

```C#
public class ChatViewModel : BaseViewModel
```

It will give access to the OnPropertyChanged void:

```C#
private int progress;

public int Progress
{
    get
    {
        return progress;
    }
    set
    {
        progress = value;
        OnPropertyChanged(nameof(Progress));
    }
}
```

### 2) RelayCommand implementation:

Example of basic Command:

```C#
public ICommand UpdateProgressCommand
{
    get
    {
        return new RelayCommand(UpdateProgress);
    }
}
```

Example of Command with parameter:

```C#
public ICommand AddUserCommand
{
    get
    {
        return new RelayCommand<User>(AddUser);
    }
}
```

### 3) Converters:

Load the resource to your UI, as follow:

```xaml
<ResourceDictionary Source="pack://application:,,,/Ingeloop.WPF.Core;component/Resources/Converters.xaml"/>
```

And use the converters as follow:

```xaml
<ProgressBar
    Value="{Binding Progress}"
    Visibility="{Binding Progress, Converter={StaticResource ProgressToVisibilityConverter}}">
</ProgressBar>
```

## Demo:

[Demo Project](https://github.com/Ingeloop/Ingeloop.WPF.Core/tree/master/Ingeloop.WPF.Core.Demo)
