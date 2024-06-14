using System.DirectoryServices.AccountManagement;
using System.Globalization;
using System.Security.Principal;
using System.Text.RegularExpressions;

using PatchSentry.Accounts;
using PatchSentry.Utilities;

namespace PatchSentry.Secpol.Policies;

public class SecpolPrivilege : SecpolBase {
    public readonly List<Principal> Principals;

    public SecpolPrivilege(SecpolBase baseClass) {
        // Initial fields
        Name = Except.Assert(baseClass.Name, () => new InvalidOperationException());
        RawValue = baseClass.RawValue;

        // Parse principals
        Principals = new();

        foreach (var principal in RawValue.Split(',')) {
            var trimmed = principal.Trim();

            if (string.IsNullOrEmpty(trimmed))
                continue;

            if (trimmed.StartsWith('*')) {
                // If it starts with a *, it is an SID
                try {
                    LocalEntities.DecodeSid(trimmed);
                }
                catch (Exception ex) {
                    throw new InvalidOperationException($"Invalid principal: {trimmed}", ex);
                }
            }
            else {
                // Otherwise, it is a name
            }


        }
    }
}