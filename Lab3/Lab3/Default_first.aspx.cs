using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Lab3
{
    public partial class Default_first : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            Select.Items.Add("Item 1");
            Select.Items.Add("Item 2");
            Select.Items.Add("Item 3");

            var htmlTable = new HtmlTable
            {
                Border = 1,
                CellPadding = 3,
                CellSpacing = 3,
                Align = "center",
                BorderColor = "black"
            };

            htmlTable.Style.Add("border-collapse", "collapse");
            htmlTable.ID = "HtmlTable";

            var titlesRow = new HtmlTableRow();

            var cell = new HtmlTableCell {InnerHtml = "Html Control"};
            titlesRow.Cells.Add(cell);

            cell = new HtmlTableCell {InnerHtml = "OnServerClick"};
            titlesRow.Cells.Add(cell);

            cell = new HtmlTableCell {InnerHtml = "OnServerChange"};
            titlesRow.Cells.Add(cell);

            htmlTable.Rows.Add(titlesRow);

            var resetButtonRow = new HtmlTableRow();

            cell = new HtmlTableCell {InnerHtml = "HtmlInputReset"};
            resetButtonRow.Cells.Add(cell);

            cell = new HtmlTableCell {InnerHtml = "NO"};
            resetButtonRow.Cells.Add(cell);

            cell = new HtmlTableCell {InnerHtml = "NO"};
            resetButtonRow.Cells.Add(cell);

            htmlTable.Rows.Add(resetButtonRow);

            Controls.Add(htmlTable);

            Session["HtmlTable"] = htmlTable;
        }

        protected void Button_ServerClick(object sender, EventArgs e)
        {
            AddRowToHtmlTable("HtmlInputButton", true, false);
        }

        protected void SubmitButton_ServerClick(object sender, EventArgs e)
        {
            AddRowToHtmlTable("HtmlInputSubmit", true, false);
        }

        protected void InputText_ServerChange(object sender, EventArgs e)
        {
            AddRowToHtmlTable("HtmlInputText", false, true);
        }

        protected void CheckBox_ServerChange(object sender, EventArgs e)
        {
            AddRowToHtmlTable("HtmlInputCheckbox", false, true);
        }

        private void AddRowToHtmlTable(string elementName, bool onServerClick, bool onServerChange)
        {
            if (!(Session["HtmlTable"] is HtmlTable htmlTable))
                return;

            var row = new HtmlTableRow();

            var cell = new HtmlTableCell {InnerHtml = elementName};
            row.Cells.Add(cell);

            cell = new HtmlTableCell {InnerHtml = onServerClick ? "YES" : "NO"};
            row.Cells.Add(cell);

            cell = new HtmlTableCell {InnerHtml = onServerChange ? "YES" : "NO"};
            row.Cells.Add(cell);

            htmlTable.Rows.Add(row);

            Controls.Add(htmlTable);
        }

        protected void Radio1_ServerChange(object sender, EventArgs e)
        {
            AddRowToHtmlTable("Radio1", false, true);
        }

        protected void Radio2_ServerChange(object sender, EventArgs e)
        {
            AddRowToHtmlTable("Radio2", false, true);
        }

        protected void TextArea_ServerChange(object sender, EventArgs e)
        {
            AddRowToHtmlTable("HtmlTextArea", false, true);
        }

        protected void Select_ServerChange(object sender, EventArgs e)
        {
            AddRowToHtmlTable("HtmlSelect", false, true);
        }

        protected void ResetButton_OnServerClick_ServerClick(object sender, EventArgs e)
        {
            AddRowToHtmlTable("HtmlInputReset", true, false);
        }
    }
}