Guideline:
    + Use PatchSentry to do this
    ! Do this manually
    ? Use PatchSentry, but review the results manually if you have time

ALWAYS. DO. FORENSICS. QUESTIONS. FIRST.
    - Set a 10 minute timer for each question
    - If you can't figure it out, move on
    - If you have time, come back to it.
        - COME BACK TO THESE FIRST AS THEY ARE WORTH THE MOST POINTS

Cool things you can do that speeds up time:
    - Install something like uBlock origin on the browser if you need to
      look up stuff
    - Remember chatgpt is allowed in the competition since it is an online
	  resource per. rule 3012 SO USE IT IF YOU'RE CONFUSED
    - i am a cool guy you can also ask me questions
         - PLEASE DO IDC IF YOU THINK ITS A DUMB QUESTION
         - DONT DO SOMETHING RETARDED
    - Win+X and Win+R is your friend

+ Account and Group Management
    - Remove unauthorized administrators
    - Disable unauthorized users
    - Change insecure passwords
        - Avoid changing current user password; can interfere with auto-login
        - Force users to change password on next login
        - Always make passwords expire for all accounts
    - Disable built-in Guest and Administrator accounts  
    ! Check builtin groups like Event Log Readers and make sure no one has permissions like these    
    ! Rename builtin accounts like Guest and Administrator

+ Service auditing
    - i aint writing all this down just use this tool i baked the CIS benchmarks recommendations into this tool for you
    - Disable bluetooth/wireless services in server images
    - PatchSentry does this for you in the services toolbox

! In group policy editor set a filter to look for changed policies
    - Click filter icon
    - Computer Configuration -> Administrative Templates -> All Settings
    - Top bar "Action" -> "Filter Options
    - Review these
        - Managed: Any
        - Configured: Yes
        - Commented: Any
        - Disable keyword filter
        - Uncheck "Enable requirements filters"
    - Click "OK"
    - Click "All Settings" again
    - Review all settings that have been changed
    - When you're done, click the filter icon to turn it off

? Audit policy
    - Enable login/logout auditing
    - Enable auditing of failed login/logout attempts
    ! Local security policy -> Advanced Audit Policy Configuration
        - if you got time, go mess around in there

? Password policy
    ? Enforce password history
    ? Remember 24 passwords
    ? Set max password age to 60
    ? Minimum password age 30
    ? Minimum password length 14
    ? Enable password must meet complexity requirements
    ? Never store passwords using reversible encryption

? User Rights Assignment
    ? Enable "UAC Built-in Admin Approval Mode"
    ? Enable "Run all admins in Admin Approval Mode"
    ? Remove all users under "Enable computer and user accounts to be trusted for delegation"
    ? Disable "Manage auditing and security log" for non-admins 
    ? Disable "Enumerate admin accounts on elevation"
        - Not in secpol, use "Group Policy -> Windows Components -> Credential User Interface"

! Misc
    - Clear Virtual Memory on shutdown
    - Reverse shells check (see networking)


! Review user files
    - Media and "hacking" tools not allowed
    - Look especially for *.exe, *.rar, *.zip, *.7z, *.mp3, *.mp4, *.avi, *.mov
        - For automation you can use CCleaner
    - Delete files that are not authorized
        - Use CCleaner with this as well
    ! Scan for files in working dir with `dir /s /b *.EXTENSION`
    - DO NOT OVERLOOK HIDDEN FILES
        - ONE TIME THERE WAS A HIDDEN "SYSTEM" FILE BUT IT HAD THE USER PASSWORDS IN IT

! Update and secure your software
    - Come on, is it that hard?
    - UPDATE. WINDOWS. UPDATE. WINDOWS. UPDATE. WINDOWS.
        - AND PLEASE CHECK FOR GROUP POLICY OVERRIDES
        - OH DOESNT WORK AFTER THAT? ENABLE THE SERVICE...
    - Just make sure you check the build architecture
		- 32 bit vs 64 bit - They WILL try to trick you. Install the correct version
    - Review features appwiz.cpl ya know the drill
    - I have a great thing for browser security
        - Enable OSCP validation and HTTPS-only if possible
        - Use a secure DNS server
        - Enable "Do Not Track"
        - Enable "Block third-party cookies and site data"
        - Block pop-ups and malicious content
        - Also disable autoplay that can be annoying and also malicious
        - Clear cookies and site data when you close the browser
        - Disable autofill
        - Do not save passwords
        - Limit location sharing
        - Use something like duckduckgo
        - Also: https://raw.githubusercontent.com/reversed-coffee/system-hardening/master/universal/Browser-Security.md
    - WINDOWS POWERSHELL EXECUTION POLICY...
		- Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope LocalMachine
		- Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser

