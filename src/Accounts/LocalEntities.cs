using System.DirectoryServices.AccountManagement;

namespace PatchSentry.Accounts;

public static partial class LocalEntities {
    internal static Lazy<PrincipalContext> Context = new(() => new(ContextType.Machine));

    /// <summary>
    /// Returns a <see cref="GroupPrincipal"/> or <see cref="UserPrincipal"/> from an SID.
    /// If the SID does not exist, this method returns null.
    /// </summary>
    /// <remarks>
    /// You can use <see cref="object.GetType"/> to determine the result.
    /// </remarks>
    public static Principal? DecodeSid(string sid) {
        if (string.IsNullOrWhiteSpace(sid))
            return null;

        var group = GroupFromSid(sid);
        if (group is not null)
            return group;

        var user = UserFromSid(sid);
        return user;
    }

    /// <summary>
    /// Helper function to cast the result from <see cref="DecodeSid(string)"/> to
    /// a specific type.
    /// </summary>
    public static T? DecodeSid<T>(string sid) where T : Principal =>
        DecodeSid(sid) as T;

    public static Principal? DecodeName;

    /// <summary>
    /// Returns a <see cref="Principal"/> or inheriting class from a
    /// partially filled out <see cref="Principal"/> (or inheriting) object.
    /// </summary>
    /// <remarks>
    /// Makes a new <see cref="PrincipalSearcher"/> and queries for a full object
    /// using its API.
    /// </remarks>
    public static T? QueryFull<T>(this T principal) where T : Principal {
        using var searcher = new PrincipalSearcher(principal);

        foreach (var result in searcher.FindAll()) {
            if (result is not T full)
                continue;
            return full;
        }

        return null;
    }
}