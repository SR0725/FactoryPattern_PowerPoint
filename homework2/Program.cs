using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework2
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PowerPointModal powerPointModal = new PowerPointModal();
            PresentationModel presentationModel = new PresentationModel(powerPointModal);
            Form1 view = new Form1(powerPointModal, presentationModel);
            Application.Run(view);
        }
    }
}
