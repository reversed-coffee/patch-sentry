using System.ComponentModel;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Management;

using PatchSentry.Utilities;

namespace PatchSentry.Forms;

public partial class AccountsForm : ToolFormBase {
    public AccountsForm() {
        InitializeComponent();
    }

    void LoadQuickManager(object? sender, DoWorkEventArgs e) {
        // Get all windows accounts
        using var userSearch = new ManagementObjectSearcher(new SelectQuery("Win32_UserAccount"));
        foreach (var entry in userSearch.Get()) {
            var username = entry["Name"].ToString()!;
            //var sid = entry["SID"].ToString()!;
            var groups = new List<string>();

            if (username is "DefaultAccount" or "WDAGUtilityAccount") {
                // builtin so just skip
                continue;
            }

            Program.State.Logger.Send($"Found {username}");

            // For all the users, get their groups and assign them
            var groupQuery = new SelectQuery("Win32_GroupUser",
                $"PartComponent=\"Win32_Group.Domain='{Environment.UserDomainName}',Name='{username}'\"");
            using var groupSearch = new ManagementObjectSearcher(groupQuery);

            // I literally have no clue how else to get around this without parsing, so I'm just gonna parse it
            // It's a cyberaptriot program who gives a crap lol
            foreach (var unkGroup in groupSearch.Get()) {
                var group = (ManagementObject)unkGroup;
                var groupName = group["GroupComponent"].ToString()!.Split("Name=\"")[1].Split("\"")[0];
                Program.State.Logger.Send($"{username} -> {groupName}");
                groups.Add(groupName);
            }

            // And now we push it to the tree
            var node = new TreeNode(username) {
                Name = username, // We set name so we can search for it later
                ForeColor = Color.Red// red = unknwon
            };

            var groupsNode = new TreeNode("Groups") { Name = "GroupList" };
            foreach (var groupName in groups)
                groupsNode.Nodes.Add(new TreeNode(groupName) { Name = groupName });

            node.Nodes.Add(groupsNode);
            ListQuickManager.Invoke(() => ListQuickManager.Nodes.Add(node));
        }
    }

    void LoadQuickManagerAsync() {
        // Clear nodes
        ListQuickManager.Nodes.Clear();

        // Start worker
        var worker = new BackgroundWorker();
        worker.DoWork += LoadQuickManager;
        worker.RunWorkerAsync();
    }

    private void BtnSetUsers_Click(object sender, EventArgs e) {
        // Ok we're gonna go every line to get users
        var lines = BoxSetUsers.Text.Trim().Split('\n').ToList();
        lines.Add("Guest"); // Add guest to the list because it's built in

        foreach (var line in lines) {
            // Alright basically we're gonna use the node list as a guide for everything
            foreach (var node in ListQuickManager.Nodes.Find(line, false)) {
                if (node.Name == "Guest") {
                    // Builtin so we do different color for disabling
                    node.ForeColor = Color.DarkOrange;
                    continue;
                }
                node.ForeColor = Color.Blue;
                node.Remove();

                // check in users group
                var groupsNode = node.Nodes.Find("GroupList", false).FirstOrDefault();
                var usersNode = groupsNode?.Nodes.Find("Users", false).FirstOrDefault();

                if (usersNode == null) {
                    groupsNode?.Nodes.Add(new TreeNode("Users") { Name = "Users", ForeColor = Color.Green });
                }

                ListQuickManager.Nodes.Add(node); // Add it to the bottom since its less important
                Program.State.Logger.Send($"Authorized user '{line}' found");
            }
        }

        SetAdmins(); // im going insane and im very lazy rn
    }

    private void SetAdmins() {
        List<string> admins = new();
        var lines = BoxSetAdmins.Text.Trim().Split('\n').ToList();
        lines.Add("!@#@#@!$@$__LITERALLY_DUMMY__"); // great coding here but its 2am so i dont care

        foreach (var line in lines) {
            // Alright basically we're gonna use the node list as a guide for everything
            foreach (var node in ListQuickManager.Nodes.Find(line, false)) {
                node.ForeColor = Color.Blue;
                node.Remove();
                ListQuickManager.Nodes.Add(node); // Add it to the bottom since its less important
                Program.State.Logger.Send($"Authorized admin '{line}' found");
                admins.Add(line);
            }
        }

        foreach (TreeNode userNode in ListQuickManager.Nodes) {
            var groupsNode = userNode.Nodes.Find("GroupList", false).FirstOrDefault();
            var adminNode = groupsNode?.Nodes.Find("Administrators", false).FirstOrDefault();

            if (adminNode == null) {
                if (admins.Contains(userNode.Text)) {
                    // should be admin so add
                    groupsNode?.Nodes.Add(new TreeNode("Administrators") { Name = "Administrators", ForeColor = Color.Green });
                }
                continue;
            }

            // If they have this node, check if they're admin on the list
            if (admins.Contains(userNode.Text)) {
                // They're admin and its ok
                adminNode.ForeColor = Color.Blue;
            }
            else {
                if (userNode.Name == "Administrator") {
                    // Builtin so we do different color for disabling
                    userNode.ForeColor = Color.DarkOrange;
                    continue;
                }

                // They should not be admin
                if (userNode.ForeColor != Color.Red) // red = unknwon so just disable it
                    userNode.ForeColor = Color.BlueViolet; // violet = look closer or subchange made
                adminNode.ForeColor = Color.Red;
            }
        }
    }

