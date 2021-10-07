using IJunior.TypedScenes;

public class PlayButton : MenuButton
{
    protected override void OnClick() => MainLevel.Load();
}
