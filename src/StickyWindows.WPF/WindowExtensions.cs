using System.Windows;

namespace StickyWindows.WPF {
    /// <summary>
    /// Extension methods for <see cref="Window"/>.
    /// </summary>
    public static class WindowExtensions {
        /// <summary>
        /// Register a new window as an external reference form.
        /// All Sticky windows will try to stick to the external references
        /// Use this to register your MainFrame so the child windows try to stick to it, when your MainFrame is NOT a sticky window
        /// </summary>
        /// <param name="window">External window that will be used as reference</param>
        public static void RegisterExternalReferenceForm(this Window window) {
            StickyWindow.RegisterExternalReferenceForm(new WpfFormAdapter(window));
        }

        /// <summary>
        /// Creates a <see cref="StickyWindow"/> object for the given <see cref="Window"/>.
        /// </summary>
        /// <param name="window">The window to create a sticky window for.</param>
        /// <returns>A <see cref="StickyWindow"/> object.</returns>
        public static StickyWindow CreateStickyWindow(this Window window) {
            return new StickyWindow(new WpfFormAdapter(window));
        }
    }
}