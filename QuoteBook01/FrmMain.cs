using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


using Quote2020;

namespace WfMain01
{
    public partial class FrmMain : Form
    {
        private SortedDictionary<string, int> StarterTopics;
        private int pwPrimaryKey;

        public FrmMain()
        {
            InitializeComponent();
            StarterTopics = new SortedDictionary<string, int>();
            StarterTopics.Add("God", 0);
            StarterTopics.Add("Life", 0);
            StarterTopics.Add("Love", 0);
            StarterTopics.Add("Joy", 0);
            StarterTopics.Add("Hope", 0);
            StarterTopics.Add("Traditions", 0);
            StarterTopics.Add("Fate", 0);
            StarterTopics.Add("Hate", 0);
            StarterTopics.Add("Peace", 0);
            StarterTopics.Add("Sex", 0);
            StarterTopics.Add("Death", 0);
        }

        private void exportCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Export CSV Report", "TODO");
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Modal Summary Report", "TODO");
        }

        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoQuotes_ShowAll();
        }

        private void DoQuotes_ShowAll(string GBUCODE = "GBU_BEST")
        {
            if (!QuoteBook.LoadGBU(out List<Quote> quotes, GBUCODE))
            {
                ShowError("Unable to load database.");
            }
            else
            {
                LoadQuotes(quotes);
            }

        }

        private void LoadQuotes(List<Quote> quotes)
        {
            this.lbRows.Items.Clear();
            foreach (Quote quote in quotes)
            {
                string sVal = quote.ID.ToString();
                string line = $"{sVal.PadLeft(6, '0')} : {quote.QUOTE}";
                lbRows.Items.Add(line);
            }
            ShowStatus("Loaded " + quotes.Count + " quotes.");
        }

        private void assignedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoQuotes_ShowDone();
        }

        private void DoQuotes_ShowDone()
        {
            if (!QuoteBook.LoadDone(out List<Quote> quotes))
            {
                ShowError("Unable to load database.");
            }
            else
            {
                LoadQuotes(quotes);
            }

        }

        private void DoQuotes_ShowUnDone()
        {
            if (!QuoteBook.LoadUnDone(out List<Quote> quotes))
            {
                ShowError("Unable to load database.");
            }
            else
            {
                LoadQuotes(quotes);
            }

        }

        private void DoQuotes_ShowDeleted()
        {
            if (!QuoteBook.LoadDeleted(out List<Quote> quotes))
            {
                ShowError("Unable to load database.");
            }
            else
            {
                LoadQuotes(quotes);
            }

        }

        private void DoQuotes_ShowSortedGBU()
        {
            if (!QuoteBook.LoadTodoSortedLtd(out List<Quote> quotes))
            {
                ShowError("Unable to load database.");
            }
            else
            {
                LoadQuotes(quotes);
            }
        }


        private void DoQuotes_ShowGBU_Limited()
        {
            if (!QuoteBook.LoadTodoLtd(out List<Quote> quotes))
            {
                ShowError("Unable to load database.");
            }
            else
            {
                LoadQuotes(quotes);
            }
        }

        private void DoQuotes_SearchGBU_Limited()
        {
            string ntopic = Microsoft.VisualBasic.Interaction.InputBox("Quote Search", "");
            if (ntopic.Length > 0)
            {
                if (!QuoteBook.SearchTodoLtd(out List<Quote> quotes, ntopic))
                {
                    ShowError("Unable to load database.");
                }
                else
                {
                    LoadQuotes(quotes);
                }
            }
        }

        private void DoQuotes_SearchGBU_UnLimited()
        {
            string ntopic = Microsoft.VisualBasic.Interaction.InputBox("Quote Search", "");
            if (ntopic.Length > 0)
            {
                if (!QuoteBook.SearchTodoUnLtd(out List<Quote> quotes, ntopic))
                {
                    ShowError("Unable to load database.");
                }
                else
                {
                    LoadQuotes(quotes);
                }
            }
        }
        private void unassignedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoQuotes_ShowUnDone();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "NojQuote4";
        }

        private void lbRows_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = lbRows.SelectedItem;
            if (obj == null) return;
            string str = obj.ToString();
            if (_Row_Parse(str, out int iIndex))
            {
                ShowQuote(iIndex);
            }
            else
            {
                ShowStatus("Error: Invalid Key Selection.");
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MessageBox.Show("btnNext_Click ToDo", "TODO");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DoApproveBookQuote();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DoQuoteDelete();
        }

        private void ShowQuote(int iIndex)
        {
            this.pwPrimaryKey = -1;
            if (QuoteBook.Read(iIndex, out Quote quote) == false)
            {
                ShowStatus("Unable to locate #" + iIndex.ToString(), "Error");
                return;
            }
            pwPrimaryKey = iIndex;

            StringBuilder sb = new StringBuilder();
            sb.Append("ID:" + quote.ID);
            sb.Append("\n\n");
            sb.Append(quote.QUOTE);
            sb.Append("\n\n");
            sb.Append("Author:" + quote.AUTHOR);
            rtQuote.Text = sb.ToString();
            quote.GetKeywords(out List<KeyValuePair<string, bool>> keywords);
            lbKeywords.Items.Clear();
            foreach (var word in keywords)
            {
                lbKeywords.Items.Add(word.Key);
                lbKeywords.SetSelected(lbKeywords.Items.Count - 1, word.Value);
            }
            lbTopics.Items.Clear();
            quote.GetTopics(out List<String> qtopics);
            var topics = QuoteBook.AddTopics(this.StarterTopics);
            foreach (var word in topics.Keys)
            {
                lbTopics.Items.Add(topics[word].ToString() + "." + word);
                foreach (var qtopic in qtopics)
                {
                    if (qtopic == word)
                    {
                        lbTopics.SetSelected(lbTopics.Items.Count - 1, true);
                        break;
                    }
                }
            }
            ShowStatus(iIndex.ToString(), "Loaded");
        }

        internal void ShowError(string message)
        {
            MessageBox.Show(message, "Error");
            ShowStatus(message, "Error");
        }

        private void ShowStatus(string message, string state = "Okay")
        {
            this.statMessage.Text = message;
            this.statState.Text = state;
        }

        internal bool GetQuote(out Quote quote)
        {
            if (!QuoteBook.Read(this.pwPrimaryKey, out quote))
            {
                return false;
            }

            List<string> strings = new List<string>();
            ListBox.SelectedObjectCollection lselected = this.lbKeywords.SelectedItems;
            foreach (var key in lselected)
            {
                strings.Add(key.ToString());
            }
            quote.SetKeywords(strings); strings.Clear();
            lselected = this.lbTopics.SelectedItems;
            foreach (var key in lselected)
            {
                string zstr = key.ToString();
                int pos = zstr.IndexOf('.');
                if (pos != -1)
                {
                    zstr = zstr.Substring(pos + 1);
                }
                strings.Add(zstr);
            }
            quote.SetTopics(strings);
            return true;
        }

        internal void DoApproveBookQuote()
        {
            if (this.pwPrimaryKey <= 0)
            {
                return;
            }
            if (GetQuote(out Quote quote))
            {
                if (quote.ID <= 0)
                {
                    return;
                }
                List<Quote> data = new List<Quote>();
                data.Add(quote);
                if (!QuoteBook.UpdateKeywords(data))
                {
                    ShowError("KEYS: Unable to update database!");
                    return;
                }
                if (!QuoteBook.UpdateTopics(data))
                {
                    ShowError("TOPICS: Unable to update database!");
                    return;
                }
                if (quote.STATE != QuoteBook.STATE_DELETED)
                {
                    QuoteBook.SetStateReady(quote.ID); // TODO: Will want to remove deleted onus??
                }
                if (quote.GBUCODE != QuoteBook.GBU_BEST)
                {
                    QuoteBook.SetGbuCode(quote.ID, QuoteBook.GBU_BEST);
                }
            }
        }
        private void DoQuoteCreate()
        {
            var form = new FrmQuoteEditAdd();
            form.Populate();
            DialogResult result = form.ShowDialog();
            if(result == DialogResult.OK)
            {
                form.GetQuote(out Quote quote);
                quote = QuoteBook.CreateQuoteMin(quote);
                if (quote == null)
                {
                    this.ShowError("Quotation Creation Failure.");
                } else
                {
                    this.ShowStatus($"Created Quote #{quote.ID}");
                }
            }
            form.Close();
            form.Dispose();
        }
        private void DoQuoteEdit()
        {
           string ntopic = Microsoft.VisualBasic.Interaction.InputBox("Quote Number", "");
            if(ntopic == "")
            {
                return;
            }
            if(!int.TryParse(ntopic, out int value))
            {
                ShowError("Invalid quote number.");
            }

            if(!QuoteBook.Read(value, out Quote quote))
            {
                ShowError($"Quote #{value} not found.");
                return;
            }

            var form = new FrmQuoteEditAdd();
            form.SetQuote(quote);
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                form.GetQuote(out Quote quote2);
                if (QuoteBook.UpdateQuoteMin(quote2) == false)
                {
                    this.ShowError("Quotation Modification Failure.");
                } else
                {
                    this.ShowStatus($"Updated Quote #{quote2.ID}");
                }
            }
            form.Close();
            form.Dispose();
        }

        internal void DoRejectBookQuote(string gbucode)
        {
            if (this.pwPrimaryKey <= 0)
            {
                return;
            }
            if (GetQuote(out Quote quote))
            {
                if (quote.ID <= 0)
                {
                    return;
                }
                QuoteBook.SetState(quote.ID, QuoteBook.STATE_IGNORE);
                QuoteBook.SetGbuCode(quote.ID, gbucode);

            }
        }

        internal void DoQuoteDelete()
        {
            if (this.pwPrimaryKey > 0)
            {
                bool bOk = true;
                if (!QuoteBook.SetStateDeleted(this.pwPrimaryKey))
                {
                    ShowError("Unable to delete quote from database!");
                    bOk = false;
                }
                if (!QuoteBook.SetGbuCode(this.pwPrimaryKey, QuoteBook.GBU_BAD))
                {
                    ShowError("Unable to tag quote in the database!");
                    bOk = false;
                }
                if (bOk)
                {
                    if (_Row_Retire(this.pwPrimaryKey))
                        this.pwPrimaryKey = -1;
                }
            }
        }

        private bool _Row_Parse(string sListboxLine, out int iIndex)
        {
            iIndex = -1;
            int pos = sListboxLine.IndexOf(':');
            if (pos == -1)
            {
                return false;
            }
            iIndex = int.Parse(sListboxLine.Substring(0, pos).Trim());
            return true;
        }

        private bool _Row_Retire(int pwLine)
        {
            for (int ss = 0; ss < this.lbRows.Items.Count; ss++)
            {
                var row = this.lbRows.Items[ss];
                if (_Row_Parse(row.ToString(), out int iIndex))
                {
                    if (iIndex == pwLine)
                    {
                        this.lbRows.Items.RemoveAt(ss);
                        return true;
                    }
                }
            }
            return false;
        }

        private void deletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoQuotes_ShowDeleted();
        }

        private void btnAssignTopic_Click(object sender, EventArgs e)
        {
            string ntopic = Microsoft.VisualBasic.Interaction.InputBox("Assign Topic", "");
            if (ntopic.Length > 0)
            {
                lbTopics.Items.Insert(0, ntopic);
            }
        }

        private void btnBatchGBUSorted_Click(object sender, EventArgs e)
        {
            DoQuotes_ShowSortedGBU();
        }

        private void btnBatchGBUnSorted_Click(object sender, EventArgs e)
        {
            DoQuotes_ShowGBU_Limited();
        }

        private void btnBatchGBUSearchLTD_Click(object sender, EventArgs e)
        {
            DoQuotes_SearchGBU_Limited();
        }

        private void btnBatchGBUSearch_Click(object sender, EventArgs e)
        {
            DoQuotes_SearchGBU_UnLimited();
        }

        private void btnGood_Click(object sender, EventArgs e)
        {
            DoRejectBookQuote(QuoteBook.GBU_GOOD);
        }

        private void btnBad_Click(object sender, EventArgs e)
        {
            DoRejectBookQuote(QuoteBook.GBU_BAD);
        }

        private void btnUgly_Click(object sender, EventArgs e)
        {
            DoRejectBookQuote(QuoteBook.GBU_UGLY);
        }

        private void btnQuoteCreate_Click(object sender, EventArgs e)
        {
            DoQuoteCreate();
        }

        private void btnQuoteEditByNumber_Click(object sender, EventArgs e)
        {
            DoQuoteEdit();
        }
    }
}
