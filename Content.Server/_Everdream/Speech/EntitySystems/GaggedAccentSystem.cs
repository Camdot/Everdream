using System.Text.RegularExpressions;
using Content.Server._Everdream.Speech.Components;
using Content.Server.Speech;
using Content.Server.Speech.Components;
using Content.Server.Speech.EntitySystems;


namespace Content.Server._Everdream.Speech.EntitySystems;

/// <summary>
/// System that gives the speaker a gagged accent.
/// </summary>
public sealed class GaggedAccentSystem : EntitySystem
{
    private static readonly Regex RegexCh = new(@"ch", RegexOptions.IgnoreCase);
    private static readonly Regex RegexCk = new(@"ck", RegexOptions.IgnoreCase);
    private static readonly Regex RegexDg = new(@"dg", RegexOptions.IgnoreCase);
    private static readonly Regex RegexPh = new(@"ph", RegexOptions.IgnoreCase);
    private static readonly Regex RegexSh = new(@"sh", RegexOptions.IgnoreCase);
    private static readonly Regex RegexTh = new(@"th", RegexOptions.IgnoreCase);
    private static readonly Regex RegexZh = new(@"zh", RegexOptions.IgnoreCase);
    private static readonly Regex RegexC = new(@"c", RegexOptions.IgnoreCase);
    private static readonly Regex RegexD = new(@"d", RegexOptions.IgnoreCase);
    private static readonly Regex RegexJ = new(@"j", RegexOptions.IgnoreCase);
    private static readonly Regex RegexK = new(@"k", RegexOptions.IgnoreCase);
    private static readonly Regex RegexL = new(@"l", RegexOptions.IgnoreCase);
    private static readonly Regex RegexN = new(@"n", RegexOptions.IgnoreCase);
    private static readonly Regex RegexP = new(@"p", RegexOptions.IgnoreCase);
    private static readonly Regex RegexQ = new(@"q", RegexOptions.IgnoreCase);
    private static readonly Regex RegexR = new(@"r", RegexOptions.IgnoreCase);
    private static readonly Regex RegexS = new(@"s", RegexOptions.IgnoreCase);
    private static readonly Regex RegexT = new(@"t", RegexOptions.IgnoreCase);
    private static readonly Regex RegexV = new(@"v", RegexOptions.IgnoreCase);
    private static readonly Regex RegexW = new(@"w", RegexOptions.IgnoreCase);
    private static readonly Regex RegexX = new(@"x", RegexOptions.IgnoreCase);
    private static readonly Regex RegexZ = new(@"z", RegexOptions.IgnoreCase);

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<GaggedAccentComponent, AccentGetEvent>(OnAccentGet);
    }

    public string Accentuate(string message, GaggedAccentComponent component)
    {
        var msg = message;

        // Obviously a dictionary would be way cleaner but I can't be bothered to write an iterator for some silly kink code.
        msg = RegexCh.Replace(msg, "h");
        msg = RegexCk.Replace(msg, "gh");
        msg = RegexDg.Replace(msg, "gh");
        msg = RegexPh.Replace(msg, "f");
        msg = RegexSh.Replace(msg, "fh");
        msg = RegexTh.Replace(msg, "f");
        msg = RegexZh.Replace(msg, "fh");
        msg = RegexC.Replace(msg, "yh");
        msg = RegexD.Replace(msg, "gh");
        msg = RegexJ.Replace(msg, "gh");
        msg = RegexK.Replace(msg, "gh");
        msg = RegexL.Replace(msg, "w");
        msg = RegexN.Replace(msg, "m");
        msg = RegexP.Replace(msg, "bh");
        msg = RegexQ.Replace(msg, "gh");
        msg = RegexR.Replace(msg, "wh");
        msg = RegexS.Replace(msg, "f");
        msg = RegexT.Replace(msg, "g");
        msg = RegexV.Replace(msg, "f");
        msg = RegexX.Replace(msg, "gh");
        msg = RegexZ.Replace(msg, "f");

        return msg;
    }

    private void OnAccentGet(EntityUid uid, GaggedAccentComponent component, AccentGetEvent args)
    {
        args.Message = Accentuate(args.Message, component);
    }
}
