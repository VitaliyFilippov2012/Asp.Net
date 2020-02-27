using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_1
{
    public partial class _Default : Page
    {
        protected void OnButtonClickRestore(object sender, EventArgs e)
        {
            RestoreAllText(Page.Controls);
        }

        protected void OnButtonClickClear(object sender, EventArgs e)
        {
            ClearAllText(Page.Controls);
        }

        protected void OnButtonClickSave(object sender, EventArgs e)
        {
            Label1.Text = TextBox1.Text;
            SaveAllText(Page.Controls);
        }

        private void SaveAllText(ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                switch (control)
                {
                    case TextBox textBox:
                        ViewState[textBox.ID] = textBox.Text;
                        break;
                    case Label label:
                        ViewState[label.ID] = label.Text;
                        break;
                }
                if (control?.Controls != null)
                {
                    SaveAllText(control.Controls);
                }
            }
        }

        private void RestoreAllText(ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                switch (control)
                {
                    case TextBox textBox:
                        if (ViewState[textBox.ID] != null)
                            textBox.Text = (string)ViewState[textBox.ID];
                        break;
                    case Label label:
                        if (ViewState[label.ID] != null)
                            label.Text = (string)ViewState[label.ID];
                        break;
                }

                if (control?.Controls != null)
                {
                    RestoreAllText(control.Controls);
                }
            }
        }

        private void ClearAllText(ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                switch (control)
                {
                    case TextBox textBox:
                        textBox.Text = "nan";
                        break;
                    case Label label:
                        label.Text = "nan";
                        break;
                    case DropDownList list:
                        list.Items.Clear();
                        break;
                }

                if (control?.Controls != null)
                {
                    ClearAllText(control.Controls);
                }
            }
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            DropDownList1.Items.Add("~CheckBox1Click~");
            Label2.Text += "~CheckBox1Click~";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String s = Request["__VIEWSTATE"];
            this.Label1.Text = "{" + s.Length + "}" + "{" + this.TextBox1.Text.Length + "}";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList1.Items.Add("~Load~");
            Label2.Text += "~Load~";
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            DropDownList1.Items.Add("~Init~");
            Label2.Text += "~Init~";
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Label2.Text += "~PreRender~";
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            // Этот текст никогда не отображается, поскольку к этому 
            // моменту весь HTML-код для страницы уже сгенерирован.
            Label2.Text += "~Unload~";
        }
        protected void Page_Disposed(object sender, EventArgs e)
        {
            // Этот текст никогда не отображается.
            Label2.Text += "~Disposed~";
        }
    }
}