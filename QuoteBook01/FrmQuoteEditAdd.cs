using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Quote2020;

namespace WfMain01
{

    public partial class FrmQuoteEditAdd : Form
    {
        private Quote quote = new Quote();

        public FrmQuoteEditAdd()
        {
            InitializeComponent();
        }

        public bool Populate()
        {
            List<String> values = QuoteBook.GetQuoteAuthors();
            foreach(var value in values)
            {
                this.cbAuthor.Items.Add(value);
            }
            values = QuoteBook.GetQuoteSources();
            foreach (var value in values)
            {
                this.cbSource.Items.Add(value);
            }
            return true;
        }

        public void GetQuote(out Quote quote)
        {
            quote = this.quote;
            quote.AUTHOR = this.cbAuthor.Text;
            quote.SOURCE = this.cbSource.Text;
            quote.CITATION = this.tbCitation.Text;
            quote.QUOTE = this.rtQuote.Text;
        }

        public void SetQuote(Quote zquote)
        {
            this.quote = zquote;
            this.cbAuthor.Text = quote.AUTHOR;
            this.cbSource.Text = quote.SOURCE;
            this.tbCitation.Text = quote.CITATION;
            this.rtQuote.Text = quote.QUOTE;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
