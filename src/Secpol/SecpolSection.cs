using PatchSentry.Secpol.Policies;

namespace PatchSentry.Secpol;

public class SecpolSection {
    public required string Name;
    public required List<SecpolBase> Policies;
}