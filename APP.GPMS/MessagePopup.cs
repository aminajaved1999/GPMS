using APP.GPMS.MUControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP.GPMS
{
    public class MessagePopup
    {
        public System.Windows.Forms.Timer timer;
        public void ShowMessagePopup( Form pForm,MessagePopupType pMsgType, string pMsg)
        {

            MUPanel rsPanel = new MUPanel();
            rsPanel.Visible = true;
            rsPanel.Padding = new Padding(3);
            rsPanel.BorderRadius = 10;
            rsPanel.BorderSize = 1;
            rsPanel.Size = new System.Drawing.Size(400, 50);
            rsPanel.Location = new System.Drawing.Point(403, 126);

            Label msgLabel = new Label();
            msgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            msgLabel.AutoSize = false;
            msgLabel.Font = new System.Drawing.Font("Verdana", 9.00F);
            msgLabel.Dock = DockStyle.Fill;
            rsPanel.Controls.Add(msgLabel);


            Button buttonClose = new Button();
            buttonClose.Click += delegate
            {
                rsPanel.Dispose();
            };
                buttonClose.Cursor = Cursors.Hand;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.Dock = DockStyle.Right;
            buttonClose.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonClose.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonClose.Text = "✖";
            buttonClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            buttonClose.Size = new System.Drawing.Size(20, 20);
            rsPanel.Controls.Add(buttonClose);

            msgLabel.BringToFront();

            if (pMsgType == MessagePopupType.Success)
            {
                rsPanel.BackColor = System.Drawing.Color.FromArgb(100, 223, 240, 216);
                rsPanel.BorderColor = System.Drawing.Color.FromArgb(60, 118, 61);

                msgLabel.ForeColor = System.Drawing.Color.FromArgb(60, 118, 61);
                buttonClose.ForeColor = System.Drawing.Color.FromArgb(60, 118, 61);
                msgLabel.BackColor = System.Drawing.Color.Transparent;
                msgLabel.Text = "𝗦𝗨𝗖𝗖𝗘𝗦𝗦! " + pMsg;
            }
            else if (pMsgType == MessagePopupType.Warning)
            {
                rsPanel.BackColor = System.Drawing.Color.FromArgb(100, 252, 248, 227);
                rsPanel.BorderColor = System.Drawing.Color.FromArgb(138, 109, 59);

                buttonClose.ForeColor = System.Drawing.Color.FromArgb(138, 109, 59);
                msgLabel.ForeColor = System.Drawing.Color.FromArgb(138, 109, 59);
                msgLabel.BackColor = System.Drawing.Color.Transparent;
                msgLabel.Text = "𝗪𝗔𝗥𝗡𝗜𝗡𝗚! " + pMsg;
            }
            else if (pMsgType == MessagePopupType.Info)
            {
                rsPanel.BackColor = System.Drawing.Color.FromArgb(100, 217, 237, 247);
                rsPanel.BorderColor = System.Drawing.Color.FromArgb(49, 112, 143);

                buttonClose.ForeColor = System.Drawing.Color.FromArgb(49, 112, 143);
                msgLabel.ForeColor = System.Drawing.Color.FromArgb(49, 112, 143);
                msgLabel.BackColor = System.Drawing.Color.Transparent;
                msgLabel.Text = "𝗜𝗡𝗙𝗢! " + pMsg;
            }
            else if (pMsgType == MessagePopupType.Error)
            {
                rsPanel.BackColor = System.Drawing.Color.FromArgb(100, 242, 222, 222);
                rsPanel.BorderColor = System.Drawing.Color.FromArgb(169, 68, 66);

                msgLabel.ForeColor = System.Drawing.Color.FromArgb(169, 68, 66);
                buttonClose.ForeColor = System.Drawing.Color.FromArgb(169, 68, 66);                
                msgLabel.BackColor = System.Drawing.Color.Transparent;
                msgLabel.Text = "𝗘𝗥𝗥𝗢𝗥! " + pMsg;
            }



            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 5000;
            timer.Tick += delegate
            {
                rsPanel.Dispose();
                timer.Dispose();
            };
            rsPanel.BringToFront();
            rsPanel.Name = "msgPanel";

            pForm.Controls.OfType<MUPanel>().Where(c => c.Name.Contains(rsPanel.Name)).ToList().ForEach(x=> x.Dispose());
            int count =pForm.Controls.OfType<MUPanel>().Where(c => c.Name.Contains(rsPanel.Name)).Count();
            rsPanel.Location = new Point(pForm.Size.Width - rsPanel.Width - 20 , 50 + (count * 50));
            pForm.Controls.Add(rsPanel);
            rsPanel.BringToFront();
            //return rsPanel;
        }
    }

    public enum MessagePopupType
    {
        Success,
        Warning,
        Info,
        Error
    }
}
