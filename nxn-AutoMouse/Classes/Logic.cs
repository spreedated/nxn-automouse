using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nxn_AutoMouse.Windows;
using Gma.System.MouseKeyHook;
using System.Windows.Forms;
using System.Diagnostics;

namespace nxn_AutoMouse
{
    public class Logic : IDisposable
    {
        private readonly IKeyboardMouseEvents m_GlobalHook;
        private bool keepPressing = false;
        private Active ActiveWindow = null;
        public Logic()
        {
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyDown += GlobalHookKeyDown;
            m_GlobalHook.MouseUp += GlobalHookMouseUp;
        }
        private void GlobalHookKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.D) //CTRL+SHIFT+D
            {
                if (keepPressing)
                {
                    Stop();
                }
                else
                {
                    Run();
                }
            }
        }
        private void GlobalHookMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (keepPressing)
            {
                Stop(false);
            }
        }

        private void Stop(bool doClick = true)
        {
            if (doClick)
            {
                AutoIt.AutoItX.MouseClick("LEFT");
            }
            keepPressing = false;
            if (ActiveWindow != null)
            {
                ActiveWindow.Close();
            }
        }
        private void Run()
        {
            ActiveWindow = new Active();
            ActiveWindow.Show();
            keepPressing = true;
            AutoIt.AutoItX.MouseDown("LEFT");
        }

        public void Dispose()
        {
            try
            {
                m_GlobalHook.Dispose();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }
    }
}
