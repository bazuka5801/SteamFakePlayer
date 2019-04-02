using System;
using System.Windows.Forms;

namespace SteamFakePlayer.Manager
{
    public partial class BotOptionsForm : Form
    {
        private readonly BotOptionsModel _model;

        public BotOptionsForm(BotOptionsModel model)
        {
            _model = model;

            InitializeComponent();

            LoadData(model);
        }

        public void LoadData(BotOptionsModel model)
        {
            tbEnterMin.Text = model.EnterMin.ToString();
            tbEnterMax.Text = model.EnterMax.ToString();
            tbExitMin.Text = model.ExitMin.ToString();
            tbExitMax.Text = model.ExitMax.ToString();
            tbReconnectMin.Text = model.ReconnectMin.ToString();
            tbReconnectMax.Text = model.ReconnectMax.ToString();
        }

        public bool SaveData()
        {
            int enterMin = 0, enterMax = 0, exitMin = 0, exitMax = 0, reconnectMin = 0, reconnectMax = 0;
            var result = ValidateIntField("EnterMin", tbEnterMin, out enterMin)
                         && ValidateIntField("EnterMax", tbEnterMax, out enterMax)
                         && ValidateIntField("ExitMin", tbExitMin, out exitMin)
                         && ValidateIntField("ExitMax", tbExitMax, out exitMax)
                         && ValidateIntField("ReconnectMin", tbReconnectMin, out reconnectMin)
                         && ValidateIntField("ReconnectMax", tbReconnectMax, out reconnectMax);

            if (result)
            {
                _model.EnterMin = enterMin;
                _model.EnterMax = enterMax;
                _model.ExitMin = exitMin;
                _model.ExitMax = exitMax;
                _model.ReconnectMin = reconnectMin;
                _model.ReconnectMax = reconnectMax;
                return true;
            }

            return false;
        }

        private bool ValidateIntField(string name, TextBox tb, out int result)
        {
            if (GetInt(tb, out result) == false)
            {
                MessageUtils.Error($"Поле {name} не является числом!");
                return false;
            }

            return true;
        }

        private bool GetInt(TextBox tb, out int result) => int.TryParse(tb.Text, out result);

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                _model.Success = true;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public class BotOptionsModel : DialogModel<BotOptionsModel, BotOptionsForm>
    {
        public int EnterMin, EnterMax;
        public int ExitMin, ExitMax;
        public int ReconnectMin, ReconnectMax;
    }
}