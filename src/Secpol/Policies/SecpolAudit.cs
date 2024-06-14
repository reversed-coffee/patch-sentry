using PatchSentry.Utilities;

namespace PatchSentry.Secpol.Policies;

[Flags]
public enum SecpolAuditFlags {
    None     = 0,
    Success  = 1,
    Failure  = 2
}

public class SecpolAudit : SecpolBase {
    public readonly SecpolAuditFlags ValueFlags;

    public SecpolAudit(SecpolBase baseClass) {
        var failFactory = () =>
            new InvalidOperationException($"Invalid type conversion to {nameof(SecpolAudit)}");

        // Initial fields
        Name = Except.Assert(baseClass.Name, failFactory);
        RawValue = baseClass.RawValue;

        // Convert value to flags
        Except.Assert(int.TryParse(RawValue, out var valueInt), failFactory);
        Except.Assert(Enum.TryParse(valueInt.ToString(), out ValueFlags), failFactory);
    }

    public override T Get<T>() {
        Except.Assert(typeof(T) == typeof(SecpolAuditFlags), () =>
            new InvalidOperationException($"Invalid cast to {nameof(T)}"));
        return (T)(object)ValueFlags;
    }

    public override string ToString() {
        return ValueFlags.ToString();
    }
}