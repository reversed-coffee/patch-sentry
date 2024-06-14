namespace PatchSentry.Utilities;

internal static class FormExtensions {
    static readonly Lazy<Dictionary<string, Form>> FormCache = new(() => new());

    static string GetDiscriminator(Type @class) => @class.GetHashCode() + @class.FullName;

    static string GetDiscriminator<T>() => GetDiscriminator(typeof(T));

    public static T Display<T>() where T : Form {
        var formClass = typeof(T);
        var disc = GetDiscriminator<T>();

        T form;
        var success = FormCache.Value.TryGetValue(disc, out var entryValue);

        if (!success || entryValue is null || entryValue.IsDisposed) {
            // Reflective construction of form
            entryValue = formClass.GetConstructor(Type.EmptyTypes)?.Invoke(null) as Form
                         ?? throw new("Failed to invoke form constructor");

            // Set entry and assign form var
            FormCache.Value[disc] = entryValue;
            form = (T)entryValue;

            // Cache cleanup; prevents memory leaks
            form.FormClosed += (_, _) => FormCache.Value.Remove(disc);
        }
        else {
            // Direct cast because it already exists and is valid
            form = (T)entryValue;
        }

        // Show the form if it isn't visible, then also unmimimize it and focus
        if (!form.Visible)
            form.Show();

        if (form.WindowState == FormWindowState.Minimized)
            form.WindowState = FormWindowState.Normal;

        form.Focus();

        return form;
    }

    public static T Display<T>(this T _) where T : Form => Display<T>();
}