    private void BtnDeleteQuick_Click(object sender, EventArgs e) {
        var node = ListQuickManager.SelectedNode;
        var name = node.Text;

        if (node.Parent == null) {
            // Delete user
            try {
                var localMachine = new DirectoryEntry($"WinNT://{Environment.MachineName},computer");
                var user = localMachine.Children.Find(name, "user");

                localMachine.Children.Remove(user);

                try {
                    // If we're connected to a domain, commit changes
                    localMachine.CommitChanges();
                }
                catch (NotImplementedException) { /* This is OK in many scenarios */ }

                Program.State.Logger.Send($"User '{name}' has been deleted");

                // sahfosfhsoifh
                ListQuickManager.Nodes.Find(name, false).FirstOrDefault()?.Remove();
            }
            catch (UnauthorizedAccessException) {
                Program.State.Logger.Send($"Access denied while deleting user '{name}'");
            }
        }
        else if (node.Parent.Name == "GroupList") {
            // Delete group
            try {
                var localMachine = new DirectoryEntry($"WinNT://{Environment.MachineName},computer");
                var group = localMachine.Children.Find(name, "group");

                localMachine.Children.Remove(group);

                try {
                    // If we're connected to a domain, commit changes
                    localMachine.CommitChanges();
                }
                catch (NotImplementedException) { /* This is OK in many scenarios */ }

                Program.State.Logger.Send($"Group '{name}' has been deleted");

                // Go through list and find all users with this group
                foreach (TreeNode userNode in ListQuickManager.Nodes) {
                    var groupListNode = userNode.Nodes.Find("GroupList", false).FirstOrDefault();
                    if (groupListNode == null) continue;

                    foreach (var groupNode in groupListNode.Nodes.Find(name, false))
                        groupNode.Remove();
                }
            }
            catch (UnauthorizedAccessException) {
                Program.State.Logger.Send($"Access denied while deleting group '{name}'");
            }
        }
        else {
            MessageBox.Show(@"Can only delete users or groups.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void AccountManagement_Load(object sender, EventArgs e) {
        LoadQuickManagerAsync();
    }

    private void BtnRefreshQuickList_Click(object sender, EventArgs e) {
        LoadQuickManagerAsync();
    }

    private void BtnDisableQuick_Click(object sender, EventArgs e) {
        var node = ListQuickManager.SelectedNode;
        var name = node.Text;

        if (node.Parent == null) {
            // Disable user
            try {
                using var principalContext = new PrincipalContext(ContextType.Machine);

                var userPrincipal = new UserPrincipal(principalContext) {
                    SamAccountName = name
                };

                using var searcher = new PrincipalSearcher(userPrincipal);
                userPrincipal = searcher.FindOne() as UserPrincipal;

                if (userPrincipal == null) {
                    MessageBox.Show(@"User not found.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (userPrincipal.Enabled == true) {
                    userPrincipal.Enabled = false;
                    userPrincipal.Save();
                }
                userPrincipal.Dispose();

                // sahfosfhsoifh
                ListQuickManager.Nodes.Find(name, false).FirstOrDefault()?.Remove();

                Program.State.Logger.Send($"User '{name}' has been disabled");
            }
            catch (UnauthorizedAccessException) {
                Program.State.Logger.Send($"Access denied while disabling user '{name}'");
            }
        }
        else {
            MessageBox.Show(@"Can only disable users.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnPatchQuick_Click(object sender, EventArgs e) {
        var node = ListQuickManager.SelectedNode;

        if (node.Parent == null) {
            // check name against cur user
            if (node.Text == Environment.UserName) {
                // del user from list
                ListQuickManager.Nodes.Find(node.Name, false).FirstOrDefault()?.Remove();

                MessageBox.Show(@"Modifying the currently logged in account is not advised.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Patch user
            if (node.ForeColor == Color.DarkOrange) {
                // del user from list
                ListQuickManager.Nodes.Find(node.Name, false).FirstOrDefault()?.Remove();

                MessageBox.Show(@"Cannot patch builtin users.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // may scrounge some other points here in case the scoring engine is tricky like it has been
            // for the past few rounds...
            var dontTouchUserAfterChangeGroup = false;
            if (node.ForeColor == Color.Red) {
                // Disable user and dont touch it anymore
                BtnDisableQuick_Click(sender, e);
                dontTouchUserAfterChangeGroup = true;
            }

            // ok go for groups in there now
            var groupsNode = node.Nodes.Find("GroupList", false).FirstOrDefault();
            if (groupsNode == null) return;

            foreach (TreeNode groupNode in groupsNode.Nodes) {
                if (groupNode.ForeColor == Color.Blue) continue; // compliant

                if (groupNode.ForeColor == Color.Red) {
                    using var principalContext = new PrincipalContext(ContextType.Machine);

                    var userPrincipal = new UserPrincipal(principalContext) {
                        SamAccountName = node.Name
                    };

                    using var searcher = new PrincipalSearcher(userPrincipal);
                    userPrincipal = searcher.FindOne() as UserPrincipal;

                    if (userPrincipal == null) {
                        MessageBox.Show(@"User not found.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var groupPrincipal = new GroupPrincipal(principalContext) {
                        Name = groupNode.Name
                    };

                    using var groupSearcher = new PrincipalSearcher(groupPrincipal);
                    groupPrincipal = groupSearcher.FindOne() as GroupPrincipal;

                    if (groupPrincipal == null) {
                        MessageBox.Show(@"Group not found.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    groupPrincipal.Members.Remove(userPrincipal);
                    groupPrincipal.Save();

                    // Go through list and find all users with this group
                    foreach (TreeNode userNode in ListQuickManager.Nodes) {
                        var groupListNode = userNode.Nodes.Find("GroupList", false).FirstOrDefault();
                        if (groupListNode == null) continue;

                        foreach (var groupNode2 in groupListNode.Nodes.Find(node.Name, false))
                            groupNode.Remove();
                    }

                    Program.State.Logger.Send($"User '{node.Name}' removed from '{groupNode.Name}'");

                    userPrincipal.Dispose();
                    groupPrincipal.Dispose();
                }
            }

            if (dontTouchUserAfterChangeGroup) {
                // del user from list
                ListQuickManager.Nodes.Find(node.Name, false).FirstOrDefault()?.Remove();

                MessageBox.Show("User has been patched.\nActions: User disabled, groups audited)", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Set password to a random string
            // This is a temporary password that will be changed on next login
            var newPassword = Security.Generate();

            using var principalContext2 = new PrincipalContext(ContextType.Machine);

            var userPrincipal2 = new UserPrincipal(principalContext2) {
                SamAccountName = node.Name
            };

            using var searcher2 = new PrincipalSearcher(userPrincipal2);
            userPrincipal2 = searcher2.FindOne() as UserPrincipal;

            if (userPrincipal2 == null) {
                MessageBox.Show(@"User not found.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            userPrincipal2.SetPassword(newPassword); // Set the temporary password. It's like a "reset password" thing
            Program.State.Logger.Send($"User '{node.Name}' password changed");

            if (!userPrincipal2.UserCannotChangePassword) {
                userPrincipal2.UserCannotChangePassword = false; // Allow the user to change their own password
                Program.State.Logger.Send($"Fixed user '{node.Name}' can't change password");
            }

            if (userPrincipal2.PasswordNeverExpires) {
                userPrincipal2.PasswordNeverExpires = false; // Ensure the password will expire, this should be for all users anyways
                Program.State.Logger.Send($"Re-enabled password expiry for '{node.Name}'");
            }
            userPrincipal2.ExpirePasswordNow(); // User must change password on next login
            Program.State.Logger.Send($"Set password expired for '{node.Name}', must change on login");

            userPrincipal2.Save();
            Program.State.Logger.Send($"Committed user security changes for '{node.Name}'");

            // Save password to file
            var filePath = System.IO.Path.Combine(Program.State.LocalFiles, "temp-pass", $"{node.Name}.dat");

            // phew this is messy but im lazy rn
            if (!System.IO.Directory.Exists(Path.Join(Program.State.LocalFiles, "temp-pass")))
                System.IO.Directory.CreateDirectory(Path.Join(Program.State.LocalFiles, "temp-pass"));

            File.WriteAllText(filePath, newPassword); // security? what's that? LOL
            // alright alright some day ill use a credential manager
            // right now, this is literally for a high school competition
            // i just dont feel like dumping 1000 lines of code into a feature that
            // has no real use in the competition
            // if i ever open source this for professional security audits ill make it secure

            // del user from list
            ListQuickManager.Nodes.Find(node.Name, false).FirstOrDefault()?.Remove();

            MessageBox.Show($"User has been patched.\nTemporary password can be found in '{filePath}'\nActions: Groups audited, password reset, password options reset", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else {
            MessageBox.Show(@"Can only patch users.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void label2_Click(object sender, EventArgs e) {

    }

    private void BoxQuickLog_TextChanged(object sender, EventArgs e) {

    }

    private void groupBox1_Enter(object sender, EventArgs e) {

    }
}