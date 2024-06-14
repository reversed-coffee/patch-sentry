namespace PatchSentry.Secpol.Policies;

/// <summary>
/// Base class that lays out the basic architecture of a security policy.
/// This will be inherited by specific policy types.
/// </summary>
public class SecpolBase {
    /// <summary>
    /// Reference to the section that this policy belongs to.
    /// </summary>
    public SecpolSection? Section { get; protected set; } = null;

    /// <summary>
    /// The name of the policy under the section.
    /// </summary>
    /// <remarks>This refers to the policy key, not the name of the section.</remarks>
    public string Name { get; protected set; }

    /// <summary>
    /// This is the <i>raw value</i> of the policy.
    /// </summary>
    /// <remarks>The value presented here is verbatim to the value in the security database.</remarks>
    public string RawValue { get; protected set; }

    /// <summary>
    /// Instantiate with an empty name and value.
    /// </summary>
    /// <remarks>This is exposed for lazy construction and is not intended to be used directly.</remarks>
    internal SecpolBase() {
        Name = string.Empty;
        RawValue = string.Empty;
    }

    /// <summary>
    /// Instantiate with the specified name and value.
    /// </summary>
    public SecpolBase(string name, string rawValue) {
        Name = name;
        RawValue = rawValue;
    }

    /// <summary>
    /// Transform this class into another class inhereting from <see cref="SecpolBase"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException"> </exception>
    public T? Transform<T>() where T : SecpolBase =>
        Activator.CreateInstance(typeof(T), this) as T;

    /// <summary>
    /// Get the value of this policy as the specified type.
    /// </summary>
    /// <exception cref="InvalidCastException"></exception>
    public virtual T Get<T>() where T : class =>
        RawValue as T ?? throw new InvalidCastException();
    
    public override string ToString() => RawValue;
}