! Review file permissions
    - Ensure users only have access to folders they should have access to

! UAC prompts
    - Max out UAC prompt level
    - "Change User Account Control Settings"

! Drive sharing
    - Turn off drive sharing if not critical (Explorer -> Right click drive -> Properties -> Sharing)
    - Securing
        - Ensure that only certain users have access to the shared drive
    - ESPECIALLY CHECK PERMISSIONS IN SHARES SHOWN IN COMPUTER MANAGEMENT UTILITY AND THE ROOT OF DRIVES
        - THESE ARE COMMONLY OVERLOOKED
    - LOOK AT SHARED IN COMPUTER MANAGEMENT I CANNOT EXPRESS THAT ENOUGH

! Network analysis
    - Resource monitor has great stuff for this
        - It also can help you find sketchy processes or processes with handles to weird files
        - Check for sketchy connections
        - Can also use netstat -pant but resource monitor is easier to use

! Task scheduler
    - Look for weird entries
    - Disable sketchy tasks
    - Done and done...

! Developer mode
    - TURN THAT CRAP OFF
    - IT TRUSTS UNSAFE UWP APPS
    - System settings -> Developer settings -> 

! Windows Firewall
    - Ensure that Windows Firewall is enabled
    - Quickly review and update firewall entries
    - Enable firewall in ALL scenarios, private and public

! Remote Desktop Protocol (RDP) and Remote Assistance
    - Win+R type "sysdm.cpl" -> Remote Tab
    - Disable Remote Assistance unless critical
    - Disable RDP unless critical
    - If remote assistance is not allowed by company policy, disable it
    - Group policies (!!!!)
        - Windows Compontents -> Remote Desktop Services -> Session Host -> Security
        - Set client connection encryption level - High level, enabled
        - Require use of specific security layer - SSL, enabled

! Review certificates on system
    - Certificate Manager: certmgr.msc
    - Remove sketchy certificates
        - Untrusted, expired, or untrusted certificates
    - Remove untrusted root CAs
        - Company root CA is generally allowed
    - This is done because rouge certificates can pose MITM risks

! Secure Shell (SSH)
    - Disable if not required
        - Generally OpenSSH service
    - Use private key authentication instead of passwords
    - Firewall rules
        - Only allow certain computers to connect
    - Limit who you can log in as
    - Avoid default ports

! IIS
    - Server manager -> Tools -> Internet Information Services (IIS) Manager
    - Disable IIS if not required
    - Server -> Website -> Edit feature setting
    - we're looking for stuff like SSL/TLS disabled
         - or like directory browsing enabled
         - make sure error pages are not detailed

! File sharing services
    - Review content that is shared remotely
        - Server manager
    - Manage access control accordingly
        - Restrict who can connect to the file sharing server
    - Server Manager -> Storage Services -> Shares
        - Modify permissions
    - Server Manager -> Local Server -> IE Enhanced Security - Enable
    - Disable SMB
   
! Windows Defender
    - Ensure that Windows Defender is enabled
    - If not installed its in the appwiz.cpl
    - Stuff that may disable it
        - Group policy (gpedit.msc)
        - Registry (regedit.exe): HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows Defender -> DisableAntiSpyware
    - Enable basic malware protection
    - Remove exclusions
        - Whitelist only cyberpatriot scoring engine
    - Enable real-time protection
    - Enable tamper protection
    - Enable basically anything that looks important

- Exploit prevention
    - in windows defender enable exploit protection
    - make sure DEP and ASLR exploit prevention is enabled (GOOGLE IT IF YOU DONT KNOW WHAT IT IS)
    + turn off port sharing and upnp (service manager)

Still have points left?
    - Review your applications and services
        - What may be vulnerable?
            - IIS, MailEnable, SMB, RDP, SSH, WHAT ARE SOME NETWORK SERVICES THAT ARE VULNERABLE?
        - What can be disabled?
        - What can be updated?
        - What can be configured?
        - Look for common vulnerabilities with google
    - https://www.stigviewer.com/stigs
    - https://www.cisecurity.org/cis-benchmarks/