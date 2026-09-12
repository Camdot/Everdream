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
    // Don't @ me. I know. This code infuriates me, too.
    private static readonly Regex RegexCh = new(@"ch");
    private static readonly Regex RegexCk = new(@"ck");
    private static readonly Regex RegexDg = new(@"dg");
    private static readonly Regex RegexPh = new(@"ph");
    private static readonly Regex RegexSh = new(@"sh");
    private static readonly Regex RegexTh = new(@"th");
    private static readonly Regex RegexZh = new(@"zh");
    private static readonly Regex RegexC = new(@"c");
    private static readonly Regex RegexD = new(@"d");
    private static readonly Regex RegexJ = new(@"j");
    private static readonly Regex RegexK = new(@"k");
    private static readonly Regex RegexL = new(@"l");
    private static readonly Regex RegexN = new(@"n");
    private static readonly Regex RegexP = new(@"p");
    private static readonly Regex RegexQ = new(@"q");
    private static readonly Regex RegexR = new(@"r");
    private static readonly Regex RegexS = new(@"s");
    private static readonly Regex RegexT = new(@"t");
    private static readonly Regex RegexV = new(@"v");
    private static readonly Regex RegexX = new(@"x");
    private static readonly Regex RegexZ = new(@"z");
    private static readonly Regex RegexChCap = new(@"Ch");
    private static readonly Regex RegexCkCap = new(@"Ck");
    private static readonly Regex RegexDgCap = new(@"Dg");
    private static readonly Regex RegexPhCap = new(@"Ph");
    private static readonly Regex RegexShCap = new(@"Sh");
    private static readonly Regex RegexThCap = new(@"Th");
    private static readonly Regex RegexZhCap = new(@"Zh");
    private static readonly Regex RegexCCap = new(@"C");
    private static readonly Regex RegexDCap = new(@"D");
    private static readonly Regex RegexJCap = new(@"J");
    private static readonly Regex RegexKCap = new(@"K");
    private static readonly Regex RegexLCap = new(@"L");
    private static readonly Regex RegexNCap = new(@"N");
    private static readonly Regex RegexPCap = new(@"P");
    private static readonly Regex RegexQCap = new(@"Q");
    private static readonly Regex RegexRCap = new(@"R");
    private static readonly Regex RegexSCap = new(@"S");
    private static readonly Regex RegexTCap = new(@"T");
    private static readonly Regex RegexVCap = new(@"V");
    private static readonly Regex RegexXCap = new(@"X");
    private static readonly Regex RegexZCap = new(@"Z");

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<GaggedAccentComponent, AccentGetEvent>(OnAccentGet);
    }

    public string Accentuate(string message, GaggedAccentComponent component)
    {
        var msg = message;

        // I can't be bothered to write an iterator for some silly kink code.
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
        msg = RegexChCap.Replace(msg, "H");
        msg = RegexCkCap.Replace(msg, "Gh");
        msg = RegexDgCap.Replace(msg, "Gh");
        msg = RegexPhCap.Replace(msg, "F");
        msg = RegexShCap.Replace(msg, "Fh");
        msg = RegexThCap.Replace(msg, "F");
        msg = RegexZhCap.Replace(msg, "Fh");
        msg = RegexCCap.Replace(msg, "Yh");
        msg = RegexDCap.Replace(msg, "Gh");
        msg = RegexJCap.Replace(msg, "Gh");
        msg = RegexKCap.Replace(msg, "Gh");
        msg = RegexLCap.Replace(msg, "W");
        msg = RegexNCap.Replace(msg, "M");
        msg = RegexPCap.Replace(msg, "Bh");
        msg = RegexQCap.Replace(msg, "Gh");
        msg = RegexRCap.Replace(msg, "Wh");
        msg = RegexSCap.Replace(msg, "F");
        msg = RegexTCap.Replace(msg, "G");
        msg = RegexVCap.Replace(msg, "F");
        msg = RegexXCap.Replace(msg, "Gh");
        msg = RegexZCap.Replace(msg, "F");

        return msg;
    }

    private void OnAccentGet(EntityUid uid, GaggedAccentComponent component, AccentGetEvent args)
    {
        args.Message = Accentuate(args.Message, component);
    }
}
