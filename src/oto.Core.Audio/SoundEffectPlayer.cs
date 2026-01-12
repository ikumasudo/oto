using System.Media;

namespace oto.Core.Audio;

public interface ISoundEffectPlayer
{
    void PlayStartSound();
    void PlayStopSound();
}

public class SoundEffectPlayer : ISoundEffectPlayer
{
    private readonly string _startSoundPath;
    private readonly string _stopSoundPath;

    public SoundEffectPlayer()
    {
        var mediaPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Windows),
            "Media");
        _startSoundPath = Path.Combine(mediaPath, "Speech On.wav");
        _stopSoundPath = Path.Combine(mediaPath, "Speech Off.wav");
    }

    public void PlayStartSound() => Task.Run(() => PlaySound(_startSoundPath));

    public void PlayStopSound() => Task.Run(() => PlaySound(_stopSoundPath));

    private static void PlaySound(string path)
    {
        if (File.Exists(path))
        {
            using var player = new SoundPlayer(path);
            player.PlaySync();
        }
    }
}
