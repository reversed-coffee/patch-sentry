using System.DirectoryServices.AccountManagement;
using System.Security.Principal;

namespace PatchSentry.Accounts;

public static partial class LocalEntities {
    /// <summary>
    /// Retrieve a <see cref="GroupPrincipal"/> from an SID.
    /// </summary>
    /// <remarks>
    /// Again, thank Microsoft for making my life hard.<br/>
    /// Check out <see cref="UserFromSid(SecurityIdentifier)"/>
    /// </remarks>
    public static GroupPrincipal? GroupFromSid(SecurityIdentifier sid) {
        using var searcher = new PrincipalSearcher(new GroupPrincipal(Context.Value));

        foreach (var result in searcher.FindAll()) {
            if (result is not GroupPrincipal principal)
                continue;

            if (principal.Sid == sid)
                return principal;
        }

        return null;
    }

    /// <summary>
    /// Retrieve a <see cref="GroupPrincipal"/> from an SID string.<br/>
    /// See <see cref="GroupFromSid(SecurityIdentifier)"/> for more information.
    /// </summary>
    public static GroupPrincipal? GroupFromSid(string sid) =>
        GroupFromSid(new SecurityIdentifier(sid));

    /// <summary>
    /// Retrieve a <see cref="GroupPrincipal"/> from a group name.
    /// </summary>
    public static GroupPrincipal? GroupFromName(string name) {
        using var context = new PrincipalContext(ContextType.Machine);
        using var principal = new GroupPrincipal(context);
        principal.SamAccountName = name;

        return principal.QueryFull();
    }
}