using System.Windows.Forms;
using System;

namespace SteamFakePlayer.Manager
{
    public class DialogModel
    {
        public bool Success;
    }
    public class DialogModel<TModel, TForm> : DialogModel
        where TModel : DialogModel, new()
        where TForm : Form
    {
        public static bool TryGetModel(out TModel obj)
        {
            return TryGetModel(obj = new TModel());
        }

        public static bool TryGetModel(TModel model)
        {
            using (var form = (TForm)Activator.CreateInstance(typeof(TForm), new object[] { model }))
            {
                form.ShowDialog();
            }
            if (model.Success)
            {
                return true;
            }

            return false;
        }
    }
}
