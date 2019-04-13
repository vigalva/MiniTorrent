using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiniTorrent.WebPortal
{
    public partial class Explorer : System.Web.UI.Page
    {
        private string SearchString = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        public string HighlightText(string InputTxt)
        {
            string Search_Str = txtSearch.Text;
            // Setup the regular expression and add the Or operator.
            Regex RegExp = new Regex(Search_Str.Replace(" ", "|").Trim(), RegexOptions.IgnoreCase);
            // Highlight keywords by calling the
            //delegate each time a keyword is found.
            return RegExp.Replace(InputTxt, new MatchEvaluator(ReplaceKeyWords));
        }

        public string ReplaceKeyWords(Match m)
        {
            return ("<span class=highlight>" + m.Value + "</span>");
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //  Set the value of the SearchString so it gets
            SearchString = txtSearch.Text;
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            //  Simple clean up text to return the Gridview to it's default state
            txtSearch.Text = "";
            SearchString = "";
            GridView1.DataBind();
        }
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchString = txtSearch.Text;
        }
    }
}