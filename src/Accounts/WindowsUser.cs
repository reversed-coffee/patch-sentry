using System.DirectoryServices.AccountManagement;
using System.Security.Principal;

namespace PatchSentry.Accounts;

public static partial class LocalEntities {
    /// <summary>
    /// Retrieve a <see cref="UserPrincipal"/> from an SID.
    /// </summary>
    /// <remarks>
    /// Thank Microsoft for making GroupPrincipal.Sid readonly so I can't query based on it.<br/>
    /// Instead, I have to go through it manually. Don't blame me.<br/>
    /// And no, I am not going to do AD requests. That's ancient and I shouldn't have to.
    /// </remarks>
    public static UserPrincipal? UserFromSid(SecurityIdentifier sid) {
        using var searcher = new PrincipalSearcher(new UserPrincipal(Context.Value));

        foreach (var result in searcher.FindAll()) {
            if (result is not UserPrincipal user)
                continue;
            
            if (user.Sid == sid)
                return user;
        }

        return null;
    }

    /// <summary>
    /// Retrieve a <see cref="UserPrincipal"/> from an SID string.<br/>
    /// See <see cref="UserFromSid(SecurityIdentifier)"/> for more information.
    /// </summary>
    public static UserPrincipal? UserFromSid(string sid) =>
        UserFromSid(new SecurityIdentifier(sid));

    /// <summary>
    /// Retrieve a <see cref="UserPrincipal"/> from a username.
    /// </summary>
    public static UserPrincipal? UserFromName(string username) {
        using var context = new PrincipalContext(ContextType.Machine);
        using var principal = new UserPrincipal(context);
        principal.SamAccountName = username;

        return principal.QueryFull();
    }
}