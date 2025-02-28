namespace WfMain01
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ssMessage = new System.Windows.Forms.StatusStrip();
            this.statState = new System.Windows.Forms.ToolStripStatusLabel();
            this.statMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.lbRows = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lbKeywords = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTopics = new System.Windows.Forms.ListBox();
            this.rtQuote = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.btnUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.btnGood = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.btnBad = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.btnUgly = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnAssignTopic = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQuoteCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQuoteEditByNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.gBUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextBatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBatchGBUSorted = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBatchGBUnSorted = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBatchGBUSearchLTD = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBatchGBUSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unassignedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssMessage.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssMessage
            // 
            this.ssMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statState,
            this.statMessage});
            this.ssMessage.Location = new System.Drawing.Point(0, 0);
            this.ssMessage.Name = "ssMessage";
            this.ssMessage.Padding = new System.Windows.Forms.Padding(2, 0, 19, 0);
            this.ssMessage.Size = new System.Drawing.Size(1067, 22);
            this.ssMessage.TabIndex = 2;
            this.ssMessage.Text = "statusStrip1";
            // 
            // statState
            // 
            this.statState.Name = "statState";
            this.statState.Size = new System.Drawing.Size(65, 17);
            this.statState.Text = "NojQuote4";
            // 
            // statMessage
            // 
            this.statMessage.Name = "statMessage";
            this.statMessage.Size = new System.Drawing.Size(16, 17);
            this.statMessage.Text = "...";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.ssMessage);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.scMain);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1067, 499);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1067, 554);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 0);
            this.scMain.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.lbRows);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.splitContainer1);
            this.scMain.Panel2.Controls.Add(this.toolStrip1);
            this.scMain.Size = new System.Drawing.Size(1067, 499);
            this.scMain.SplitterDistance = 354;
            this.scMain.SplitterWidth = 5;
            this.scMain.TabIndex = 2;
            // 
            // lbRows
            // 
            this.lbRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRows.FormattingEnabled = true;
            this.lbRows.ItemHeight = 20;
            this.lbRows.Location = new System.Drawing.Point(0, 0);
            this.lbRows.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lbRows.Name = "lbRows";
            this.lbRows.Size = new System.Drawing.Size(354, 499);
            this.lbRows.TabIndex = 0;
            this.lbRows.Click += new System.EventHandler(this.lbRows_SelectedIndexChanged);
            this.lbRows.SelectedIndexChanged += new System.EventHandler(this.lbRows_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.rtQuote);
            this.splitContainer1.Size = new System.Drawing.Size(708, 471);
            this.splitContainer1.SplitterDistance = 206;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lbKeywords);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lbTopics);
            this.splitContainer2.Size = new System.Drawing.Size(708, 206);
            this.splitContainer2.SplitterDistance = 233;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // lbKeywords
            // 
            this.lbKeywords.BackColor = System.Drawing.Color.Blue;
            this.lbKeywords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbKeywords.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKeywords.ForeColor = System.Drawing.Color.Wheat;
            this.lbKeywords.FormattingEnabled = true;
            this.lbKeywords.ItemHeight = 25;
            this.lbKeywords.Location = new System.Drawing.Point(0, 0);
            this.lbKeywords.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lbKeywords.Name = "lbKeywords";
            this.lbKeywords.ScrollAlwaysVisible = true;
            this.lbKeywords.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbKeywords.Size = new System.Drawing.Size(233, 206);
            this.lbKeywords.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 0);
            this.panel1.TabIndex = 1;
            // 
            // lbTopics
            // 
            this.lbTopics.BackColor = System.Drawing.Color.DarkOrange;
            this.lbTopics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTopics.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTopics.ForeColor = System.Drawing.Color.Wheat;
            this.lbTopics.FormattingEnabled = true;
            this.lbTopics.ItemHeight = 25;
            this.lbTopics.Location = new System.Drawing.Point(0, 0);
            this.lbTopics.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lbTopics.Name = "lbTopics";
            this.lbTopics.ScrollAlwaysVisible = true;
            this.lbTopics.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbTopics.Size = new System.Drawing.Size(470, 206);
            this.lbTopics.TabIndex = 0;
            // 
            // rtQuote
            // 
            this.rtQuote.BackColor = System.Drawing.Color.LightBlue;
            this.rtQuote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtQuote.Location = new System.Drawing.Point(0, 0);
            this.rtQuote.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rtQuote.Name = "rtQuote";
            this.rtQuote.ReadOnly = true;
            this.rtQuote.Size = new System.Drawing.Size(708, 260);
            this.rtQuote.TabIndex = 0;
            this.rtQuote.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNext,
            this.toolStripLabel3,
            this.btnUpdate,
            this.toolStripLabel2,
            this.btnDelete,
            this.toolStripLabel4,
            this.btnGood,
            this.toolStripLabel5,
            this.btnBad,
            this.toolStripLabel6,
            this.btnUgly,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.btnAssignTopic});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStrip1.Size = new System.Drawing.Size(708, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(51, 25);
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(22, 25);
            this.toolStripLabel3.Text = "   ";
            // 
            // btnUpdate
            // 
            this.btnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(51, 25);
            this.btnUpdate.Text = "BEST";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(22, 25);
            this.toolStripLabel2.Text = "   ";
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 25);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(22, 25);
            this.toolStripLabel4.Text = "   ";
            // 
            // btnGood
            // 
            this.btnGood.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnGood.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGood.Name = "btnGood";
            this.btnGood.Size = new System.Drawing.Size(61, 25);
            this.btnGood.Text = "GOOD";
            this.btnGood.Click += new System.EventHandler(this.btnGood_Click);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(22, 25);
            this.toolStripLabel5.Text = "   ";
            // 
            // btnBad
            // 
            this.btnBad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBad.Name = "btnBad";
            this.btnBad.Size = new System.Drawing.Size(47, 25);
            this.btnBad.Text = "BAD";
            this.btnBad.Click += new System.EventHandler(this.btnBad_Click);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(22, 25);
            this.toolStripLabel6.Text = "   ";
            // 
            // btnUgly
            // 
            this.btnUgly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUgly.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUgly.Name = "btnUgly";
            this.btnUgly.Size = new System.Drawing.Size(54, 25);
            this.btnUgly.Text = "UGLY";
            this.btnUgly.Click += new System.EventHandler(this.btnUgly_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(22, 25);
            this.toolStripLabel1.Text = "   ";
            // 
            // btnAssignTopic
            // 
            this.btnAssignTopic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAssignTopic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAssignTopic.Name = "btnAssignTopic";
            this.btnAssignTopic.Size = new System.Drawing.Size(94, 25);
            this.btnAssignTopic.Text = "New Topic";
            this.btnAssignTopic.Click += new System.EventHandler(this.btnAssignTopic_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.gBUToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1067, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuoteCreate,
            this.btnQuoteEditByNumber});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(87, 29);
            this.toolStripMenuItem1.Text = "Quotes";
            // 
            // btnQuoteCreate
            // 
            this.btnQuoteCreate.Name = "btnQuoteCreate";
            this.btnQuoteCreate.Size = new System.Drawing.Size(180, 30);
            this.btnQuoteCreate.Text = "New ...";
            this.btnQuoteCreate.Click += new System.EventHandler(this.btnQuoteCreate_Click);
            // 
            // btnQuoteEditByNumber
            // 
            this.btnQuoteEditByNumber.Name = "btnQuoteEditByNumber";
            this.btnQuoteEditByNumber.Size = new System.Drawing.Size(180, 30);
            this.btnQuoteEditByNumber.Text = "Edit ...";
            this.btnQuoteEditByNumber.Click += new System.EventHandler(this.btnQuoteEditByNumber_Click);
            // 
            // gBUToolStripMenuItem
            // 
            this.gBUToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextBatchToolStripMenuItem,
            this.searchToolStripMenuItem});
            this.gBUToolStripMenuItem.Name = "gBUToolStripMenuItem";
            this.gBUToolStripMenuItem.Size = new System.Drawing.Size(64, 29);
            this.gBUToolStripMenuItem.Text = "GBU";
            // 
            // nextBatchToolStripMenuItem
            // 
            this.nextBatchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBatchGBUSorted,
            this.btnBatchGBUnSorted});
            this.nextBatchToolStripMenuItem.Name = "nextBatchToolStripMenuItem";
            this.nextBatchToolStripMenuItem.Size = new System.Drawing.Size(181, 30);
            this.nextBatchToolStripMenuItem.Text = "Next Batch";
            // 
            // btnBatchGBUSorted
            // 
            this.btnBatchGBUSorted.Name = "btnBatchGBUSorted";
            this.btnBatchGBUSorted.Size = new System.Drawing.Size(180, 30);
            this.btnBatchGBUSorted.Text = "Sorted";
            this.btnBatchGBUSorted.Click += new System.EventHandler(this.btnBatchGBUSorted_Click);
            // 
            // btnBatchGBUnSorted
            // 
            this.btnBatchGBUnSorted.Name = "btnBatchGBUnSorted";
            this.btnBatchGBUnSorted.Size = new System.Drawing.Size(180, 30);
            this.btnBatchGBUnSorted.Text = "Unsorted";
            this.btnBatchGBUnSorted.Click += new System.EventHandler(this.btnBatchGBUnSorted_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBatchGBUSearchLTD,
            this.btnBatchGBUSearch});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(181, 30);
            this.searchToolStripMenuItem.Text = "Search";
            // 
            // btnBatchGBUSearchLTD
            // 
            this.btnBatchGBUSearchLTD.Name = "btnBatchGBUSearchLTD";
            this.btnBatchGBUSearchLTD.Size = new System.Drawing.Size(180, 30);
            this.btnBatchGBUSearchLTD.Text = "Limited";
            this.btnBatchGBUSearchLTD.Click += new System.EventHandler(this.btnBatchGBUSearchLTD_Click);
            // 
            // btnBatchGBUSearch
            // 
            this.btnBatchGBUSearch.Name = "btnBatchGBUSearch";
            this.btnBatchGBUSearch.Size = new System.Drawing.Size(180, 30);
            this.btnBatchGBUSearch.Text = "Unlimited";
            this.btnBatchGBUSearch.Click += new System.EventHandler(this.btnBatchGBUSearch_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllToolStripMenuItem,
            this.assignedToolStripMenuItem,
            this.unassignedToolStripMenuItem,
            this.deletedToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(116, 29);
            this.filterToolStripMenuItem.Text = "GBU_BEST";
            // 
            // showAllToolStripMenuItem
            // 
            this.showAllToolStripMenuItem.Name = "showAllToolStripMenuItem";
            this.showAllToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            this.showAllToolStripMenuItem.Text = "Show Al&l";
            this.showAllToolStripMenuItem.Click += new System.EventHandler(this.showAllToolStripMenuItem_Click);
            // 
            // assignedToolStripMenuItem
            // 
            this.assignedToolStripMenuItem.Name = "assignedToolStripMenuItem";
            this.assignedToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            this.assignedToolStripMenuItem.Text = "&Assigned";
            this.assignedToolStripMenuItem.Click += new System.EventHandler(this.assignedToolStripMenuItem_Click);
            // 
            // unassignedToolStripMenuItem
            // 
            this.unassignedToolStripMenuItem.Name = "unassignedToolStripMenuItem";
            this.unassignedToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            this.unassignedToolStripMenuItem.Text = "&Unassigned";
            this.unassignedToolStripMenuItem.Click += new System.EventHandler(this.unassignedToolStripMenuItem_Click);
            // 
            // deletedToolStripMenuItem
            // 
            this.deletedToolStripMenuItem.Name = "deletedToolStripMenuItem";
            this.deletedToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            this.deletedToolStripMenuItem.Text = "&Deleted";
            this.deletedToolStripMenuItem.Click += new System.EventHandler(this.deletedToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportCSVToolStripMenuItem,
            this.summaryToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(94, 29);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // exportCSVToolStripMenuItem
            // 
            this.exportCSVToolStripMenuItem.Name = "exportCSVToolStripMenuItem";
            this.exportCSVToolStripMenuItem.Size = new System.Drawing.Size(186, 30);
            this.exportCSVToolStripMenuItem.Text = "E&xport CSV";
            this.exportCSVToolStripMenuItem.Click += new System.EventHandler(this.exportCSVToolStripMenuItem_Click);
            // 
            // summaryToolStripMenuItem
            // 
            this.summaryToolStripMenuItem.Name = "summaryToolStripMenuItem";
            this.summaryToolStripMenuItem.Size = new System.Drawing.Size(186, 30);
            this.summaryToolStripMenuItem.Text = "S&ummary";
            this.summaryToolStripMenuItem.Click += new System.EventHandler(this.summaryToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FrmMain";
            this.Text = "Quote Book 01";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ssMessage.ResumeLayout(false);
            this.ssMessage.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.StatusStrip ssMessage;
        private System.Windows.Forms.ToolStripStatusLabel statState;
        private System.Windows.Forms.ToolStripStatusLabel statMessage;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.ListBox lbRows;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox lbKeywords;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lbTopics;
        private System.Windows.Forms.RichTextBox rtQuote;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton btnUpdate;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton btnGood;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripButton btnBad;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripButton btnUgly;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton btnAssignTopic;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnQuoteCreate;
        private System.Windows.Forms.ToolStripMenuItem btnQuoteEditByNumber;
        private System.Windows.Forms.ToolStripMenuItem gBUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextBatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnBatchGBUSorted;
        private System.Windows.Forms.ToolStripMenuItem btnBatchGBUnSorted;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnBatchGBUSearchLTD;
        private System.Windows.Forms.ToolStripMenuItem btnBatchGBUSearch;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unassignedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem summaryToolStripMenuItem;
    }
}

