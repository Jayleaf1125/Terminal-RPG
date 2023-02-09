using Terminal.Gui;

namespace App
{
    static class AppTerminalTest
    {
        public static void Test()
        {
            Application.Init();
            var top = Application.Top;

            var win = new Window("Retro Chat")
            {
                X = 0,
                Y = 1, // Leave one row for the toplevel menu

                // By using Dim.Fill(), it will automatically resize without manual intervention
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

        Console.WriteLine("Hello");

            var usernameLabel = new Label() {
                Text = "Username:"
            };

            Application.Shutdown();

        }
    }
}